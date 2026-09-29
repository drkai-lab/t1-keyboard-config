#!/usr/bin/env bash
# Build every distributable artifact into ../dist/:
#   t1-keyboard-linux-<ver>.tar.gz                 generic tarball (./install.sh)
#   t1-keyboard-config_<ver>_amd64.deb             Debian / Ubuntu
#   t1-keyboard-config-<ver>-1-x86_64.pkg.tar.zst  Arch Linux (pacman -U)
set -euo pipefail

SRC_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PACKAGING="${SRC_DIR}/packaging"
DIST="$(cd "${SRC_DIR}/.." && pwd)/dist"
VERSION="$(sed -n 's/^VERSION = "\(.*\)"/\1/p' "${SRC_DIR}/t1-keyboard-config")"
DEB_NAME="t1-keyboard-config_${VERSION}_amd64.deb"
ARCH_NAME="t1-keyboard-config-${VERSION}-1-x86_64.pkg.tar.zst"

info() { printf '  \033[32mOK\033[0m  %s\n' "$1"; }
die()  { printf '  \033[31mNG\033[0m  %s\n' "$1" >&2; exit 1; }

echo "T1 Keyboard Config ${VERSION} - packaging"
echo "----------------------------------------"

mkdir -p "${DIST}"

# --- shared payload (identical for both packages) -------------------------
stage_payload() {
  local root="$1"
  install -Dm755 "${SRC_DIR}/t1-keyboard-config" \
    "${root}/usr/bin/t1-keyboard-config"
  install -Dm644 "${SRC_DIR}/99-t1-keyboard.rules" \
    "${root}/usr/lib/udev/rules.d/99-t1-keyboard.rules"
  install -Dm644 "${PACKAGING}/t1-keyboard-config.desktop" \
    "${root}/usr/share/applications/t1-keyboard-config.desktop"
  install -Dm644 "${SRC_DIR}/README.md" \
    "${root}/usr/share/doc/t1-keyboard-config/README.md"
  install -Dm644 "${SRC_DIR}/LICENSE" \
    "${root}/usr/share/doc/t1-keyboard-config/copyright"
  install -Dm644 "${SRC_DIR}/LICENSE" \
    "${root}/usr/share/licenses/t1-keyboard-config/LICENSE"
}

# --- 1. generic tarball ----------------------------------------------------
echo "tarball"
"${SRC_DIR}/build-release.sh" >/dev/null
info "$(basename "$(ls -1 "${DIST}"/t1-keyboard-linux-*.tar.gz | head -1)")"

# --- 2. Debian package -----------------------------------------------------
echo "debian"
command -v ar >/dev/null 2>&1 || die "ar not found (binutils)"
command -v tar >/dev/null 2>&1 || die "tar not found"

DEB_TMP="${DIST}/.deb-build"
rm -rf "${DEB_TMP}"
mkdir -p "${DEB_TMP}/data" "${DEB_TMP}/ctrl"

stage_payload "${DEB_TMP}/data"

installed_size="$(du -sk "${DEB_TMP}/data" | cut -f1)"
sed -e "s/@VERSION@/${VERSION}/" \
    -e "s/@SIZE@/${installed_size}/" \
    "${PACKAGING}/debian/control" > "${DEB_TMP}/ctrl/control"
install -m 0755 "${PACKAGING}/debian/postinst" "${DEB_TMP}/ctrl/postinst"
install -m 0755 "${PACKAGING}/debian/postrm"   "${DEB_TMP}/ctrl/postrm"

tar --numeric-owner --owner=0 --group=0 --format=gnu \
    -czf "${DEB_TMP}/control.tar.gz" -C "${DEB_TMP}/ctrl" .
tar --numeric-owner --owner=0 --group=0 --format=gnu \
    -czf "${DEB_TMP}/data.tar.gz" -C "${DEB_TMP}/data" .
printf '2.0\n' > "${DEB_TMP}/debian-binary"

rm -f "${DIST}/${DEB_NAME}"
( cd "${DEB_TMP}" && ar rc "${DIST}/${DEB_NAME}" \
    debian-binary control.tar.gz data.tar.gz )
rm -rf "${DEB_TMP}"
info "${DEB_NAME}"

# --- 3. Arch package -------------------------------------------------------
echo "arch"
command -v makepkg >/dev/null 2>&1 || die "makepkg not found (install base-devel)"

ARCH_DIR="${PACKAGING}/arch"
rm -rf "${ARCH_DIR}/payload" "${ARCH_DIR}/tests"
mkdir -p "${ARCH_DIR}/payload"
stage_payload "${ARCH_DIR}/payload"
cp -a "${SRC_DIR}/tests" "${ARCH_DIR}/tests"

( cd "${ARCH_DIR}" && makepkg -f --noconfirm --cleanbuild >/tmp/t1-makepkg.log 2>&1 ) \
  || { cat /tmp/t1-makepkg.log >&2; die "makepkg failed (see /tmp/t1-makepkg.log)"; }
rm -rf "${ARCH_DIR}/payload" "${ARCH_DIR}/tests" "${ARCH_DIR}/src" \
       "${ARCH_DIR}/pkg"
mv "${ARCH_DIR}/${ARCH_NAME}" "${DIST}/${ARCH_NAME}"
info "${ARCH_NAME}"

# --- checksums -------------------------------------------------------------
( cd "${DIST}" && sha256sum t1-keyboard-linux-*.tar.gz "${DEB_NAME}" \
    "${ARCH_NAME}" > SHA256SUMS )

echo
echo "Artifacts in ${DIST}:"
ls -lh "${DIST}" | tail -n +2 | sed 's/^/  /'
echo
echo "Install:"
echo "  Arch:    sudo pacman -U ${DIST}/${ARCH_NAME}"
echo "  Debian:  sudo dpkg -i ${DIST}/${DEB_NAME}   (deps: sudo apt install -f)"
echo "  Generic: tar xzf ${DIST}/t1-keyboard-linux-*.tar.gz && ./install.sh"
