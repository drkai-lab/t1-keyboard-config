#!/usr/bin/env python3
"""Golden-vector tests for the T1 protocol encoders.

Vectors are derived by hand from the decompiled Windows original
(decompiled/HIDTester/FormMain.cs Download_Click, MULKey.cs, MouseKey.cs,
LEDkey.cs) and must stay in sync with the firmware's expected frames.
"""

import importlib.machinery
import importlib.util
import os
import unittest

HERE = os.path.dirname(os.path.abspath(__file__))
SCRIPT = os.path.join(HERE, "..", "t1-keyboard-config")


def load_module():
    loader = importlib.machinery.SourceFileLoader("t1kb", SCRIPT)
    spec = importlib.util.spec_from_loader("t1kb", loader)
    module = importlib.util.module_from_spec(spec)
    loader.exec_module(module)
    return module


t1 = load_module()


class KeyReportsTest(unittest.TestCase):
    def test_plain_key_has_modifier_prologue(self):
        reports = t1.key_reports(1, 1, 3, [(0, 4)])
        self.assertEqual(len(reports), 2)
        self.assertEqual(reports[0], bytes([1, 0x11, 1, 0, 0, 0]))
        self.assertEqual(reports[1], bytes([1, 0x11, 1, 1, 0, 4]))

    def test_modifier_only_key(self):
        reports = t1.key_reports(5, 2, 3, [], 0x01)
        self.assertEqual(reports, [bytes([5, 0x21, 0, 0, 0x01, 0])])

    def test_ctrl_combo(self):
        reports = t1.key_reports(1, 1, 3, [(0x01, 4)])
        self.assertEqual(reports[1], bytes([1, 0x11, 1, 1, 0x01, 4]))

    def test_two_key_group_uses_second_slot(self):
        reports = t1.key_reports(3, 1, 3, [(0, 4), (0x02, 5)])
        self.assertEqual(len(reports), 3)
        self.assertEqual(reports[2], bytes([3, 0x11, 2, 2, 0x02, 5]))

    def test_group_count_capped_at_five(self):
        keys = [(0, 4), (0, 5), (0, 6), (0, 7), (0, 8), (0, 9), (0, 10)]
        reports = t1.key_reports(1, 1, 3, keys)
        self.assertEqual(len(reports), 6)
        self.assertEqual(reports[0][2], 5)
        self.assertEqual(reports[-1][3], 5)

    def test_report_id_zero_drops_layer_nibble(self):
        reports = t1.key_reports(1, 3, 0, [(0, 4)])
        self.assertEqual(reports[1][1], t1.TYPE_KEY)

    def test_layer_nibble(self):
        reports = t1.key_reports(1, 3, 3, [(0, 4)])
        self.assertEqual(reports[1][1], 0x31)


class MediaTest(unittest.TestCase):
    def test_report_id_3_uses_first_byte(self):
        self.assertEqual(t1.media_report(1, 1, 3, "play"), bytes([1, 0x12, 205, 0]))
        self.assertEqual(t1.media_report(1, 1, 3, "vol_up"), bytes([1, 0x12, 233, 0]))

    def test_report_id_0_values(self):
        self.assertEqual(t1.media_report(1, 1, 0, "play")[2:], bytes([64, 0]))
        self.assertEqual(t1.media_report(1, 1, 0, "next")[2:], bytes([0, 1]))

    def test_report_id_2_values(self):
        self.assertEqual(t1.media_report(1, 1, 2, "play")[2:], bytes([0, 4]))
        self.assertEqual(t1.media_report(1, 1, 2, "vol_up")[2:], bytes([64, 0]))

    def test_type_byte(self):
        self.assertEqual(t1.media_report(2, 2, 3, "mute")[1], 0x22)


class MouseTest(unittest.TestCase):
    def test_buttons(self):
        self.assertEqual(t1.mouse_report(1, 1, 3, "left"), bytes([1, 0x13, 1, 0, 0, 0, 0]))
        self.assertEqual(t1.mouse_report(2, 1, 3, "right")[2], 2)
        self.assertEqual(t1.mouse_report(3, 1, 3, "centre")[2], 4)

    def test_wheel(self):
        self.assertEqual(t1.mouse_report(1, 1, 3, "wheel_up"), bytes([1, 0x13, 0, 0, 0, 1, 0]))
        self.assertEqual(t1.mouse_report(1, 1, 3, "wheel_down")[5], 0xFF)

    def test_modified_wheel_matches_original_buffers(self):
        self.assertEqual(t1.mouse_report(1, 1, 3, "ctrl_wheel_up")[2:], bytes([0, 0, 1, 1, 0]))
        self.assertEqual(t1.mouse_report(1, 1, 3, "shift_wheel_up")[2:], bytes([0, 0, 1, 2, 0]))
        self.assertEqual(t1.mouse_report(1, 1, 3, "alt_wheel_down")[2:], bytes([0, 0, 1, 0xFF, 0]))


