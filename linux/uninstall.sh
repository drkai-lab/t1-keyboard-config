#!/usr/bin/env bash
# T1 mini keyboard - Linux uninstaller
set -euo pipefail

BIN="${HOME}/.local/bin/t1-keyboard-config"
DESKTOP="${HOME}/.local/share/applications/t1-keyboard-config.desktop"
AUTOSTART="${HOME}/.config/autostart/t1-keyboard-config-monitor.desktop"
UDEV_RULE="/etc/udev/rules.d/99-t1-keyboard.rules"

rm -f "${BIN}" && echo "  OK  removed ${BIN}"
rm -f "${DESKTOP}" && echo "  OK  removed ${DESKTOP}"
rm -f "${AUTOSTART}" && echo "  OK  removed ${AUTOSTART}"

pkill -f "t1-keyboard-config --monitor" 2>/dev/null || true

if [[ -f "${UDEV_RULE}" ]]; then
  if sudo rm -f "${UDEV_RULE}"; then
    sudo udevadm control --reload-rules
    sudo udevadm trigger
    echo "  OK  removed ${UDEV_RULE}"
  else
    echo "  NG  could not remove ${UDEV_RULE}" >&2
    exit 1
  fi
fi

echo
echo "Settings kept at ~/.config/t1-keyboard (delete manually if desired)."
