#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""VRChat OSC hotkey daemon: Shift+1..0 -> OSC expression/gimmick control.

Registers global hotkeys (Shift+1 through Shift+0) on Windows and sends
OSC boolean messages (press=TRUE, release=FALSE) to VRChat. Each key maps
to a user-configurable OSC address (e.g. /avatar/parameters/Expression1).

This is a standalone tool, independent of the T1 keyboard monitor.

Usage:
    python vrc-hotkey-osc.py              # run with default config
    python vrc-hotkey-osc.py --config X   # use a custom config file
    python vrc-hotkey-osc.py --port 9000  # override the OSC port

Config file (default: %APPDATA%\\vrc-hotkey-osc\\settings.json):
    {
      "osc": {"host": "127.0.0.1", "port": 9000},
      "hotkeys": {
        "1": "/avatar/parameters/Expression1",
        "2": "/avatar/parameters/Expression2",
        ...
        "0": "/avatar/parameters/Expression10"
      }
    }
"""

from __future__ import annotations

import argparse
import ctypes
import json
import os
import sys
import time

if sys.platform == "win32":
    import ctypes.wintypes as wt

IS_WIN = sys.platform == "win32"

if IS_WIN:
    _root = os.environ.get("APPDATA") or os.path.expanduser("~")
    CONFIG_DIR = os.path.join(_root, "vrc-hotkey-osc")
else:
    CONFIG_DIR = os.path.expanduser("~/.config/vrc-hotkey-osc")

CONFIG_FILE = os.path.join(CONFIG_DIR, "settings.json")

# Virtual-key codes for the number row 1..0
VK_CODES = {
    "1": 0x31, "2": 0x32, "3": 0x33, "4": 0x34, "5": 0x35,
    "6": 0x36, "7": 0x37, "8": 0x38, "9": 0x39, "0": 0x30,
}

# Default OSC addresses for Shift+1..0
DEFAULT_HOTKEYS = {
    "1": "/avatar/parameters/Expression1",
    "2": "/avatar/parameters/Expression2",
    "3": "/avatar/parameters/Expression3",
    "4": "/avatar/parameters/Expression4",
    "5": "/avatar/parameters/Expression5",
    "6": "/avatar/parameters/Expression6",
    "7": "/avatar/parameters/Expression7",
    "8": "/avatar/parameters/Expression8",
    "9": "/avatar/parameters/Expression9",
    "0": "/avatar/parameters/Expression10",
}

MOD_NOREPEAT = 0x4000
WM_HOTKEY = 0x0312


def load_config(path=None):
    path = path or CONFIG_FILE
    try:
        with open(path, encoding="utf-8") as fh:
            data = json.load(fh)
            if isinstance(data, dict):
                return data
    except Exception:
        pass
    return {}


def save_config(config, path=None):
    path = path or CONFIG_FILE
    os.makedirs(os.path.dirname(path), exist_ok=True)
    tmp = path + ".tmp"
    with open(tmp, "w", encoding="utf-8") as fh:
        json.dump(config, fh, indent=2, ensure_ascii=False)
    os.replace(tmp, path)


class OscSender:
    def __init__(self, host="127.0.0.1", port=9000):
        self.host = host
        self.port = int(port)

    @staticmethod
    def _pad(raw):
        return raw + b"\x00" * ((4 - len(raw) % 4) % 4)

    def send_bool(self, address, value):
        import socket
        try:
            sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
            sock.sendto(self._pad(address.encode()) +
                        self._pad(b",T" if value else b",F") +
                        (b"\x01" if value else b"\x00"),
                        (self.host, self.port))
            sock.close()
            return True
        except OSError:
            return False


def run_daemon(config):
    if not IS_WIN:
        print("This tool requires Windows (global hotkeys).")
        return 1

    osc_cfg = config.get("osc", {})
    osc = OscSender(osc_cfg.get("host", "127.0.0.1"), osc_cfg.get("port", 9000))
    hotkeys = config.get("hotkeys", DEFAULT_HOTKEYS)

    user32 = ctypes.WinDLL("user32", use_last_error=True)
    kernel32 = ctypes.WinDLL("kernel32", use_last_error=True)

    # RegisterHotKey(NULL, id, MOD_SHIFT, vk)
    user32.RegisterHotKey.argtypes = [wt.HWND, ctypes.c_int, wt.UINT, wt.UINT]
    user32.RegisterHotKey.restype = wt.BOOL
    user32.UnregisterHotKey.argtypes = [wt.HWND, ctypes.c_int]
    user32.UnregisterHotKey.restype = wt.BOOL

    # GetMessageW
    class MSG(ctypes.Structure):
        _fields_ = [
            ("hwnd", wt.HWND),
            ("message", wt.UINT),
            ("wParam", wt.WPARAM),
            ("lParam", wt.LPARAM),
            ("time", wt.DWORD),
            ("pt_x", wt.LONG),
            ("pt_y", wt.LONG),
        ]

    msg = MSG()
    hotkey_ids = {}
    id_to_key = {}

    print("VRChat OSC hotkey daemon")
    print("  OSC: %s:%d" % (osc.host, osc.port))
    print("  Hotkeys: Shift+1..0")
    for key, addr in hotkeys.items():
        print("    Shift+%s -> %s" % (key, addr))
    print("Press Ctrl+C to exit.\n")

    # Register all hotkeys
    for i, (key, vk) in enumerate(VK_CODES.items()):
        hotkey_id = 0x1000 + i
        if user32.RegisterHotKey(None, hotkey_id, MOD_NOREPEAT | 0x0002, vk):
            hotkey_ids[key] = hotkey_id
            id_to_key[hotkey_id] = key
        else:
            err = ctypes.get_last_error()
            print("  WARNING: Failed to register Shift+%s (error %d)" % (key, err))

    if not hotkey_ids:
        print("ERROR: No hotkeys could be registered.")
        return 1

    # Message loop
    try:
        while True:
            result = user32.GetMessageW(ctypes.byref(msg), None, 0, 0)
            if result == 0 or result == -1:
                break
            if msg.message == WM_HOTKEY:
                hotkey_id = msg.wParam
                key = id_to_key.get(hotkey_id)
                if key is None:
                    continue
                address = hotkeys.get(key)
                if address is None:
                    continue
                # LOWORD of lParam = virtual key, HIWORD = modifiers
                # We send TRUE on press, FALSE on release (WM_HOTKEY fires on both)
                # Use GetAsyncKeyState to determine if the key is currently down
                vk = VK_CODES[key]
                is_down = (user32.GetAsyncKeyState(vk) & 0x8000) != 0
                osc.send_bool(address, is_down)
                print("  Shift+%s %s -> %s" % (key, "DOWN" if is_down else "UP", address))
    except KeyboardInterrupt:
        pass
    finally:
        for hotkey_id in hotkey_ids.values():
            user32.UnregisterHotKey(None, hotkey_id)
        print("\nDaemon stopped.")

    return 0


def main(argv=None):
    parser = argparse.ArgumentParser(
        prog="vrc-hotkey-osc",
        description="VRChat OSC hotkey daemon: Shift+1..0 -> OSC expression control")
    parser.add_argument("--config", default=None, help="path to a custom config file")
    parser.add_argument("--port", type=int, default=None, help="override the OSC port")
    parser.add_argument("--host", default=None, help="override the OSC host")
    parser.add_argument("--init", action="store_true",
                        help="create a default config file and exit")
    args = parser.parse_args(argv)

    config = load_config(args.config)

    if args.init:
        os.makedirs(os.path.dirname(CONFIG_FILE), exist_ok=True)
        save_config({
            "osc": {"host": "127.0.0.1", "port": 9000},
            "hotkeys": DEFAULT_HOTKEYS,
        }, args.config)
        print("Default config written to: %s" % (args.config or CONFIG_FILE))
        return 0

    if args.host:
        config.setdefault("osc", {})["host"] = args.host
    if args.port:
        config.setdefault("osc", {})["port"] = args.port

    return run_daemon(config)


if __name__ == "__main__":
    sys.exit(main())