class CommandTest(unittest.TestCase):
    def test_led(self):
        self.assertEqual(t1.led_report(1, 3, 2), bytes([0xB0, 0x18, 2]))

    def test_layer_and_flash(self):
        self.assertEqual(t1.layer_report(1), bytes([0xA1, 1]))
        self.assertEqual(t1.layer_report(9), bytes([0xA1, 3]))
        self.assertEqual(t1.flash_report(), bytes([0xAA, 0xAA]))
        self.assertEqual(t1.flash_led_report(), bytes([0xAA, 0xA1]))
        self.assertEqual(t1.probe_report(), bytes([0x00, 0x00]))


class FramingTest(unittest.TestCase):
    def make_device(self, report_id=3, data_len=64, had_id=True):
        device = t1.T1Device()
        device.report_id = report_id
        device.data_len = data_len
        device.had_report_id = had_id
        return device

    def test_frame_with_report_id(self):
        frame = self.make_device().frame(bytes([0xAA, 0xAA]))
        self.assertEqual(len(frame), 65)
        self.assertEqual(frame[0], 3)
        self.assertEqual(frame[1:3], bytes([0xAA, 0xAA]))

    def test_frame_without_report_id(self):
        frame = self.make_device(report_id=0, data_len=8, had_id=False).frame(bytes([1, 2, 3]))
        self.assertEqual(frame, bytes([1, 2, 3, 0, 0, 0, 0, 0]))

    def test_frame_truncates_oversized_payload(self):
        frame = self.make_device(data_len=4).frame(bytes(range(20)))
        self.assertEqual(len(frame), 5)
        self.assertEqual(frame[1:], bytes([0, 1, 2, 3]))


class DescriptorTest(unittest.TestCase):
    def test_output_report_with_id(self):
        data = bytes([0x85, 3, 0x95, 0x40, 0x75, 0x08, 0x91, 0x02])
        parsed = t1.parse_report_descriptor(data)
        self.assertEqual(parsed, {"outputs": {3: 512}})

    def test_output_report_without_id(self):
        data = bytes([0x95, 8, 0x75, 8, 0x91, 0x02])
        parsed = t1.parse_report_descriptor(data)
        self.assertEqual(parsed, {"outputs": {0: 64}})

    def test_input_reports_are_ignored(self):
        data = bytes([0x85, 5, 0x95, 8, 0x75, 8, 0x81, 0x02])
        self.assertIsNone(t1.parse_report_descriptor(data))

    def test_multi_byte_report_count(self):
        data = bytes([0x96, 0x00, 0x01, 0x75, 0x08, 0x91, 0x02])
        parsed = t1.parse_report_descriptor(data)
        self.assertEqual(parsed, {"outputs": {0: 2048}})


def config_descriptor():
    """Synthetic config descriptor with three HID interfaces."""

    def interface(number, hid_length):
        return (
            bytes([9, 0x04, number, 0, 1, 3, 1, 1, 0])
            + bytes([9, 0x21, 0x11, 0x01, 0, 1, 0x22, hid_length & 0xFF, hid_length >> 8])
            + bytes([7, 0x05, 0x81, 3, 8, 0, 10])
        )

    body = interface(0, 64) + interface(1, 60) + interface(2, 70)
    head = bytes([9, 2]) + (9 + len(body)).to_bytes(2, "little") + bytes([3, 1, 0, 0x80, 50])
    return head + body


class HidDescriptorTest(unittest.TestCase):
    def test_lengths_per_interface(self):
        lengths = t1.hid_descriptor_lengths(config_descriptor())
        self.assertEqual(lengths, {0: 64, 1: 60, 2: 70})

    def test_target_interface_is_preferred(self):
        self.assertEqual(t1.hid_descriptor_lengths(config_descriptor()).get(1), 60)

    def test_rejects_bogus_lengths(self):
        data = bytes([9, 0x04, 1, 0, 1, 3, 1, 1, 0]) + bytes(
            [9, 0x21, 0x11, 0x01, 0, 1, 0x22, 4, 0]
        )
        self.assertEqual(t1.hid_descriptor_lengths(data), {})

    def test_truncated_descriptor_stops_cleanly(self):
        self.assertEqual(t1.hid_descriptor_lengths(config_descriptor()[:12]), {})


class IoctlConstantTest(unittest.TestCase):
    def test_usbfs_numbers(self):
        self.assertEqual(t1.USBDEVFS_SUBMITURB, 0x8038550A)
        self.assertEqual(t1.USBDEVFS_REAPURBNDELAY, 0x4008550D)
        self.assertEqual(t1.USBDEVFS_CONTROL, 0xC0185500)
        self.assertEqual(t1.USBDEVFS_CLAIMINTERFACE, 0x8004550F)

    def test_urb_struct_size(self):
        import ctypes

        self.assertEqual(ctypes.sizeof(t1._Urb), 56)
        self.assertEqual(ctypes.sizeof(t1._Ctrl), 24)


if __name__ == "__main__":
    unittest.main(verbosity=2)
