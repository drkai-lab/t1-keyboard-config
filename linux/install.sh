#!/usr/bin/env bash
# T1 mini keyboard - Linux installer
set -euo pipefail

SRC_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
BIN_DIR="${HOME}/.local/bin"
APP_DIR="${HOME}/.local/share/applications"
AUTOSTART_DIR="${HOME}/.config/autostart"
UDEV_RULE_SRC="${SRC_DIR}/99-t1-keyboard.rules"
UDEV_RULE_DST="/etc/udev/rules.d/99-t1-keyboard.rules"
APP_NAME="t1-keyboard-config"

ADD_AUTOSTART=0
SKIP_UDEV=0

for arg in "$@"; do
  case "$arg" in
    --autostart) ADD_AUTOSTART=1 ;;
    --no-udev) SKIP_UDEV=1 ;;
    -h|--help)
      cat <<EOF
T1 keyboard Linux installer

Usage: ./install.sh [options]
  --autostart   start the dial/OSC monitor daemon at login
  --no-udev     skip the udev rule (already installed / no sudo)
  -h, --help    this text
EOF
      exit 0 ;;
    *) echo "unknown option: $arg" >&2; exit 2 ;;
  esac
done

info() { printf '  \033[32mOK\033[0m  %s\n' "$1"; }
warn() { printf '  \033[33m!!\033[0m  %s\n' "$1"; }
fail() { printf '  \033[31mNG\033[0m  %s\n' "$1" >&2; }

echo "T1 Keyboard Config ${APP_NAME} installer"
echo "----------------------------------------"

# --- dependencies ----------------------------------------------------------
if ! command -v python3 >/dev/null 2>&1; then
  fail "python3 not found"
  exit 1
fi
info "python3 $(python3 -c 'import sys; print(".".join(map(str, sys.version_info[:3])))')"

if python3 -c 'import gi; gi.require_version("Gtk","4.0"); gi.require_version("Adw","1")' \
     >/dev/null 2>&1; then
  info "GTK4 + libadwaita bindings"
else
  fail "PyGObject GTK4/libadwaita missing"
  echo "       Arch:  sudo pacman -S python-gobject libadwaita"
  echo "       Debian: sudo apt install python3-gi gir1.2-gtk-4.0 gir1.2-adw-1"
  exit 1
fi

if command -v wpctl >/dev/null 2>&1; then
  info "wpctl (PipeWire volume control)"
else
  warn "wpctl not found - dial volume control disabled (pipewire-utils)"
fi

# --- binary ----------------------------------------------------------------
mkdir -p "${BIN_DIR}"
install -m 0755 "${SRC_DIR}/${APP_NAME}" "${BIN_DIR}/${APP_NAME}"
info "installed ${BIN_DIR}/${APP_NAME}"

# --- desktop entry ---------------------------------------------------------
mkdir -p "${APP_DIR}"
cat > "${APP_DIR}/${APP_NAME}.desktop" <<EOF
[Desktop Entry]
Name=T1 Keyboard Config
Name[ja]=T1 キーボード設定
Exec=${BIN_DIR}/${APP_NAME}
Terminal=false
Type=Application
Categories=Settings;Utility;
Comment=T1 mini keyboard configurator (VID 1189 / PID 8890)
Comment[ja]=T1ミニキーボード設定ツール
EOF
command -v update-desktop-database >/dev/null 2>&1 && \
  update-desktop-database "${APP_DIR}" >/dev/null 2>&1 || true
info "installed ${APP_DIR}/${APP_NAME}.desktop"

# --- optional monitor autostart -------------------------------------------
if [[ ${ADD_AUTOSTART} -eq 1 ]]; then
  mkdir -p "${AUTOSTART_DIR}"
  cat > "${AUTOSTART_DIR}/${APP_NAME}-monitor.desktop" <<EOF
[Desktop Entry]
Type=Application
Name=T1 Keyboard Monitor
Exec=${BIN_DIR}/${APP_NAME} --monitor
X-GNOME-Autostart-enabled=true
EOF
  info "monitor autostart enabled (${AUTOSTART_DIR})"
else
  echo "  ..  monitor autostart skipped (use --autostart to enable)"
fi

# --- udev rule -------------------------------------------------------------
if [[ ${SKIP_UDEV} -eq 0 ]]; then
  if [[ -f "${UDEV_RULE_SRC}" ]]; then
    if command -v sudo >/dev/null 2>&1; then
      if sudo -n cp "${UDEV_RULE_SRC}" "${UDEV_RULE_DST}" 2>/dev/null || \
         sudo cp "${UDEV_RULE_SRC}" "${UDEV_RULE_DST}"; then
        sudo udevadm control --reload-rules
        sudo udevadm trigger
        info "udev rule installed (${UDEV_RULE_DST})"
      else
        fail "could not install the udev rule - run manually:"
        echo "       sudo cp ${UDEV_RULE_SRC} ${UDEV_RULE_DST}"
        echo "       sudo udevadm control --reload-rules && sudo udevadm trigger"
      fi
    else
      fail "sudo not available - install the udev rule manually"
    fi
  else
    fail "99-t1-keyboard.rules not found next to install.sh"
  fi
else
  echo "  ..  udev rule skipped (--no-udev)"
fi

# --- self test -------------------------------------------------------------
echo
if "${BIN_DIR}/${APP_NAME}" --selftest; then
  echo
  echo "Install complete. Start with:"
  echo "  ${APP_NAME}                 # configuration GUI"
  echo "  ${APP_NAME} --monitor       # dial / VRChat OSC daemon"
  exit 0
else
  echo
  echo "Install finished, but the self test reported problems (see above)."
  echo "If the usb node still shows 'Permission denied', unplug and replug"
  echo "the keyboard, then run: ${APP_NAME} --selftest"
  exit 1
fi
