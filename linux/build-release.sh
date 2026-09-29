#!/usr/bin/env bash
# Build the distributable tarball into ../dist/
set -euo pipefail

SRC_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
ROOT="$(cd "${SRC_DIR}/.." && pwd)"
VERSION="$(sed -n 's/^VERSION = "\(.*\)"/\1/p' "${SRC_DIR}/t1-keyboard-config")"
NAME="t1-keyboard-linux-${VERSION}"
DIST="$(cd "${SRC_DIR}/.." && pwd)/dist"
STAGE="${DIST}/${NAME}"

rm -rf "${STAGE}"
mkdir -p "${STAGE}/tests"

cp -a "${SRC_DIR}/t1-keyboard-config" \
      "${SRC_DIR}/99-t1-keyboard.rules" \
      "${SRC_DIR}/install.sh" \
      "${SRC_DIR}/uninstall.sh" \
      "${ROOT}/README.md" \
      "${ROOT}/README.ja.md" \
      "${ROOT}/README.zh-CN.md" \
      "${ROOT}/README.ko.md" \
      "${ROOT}/LICENSE" \
      "${SRC_DIR}/ruff.toml" "${STAGE}/"
cp -a "${SRC_DIR}/tests/." "${STAGE}/tests/"

python3 -m py_compile "${STAGE}/t1-keyboard-config"
for test in "${STAGE}"/tests/test_*.py; do
  python3 "$test" >/dev/null
done
rm -rf "${STAGE}/__pycache__" "${STAGE}/tests/__pycache__"

chmod +x "${STAGE}/t1-keyboard-config" "${STAGE}/install.sh" "${STAGE}/uninstall.sh"

tar -C "${DIST}" -czf "${DIST}/${NAME}.tar.gz" "${NAME}"
sha256sum "${DIST}/${NAME}.tar.gz" > "${DIST}/${NAME}.tar.gz.sha256"
rm -rf "${STAGE}"

echo "${DIST}/${NAME}.tar.gz"
cat "${DIST}/${NAME}.tar.gz.sha256"
