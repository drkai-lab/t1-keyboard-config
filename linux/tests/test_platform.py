#!/usr/bin/env python3
"""Platform abstraction tests: key tables, paths, input source selection."""

import importlib.machinery
import importlib.util
import os
import tempfile
import unittest

HERE = os.path.dirname(os.path.abspath(__file__))
SCRIPT = os.path.join(HERE, "..", "t1-keyboard-config")

loader = importlib.machinery.SourceFileLoader("t1k_platform", SCRIPT)
spec = importlib.util.spec_from_loader("t1k_platform", loader)
t1 = importlib.util.module_from_spec(spec)
loader.exec_module(t1)


class KeyTableTest(unittest.TestCase):
    def test_windows_virtual_keys(self):
        table = t1.VK_TO_EVDEV
        self.assertEqual(table[0x41], 30)   # VK_A -> KEY_A
        self.assertEqual(table[0x5A], 44)   # VK_Z -> KEY_Z
        self.assertEqual(table[0x31], 2)    # VK_1 -> KEY_1
        self.assertEqual(table[0x30], 11)   # VK_0 -> KEY_0
        self.assertEqual(table[0x70], 59)   # VK_F1 -> KEY_F1
        self.assertEqual(table[0x7A], 87)   # VK_F11 -> KEY_F11
        self.assertEqual(table[0x7B], 88)   # VK_F12 -> KEY_F12
        self.assertEqual(table[0x26], 103)  # VK_UP -> KEY_UP
        self.assertEqual(table[0x25], 105)  # VK_LEFT -> KEY_LEFT
        self.assertEqual(table[0xAD], 113)  # mute
        self.assertEqual(table[0xAF], 114)  # volume up
        self.assertEqual(table[0xB3], 164)  # play/pause
        self.assertEqual(table[0x0D], 28)   # return
        self.assertEqual(table[0x1B], 1)    # escape

    def test_hid_usages(self):
        table = t1.HID_USAGE_TO_EVDEV
        self.assertEqual(table[0x04], 30)   # usage A
        self.assertEqual(table[0x1D], 44)   # usage Z
        self.assertEqual(table[0x1E], 2)    # usage 1
        self.assertEqual(table[0x27], 11)   # usage 0
        self.assertEqual(table[0x28], 28)   # enter
        self.assertEqual(table[0x3A], 59)   # F1
        self.assertEqual(table[0x45], 88)   # F12
        self.assertEqual(table[0x4F], 106)  # right
        self.assertEqual(table[0x52], 103)  # up
        self.assertEqual(table[0xE0], 29)   # left ctrl
        self.assertEqual(table[0xE5], 54)   # right shift

    def test_consumer_usages(self):
        table = t1.CONSUMER_TO_EVDEV
        self.assertEqual(table[0xE9], 114)
        self.assertEqual(table[0xEA], 115)
        self.assertEqual(table[0xE2], 113)
        self.assertEqual(table[0xCD], 164)

    def test_names_cover_the_tables(self):
        names = t1.EVDEV_KEY_NAMES
        checks = ((t1.EV_KEY, 30, "KEY_A"), (t1.EV_KEY, 44, "KEY_Z"),
                  (t1.EV_KEY, 2, "KEY_1"), (t1.EV_KEY, 59, "KEY_F1"),
                  (t1.EV_KEY, 103, "KEY_UP"), (t1.EV_KEY, 164, "KEY_PLAYPAUSE"),
                  (t1.EV_REL, 8, "REL_WHEEL"), (t1.EV_REL, 6, "REL_HWHEEL"))
        for etype, code, expected in checks:
            self.assertEqual(names[(etype, code)], expected)
        # code 6 is KEY_5 on EV_KEY and REL_HWHEEL on EV_REL
        self.assertEqual(names[(t1.EV_KEY, 6)], "KEY_5")
        self.assertEqual(names[(t1.EV_REL, 6)], "REL_HWHEEL")

    def test_mappings_agree_for_shared_keys(self):
        """Windows VK and macOS HID tables must agree on shared keys."""
        for vk, hid in ((0x41, 0x04), (0x5A, 0x1D), (0x0D, 0x28),
                        (0x26, 0x52), (0x25, 0x50), (0x70, 0x3A)):
            self.assertEqual(t1.VK_TO_EVDEV[vk], t1.HID_USAGE_TO_EVDEV[hid],
                             "disagreement for {vk:#x}")


class PathTest(unittest.TestCase):
    def test_settings_live_under_config_dir(self):
        self.assertTrue(t1.CONFIG_FILE.startswith(t1.CONFIG_DIR))
        self.assertTrue(t1.CONFIG_FILE.endswith("settings.json"))

    def test_pid_file_follows_state_dir(self):
        original = t1.STATE_DIR
        try:
            with tempfile.TemporaryDirectory() as tmp:
                t1.STATE_DIR = tmp
                self.assertEqual(t1.pid_file_path(),
                                 os.path.join(tmp, "monitor.pid"))
                t1.write_pid_file()
                self.assertTrue(os.path.exists(t1.pid_file_path()))
                t1.remove_pid_file()
                self.assertFalse(os.path.exists(t1.pid_file_path()))
        finally:
            t1.STATE_DIR = original

    def test_input_names_fall_back_without_kernel_header(self):
        original = t1.INPUT_CODES
        try:
            t1.INPUT_CODES = os.path.join(tempfile.gettempdir(), "missing.h")
            names = t1.load_input_names()
        finally:
            t1.INPUT_CODES = original
        self.assertEqual(names.get((t1.EV_KEY, 30)), "KEY_A")
        self.assertEqual(names.get((t1.EV_REL, 6)), "REL_HWHEEL")


class InputSourceTest(unittest.TestCase):
    def test_open_source_returns_a_source_or_none(self):
        source = t1.open_input_source()
        if source is None:
            self.assertTrue(t1.IS_LINUX or t1.IS_WIN or t1.IS_MAC)
            return
        try:
            self.assertTrue(hasattr(source, "wait"))
            self.assertTrue(source.describe())
            self.assertEqual(source.wait(0.01), [])
        finally:
            source.close()

    def test_linux_source_uses_module_level_helpers(self):
        """The monitor tests patch these; keep them wired to the module."""
        self.assertTrue(callable(t1.open_input_nodes))
        self.assertTrue(callable(t1.read_events))
        self.assertTrue(hasattr(t1, "select"))


if __name__ == "__main__":
    unittest.main(verbosity=2)
