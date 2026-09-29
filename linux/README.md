# T1 Keyboard Config

Cross-platform configuration tool for the T1 mini keyboard (USB VID `1189` / PID `8890`).
We reverse-engineered the vendor's Windows `MINI KeyBoard.exe` and rewrote it as a
single-file Python application using **Tkinter (standard library only)** — no runtime
dependencies.

English | [日本語](README.ja.md) | [简体中文](README.zh-CN.md) | [한국어](README.ko.md)

| Target OS | Status |
| --- | --- |
| Linux (Arch / Omarchy recommended) | Verified on hardware (writes, monitor, GUI) |
| Windows 11 | Implemented, **not verified** (no Windows machine in this environment) |
| macOS | Implemented, **not verified** (no macOS machine in this environment) |

- Key assignments (up to 5 combos per key), modifier keys, multimedia, mouse, LEDs
- Layer 1/2/3 switching and flashing
- Dial rotation → volume / VRChat OSC
- Key → VRChat OSC mappings
- `settings.json` is portable across the 3 OSes (all codes stored as Linux evdev codes)

---

## Requirements

| Item | Linux | Windows 11 | macOS |
| --- | --- | --- | --- |
| Python | 3.9+ | 3.9+ (python.org / winget) | 3.9+ (python.org / brew) |
| GUI | Tkinter (`tk`) | Tkinter (bundled) | Tkinter (`python-tk`) |
| Write path | usbfs (`/dev/bus/usb`) | HID (`WriteFile`) | IOHID (`SetReport`) |
| Volume control | `wpctl` (optional) | Core Audio (built in) | `osascript` (built in) |
| Extra packages | none | none | none |

```bash
# Arch
sudo pacman -S tk pipewire-utils
# Debian / Ubuntu
sudo apt install python3-tk
# Windows / macOS usually ship Tkinter already
python3 -c "import tkinter; print('ok')"
```

---

## Installation

### Linux: three prebuilt packages

`./build-packages.sh` produces them in `../dist/`.

```bash
# Arch Linux (pacman)
sudo pacman -U dist/t1-keyboard-config-<ver>-1-x86_64.pkg.tar.zst

# Debian / Ubuntu (dpkg)
sudo dpkg -i dist/t1-keyboard-config_<ver>_amd64.deb   # then: sudo apt install -f if needed

# Any distro (tarball)
tar xzf dist/t1-keyboard-linux-<ver>.tar.gz && cd t1-keyboard-linux-<ver> && ./install.sh
```

Packaged installs reload the udev rule immediately (no session-dependent reload).

### From source (all OSes)

```bash
./install.sh              # GUI + (on Linux) the udev rule
./install.sh --autostart  # also start the dial/OSC monitor at login
```

`install.sh` does the following:

1. Installs the program to `~/.local/bin/t1-keyboard-config`
2. Installs a menu entry ("T1 キーボード設定" / "T1 Keyboard Config") to
   `~/.local/share/applications/` (Linux)
