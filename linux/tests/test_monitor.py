#!/usr/bin/env python3
"""Integration test for the monitor daemon.

The monitor's evdev input is replaced by a scripted event source so the whole
chain (settings load -> event dispatch -> OSC) can be checked without pressing
keys on the hardware.
"""

import contextlib
import importlib.machinery
import importlib.util
import json
import os
import socket
import tempfile
import time
import types
import unittest

HERE = os.path.dirname(os.path.abspath(__file__))
SCRIPT = os.path.join(HERE, "..", "t1-keyboard-config")

loader = importlib.machinery.SourceFileLoader("t1k", SCRIPT)
spec = importlib.util.spec_from_loader("t1k", loader)
t1 = importlib.util.module_from_spec(spec)
loader.exec_module(t1)

PORT = 19111


def osc_string(data):
    end = data.index(b"\0")
    return data[:end].decode()


def set_addr(address):
    with open(t1.CONFIG_FILE) as fh:
        cfg = json.load(fh)
    cfg["key_osc"]["7"]["addr"] = address
    with open(t1.CONFIG_FILE, "w") as fh:
        json.dump(cfg, fh)


class MonitorTest(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.tmp = tempfile.mkdtemp(prefix="t1kb-test-")
        t1.CONFIG_FILE = os.path.join(cls.tmp, "settings.json")
        t1.STATE_DIR = cls.tmp
        t1.LOG_FILE = os.path.join(cls.tmp, "monitor.log")
        cls.srv = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        cls.srv.bind(("127.0.0.1", PORT))
        cls.srv.settimeout(0.3)

    @classmethod
    def tearDownClass(cls):
        cls.srv.close()

    def drain(self, seconds=1.0):
        packets = []
        end = time.time() + seconds
        while time.time() < end:
            with contextlib.suppress(TimeoutError):
                packets.append(self.srv.recv(4096))
        return packets

    def setUp(self):
        self.drain(0.2)

    def test_monitor_chain(self):
        script = []
        with open(t1.CONFIG_FILE, "w") as fh:
            json.dump(
                {
                    "osc": {
                        "host": "127.0.0.1",
                        "port": PORT,
                        "user_volume_addr": "/avatar/parameters/UserVolume",
                    },
                    "key_osc": {
                        "7": {"addr": "/avatar/parameters/Test", "toggle": False, "code": 7},
                        "8": {"addr": "/avatar/parameters/Toggle", "toggle": True, "code": 8},
                    },
                    "dial": {
                        "modes": ["user"],
                        "rotate_codes": [6],
                        "push_code": None,
                        "step": 0.1,
                    },
                },
                fh,
            )

        script.extend([("event", t1.EV_KEY, 7, 1), ("event", t1.EV_KEY, 7, 0)])
        script.extend([("event", t1.EV_KEY, 8, 1)])
        script.extend([("event", t1.EV_KEY, 8, 1)])
        script.extend([("event", t1.EV_KEY, 7, 1), ("event", t1.EV_KEY, 7, 0)])
        script.extend([("event", t1.EV_REL, 6, 1)] * 3)
        script.append(("stop",))

        original_read = t1.read_events
        calls = {"n": 0}

        def fake_read(fd):
            calls["n"] += 1
            if not script:
                raise KeyboardInterrupt
            item = script.pop(0)
            if item[0] == "stop":
                raise KeyboardInterrupt
            if item[0] == "func":
                item[1]()
                return []
            return [(item[1], item[2], item[3])]

        t1.open_input_nodes = lambda nonblock=True: [(99, "/dev/fake")]
        t1.read_events = fake_read
        t1.select = types.SimpleNamespace(select=lambda r, w, x, t: (list(r), [], []))
        try:
            with self.assertRaises(KeyboardInterrupt):
                t1.run_monitor()
        finally:
            t1.read_events = original_read

        self.assertGreater(calls["n"], 5, "monitor never polled events")

    def test_osc_packets(self):
        """Re-run the chain and inspect the datagrams it produced."""
        script = [
            ("event", t1.EV_KEY, 7, 1),
            ("event", t1.EV_KEY, 7, 0),
            ("func", lambda: set_addr("/avatar/parameters/Renamed")),
            ("event", t1.EV_KEY, 7, 1),
            ("event", t1.EV_KEY, 7, 0),
            ("event", t1.EV_KEY, 8, 1),
            ("event", t1.EV_REL, 6, 1),
            ("event", t1.EV_REL, 6, -1),
            ("stop",),
        ]
        with open(t1.CONFIG_FILE, "w") as fh:
            json.dump(
                {
                    "osc": {
                        "host": "127.0.0.1",
                        "port": PORT,
                        "user_volume_addr": "/avatar/parameters/UserVolume",
                    },
                    "key_osc": {
                        "7": {"addr": "/avatar/parameters/Test", "toggle": False, "code": 7},
                        "8": {"addr": "/avatar/parameters/Toggle", "toggle": True, "code": 8},
                    },
                    "dial": {
                        "modes": ["user"],
                        "rotate_codes": [6],
                        "push_code": None,
                        "step": 0.25,
                    },
                },
                fh,
            )

        def fake_read(fd):
            item = script.pop(0)
            if item[0] == "stop":
                raise KeyboardInterrupt
            if item[0] == "func":
                item[1]()
                return []
            return [(item[1], item[2], item[3])]

        original_read = t1.read_events
        t1.open_input_nodes = lambda nonblock=True: [(99, "/dev/fake")]
        t1.read_events = fake_read
        t1.select = types.SimpleNamespace(select=lambda r, w, x, t: (list(r), [], []))
        try:
            with self.assertRaises(KeyboardInterrupt):
                t1.run_monitor()
        finally:
            t1.read_events = original_read

        packets = self.drain(1.0)
        blob = b"".join(packets)
        self.assertIn(b"/avatar/parameters/Test", blob, blob[:200])
        self.assertIn(b"/avatar/parameters/Renamed", blob, "settings hot reload must be picked up")
        self.assertIn(b",T", blob)
        self.assertIn(b",F", blob, "momentary key must send a release")
        self.assertIn(b"/avatar/parameters/Toggle", blob, "toggle key")
        self.assertIn(b"/avatar/parameters/UserVolume", blob, "dial -> OSC float")
        self.assertIn(b",f", blob)
        self.assertEqual(
            blob.count(b"/avatar/parameters/Test"),
            2,
            "momentary key must send exactly one press + one release",
        )
        self.assertEqual(
            blob.count(b"/avatar/parameters/Renamed"),
            2,
            "reloaded binding must also send press + release",
        )


if __name__ == "__main__":
    unittest.main(verbosity=2)