3. On Linux, installs `/etc/udev/rules.d/99-t1-keyboard.rules` and reloads udev
   (opens only this device's usb / hidraw / input nodes; not needed on macOS/Windows)
4. Runs `--selftest` at the end to report whether the device is usable

Uninstall: `./uninstall.sh`

### Windows 11 / macOS (run from source)

```powershell
# Windows (PowerShell) - nothing else to install
python t1-keyboard-config            # GUI
python t1-keyboard-config --selftest # connectivity check
```

```bash
# macOS
python3 t1-keyboard-config
# optional: put it on PATH
ln -s "$(pwd)/t1-keyboard-config" /usr/local/bin/t1-keyboard-config
```

> **Why no `.exe` / `.app`**: this development environment is Linux-only, so Windows and
> macOS binaries were **not built** (and cannot be tested here). The distribution is
> source-based as shown above. For build instructions see
> "Building a Windows/macOS executable" below.

---

## Usage

```bash
t1-keyboard-config            # configuration GUI (needs ~/.local/bin on PATH)
t1-keyboard-config --selftest # device, permission and write-path diagnostics
t1-keyboard-config --watch    # live stream of T1 input events
t1-keyboard-config --monitor  # dial/OSC monitor daemon (foreground)
t1-keyboard-config --version
```

### Verify that writes take effect

```bash
t1-keyboard-config --watch      # 1) press KEY1 to see its current code
```

In the GUI select `KEY1`, open the `Multimedia` tab, pick "Play/Pause" and press
**Write**. Then run

```bash
t1-keyboard-config --watch      # 2) press KEY1 again
```

It should now report `KEY_PLAYPAUSE` (write "None" to restore the original).

### GUI walkthrough

1. Pick a **layer** (1/2/3) at the top
2. Pick a **physical key** on the left (KEY1–KEY12 / K1-L…K2-R)
3. Choose the assignment on the right-hand tabs
   - `Keys` … a single key (double-click a row to write immediately)
   - `Modifiers` … modifier + base key, up to 5 groups
   - `Multimedia` / `Mouse` / `LED`
4. Press **Write**

> Mappings are stored in the keyboard's flash, so **they cannot be read back**.
> "Current settings" only shows what this tool has written.

### Dial / VRChat OSC

1. In the `Dial` tab pick the mode you want to control (mic / headphone / user volume)
2. Press "Learn rotation" and turn the dial (defaults: REL_HWHEEL / REL_WHEEL)
3. Press "Learn press" and press the dial once
4. Press "Start monitor" (or run `t1-keyboard-config --monitor` / `--autostart`)
5. In the `VRChat OSC` tab set an OSC address per key and click "…" to **learn** the
   key code (press that T1 key while it listens)

Volume backends: Linux=`wpctl`, Windows=Core Audio, macOS=`osascript`; OSC is sent over UDP.
Log: Linux `~/.local/state/t1-keyboard/monitor.log` /
Windows/macOS `%APPDATA%\t1-keyboard\state\monitor.log`

---

## Self test

```bash
t1-keyboard-config --selftest
```

| Check | If it fails |
| --- | --- |
| platform | reported OS / Python version |
| udev rule installed (Linux) | re-run `sudo ./install.sh` |
| usb device present (Linux) | check cable / hub |
| usb node permission (Linux) | reload the udev rule, replug the device, re-run `--selftest` |
| config interface | check that no other process holds the device |
| hidraw / input events | same as above; `sudo udevadm trigger` |

To also attempt a harmless write:

```bash
t1-keyboard-config --selftest --write
```

---

## Implementation notes (protocol)

The original Windows tool sends output reports to **USB interface 1 (`mi_01`)**.
That interface exposes interrupt-OUT (EP 0x02) only, so each OS takes a different path:

| OS | Path |
| --- | --- |
| Linux | usbfs (`USBDEVFS_SUBMITURB`, falling back to SET_REPORT). `usbhid` never binds IF1 |
| Windows | open the HID device on `mi_01` and `WriteFile` (same as the vendor's `WriteReport`) |
| macOS | `IOHIDDeviceSetReport(kIOHIDReportTypeOutput)` |

Frames are `[ReportID][payload...]`, in the same order as the original `Download_Click`.

| Kind | Payload |
| --- | --- |
| Key | `[keynum][layer<<4\|1][groupCount][groupIndex][mod][usage]` (groupCount+1 entries) |
| Multimedia | `[keynum][layer<<4\|2][b5][b6]` |
| Mouse | `[keynum][layer<<4\|3][buttons][x][y][wheel][pan]` |
| LED | `[0xB0][layer<<4\|8][mode]` |
| Layer switch | `[0xA1][layer]` |
| Flash commit | `[0xAA][0xAA]` / LEDs: `[0xAA,0xA1]` |

The report ID is auto-detected from the HID report descriptor, otherwise probed in the
vendor's order `3 → 0 → 2` (`ReportID==0` disables the layer nibble).

### Input event normalization

Codes used by the monitor and the learners are normalized to **Linux evdev codes**.

- Linux: read evdev directly
- Windows: Raw Input (`WM_INPUT`) → `VK_TO_EVDEV` (filtered to the T1 only)
- macOS: IOHID callbacks → `HID_USAGE_TO_EVDEV` / `CONSUMER_TO_EVDEV`

`settings.json` therefore transfers between OSes unchanged.

---

## Building a Windows/macOS executable

This repository ships as source. If you need a standalone binary:

```bash
pip install pyinstaller
pyinstaller --onefile --windowed --name t1-keyboard-config t1-keyboard-config
# output: dist/t1-keyboard-config(.exe)  - must be built on each target OS
```

**Not built here** — a real Windows/macOS machine or CI is required to build and test it.

---

## Security notes

`99-t1-keyboard.rules` sets `MODE="0666"` **only on nodes whose VID/PID match**
(Linux only). That avoids re-login and `input` group changes, but any user logged into
that machine can then access the device. On shared machines use `MODE="0660"` +
`GROUP="input"` and add the users to the `input` group.

If key learning does not work on macOS, allow this tool under
"System Settings → Privacy & Security → **Input Monitoring**".

---

## Known limitations

- The firmware offers no readback, so the effect of a write must be confirmed on the device
- Learning (dial press / key codes) depends on the hardware; do it once on first use
- The Windows app's "K3" and "KEY13–16" buttons are unimplemented in the original binary,
  so they are absent here as well
- **The Windows/macOS write and input backends are unverified** (no such OS in this
  development environment). Always run `--selftest` on the real machine; failures are
  reported in the toast / stdout
- Windows key codes convert layout-dependent VK values to evdev codes (some Japanese-layout
  special keys are not learnable)

---

## Repository layout

```
t1-keyboard-config          the program (single file / executable / all 3 OSes)
99-t1-keyboard.rules        udev rule (Linux only)
install.sh / uninstall.sh   installer / uninstaller
tests/test_protocol.py      protocol encoder golden tests
tests/test_monitor.py       monitor -> OSC integration test
tests/test_platform.py      key tables / paths / input backends
packaging/                  .deb and pacman package definitions
build-release.sh            tarball build
build-packages.sh           tarball + .deb + .pkg.tar.zst in one step
LICENSE                     MIT
README.md                   this file (English)
README.ja.md                Japanese
README.zh-CN.md             Simplified Chinese
README.ko.md                Korean
```

Tests: `python3 tests/test_protocol.py` and friends (41 total). Lint: `ruff check .`

---

## License

MIT (see `LICENSE`). Unofficial tool, not affiliated with the vendor or T1.
