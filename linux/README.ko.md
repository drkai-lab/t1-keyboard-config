# T1 Keyboard Config

T1 미니 키보드(USB VID `1189` / PID `8890`)용 **크로스 플랫폼 설정 도구**입니다.
벤더의 Windows 버전 `MINI KeyBoard.exe` 프로토콜을 역공정하여 **Tkinter(표준 라이브러리만
사용)** 으로 다시 작성한 단일 파일 Python 애플리케이션입니다. 런타임 추가 의존성은 없습니다.

[English](README.md) | [日本語](README.ja.md) | [简体中文](README.zh-CN.md) | 한국어

| 대상 OS | 상태 |
| --- | --- |
| Linux (Arch / Omarchy 권장) | 실기기 검증 완료(쓰기·모니터·GUI) |
| Windows 11 | 구현 완료, **미검증**(이 환경에 Windows 머신 없음) |
| macOS | 구현 완료, **미검증**(이 환경에 macOS 머신 없음) |

- 키 할당(키당 최대 5개 조합), 수정자 키, 멀티미디어, 마우스, LED
- 레이어 1/2/3 전환 및 플래시
- 다이얼 입력 → 볼륨 / VRChat OSC
- 키 → VRChat OSC 매핑
- `settings.json`은 3개 OS에서 호환(evdev 코드로 정규화하여 저장)

---

## 요구 사항

| 항목 | Linux | Windows 11 | macOS |
| --- | --- | --- | --- |
| Python | 3.9 이상 | 3.9 이상 (python.org / winget) | 3.9 이상 (python.org / brew) |
| GUI | Tkinter (`tk`) | Tkinter (내장) | Tkinter (`python-tk`) |
| 쓰기 경로 | usbfs (`/dev/bus/usb`) | HID (`WriteFile`) | IOHID (`SetReport`) |
| 볼륨 제어 | `wpctl` (선택) | Core Audio (내장) | `osascript` (내장) |
| 추가 패키지 | 없음 | 없음 | 없음 |

```bash
# Arch
sudo pacman -S tk pipewire-utils
# Debian / Ubuntu
sudo apt install python3-tk
# Windows / macOS은 대부분 Tkinter가 기본 제공
python3 -c "import tkinter; print('ok')"
```

---

## 설치

### Linux: 사전 빌드 패키지 3종

`./build-packages.sh`가 `../dist/`에 생성합니다.

```bash
# Arch Linux (pacman)
sudo pacman -U dist/t1-keyboard-config-<ver>-1-x86_64.pkg.tar.zst

# Debian / Ubuntu (dpkg)
sudo dpkg -i dist/t1-keyboard-config_<ver>_amd64.deb   # 의존성 부족 시 sudo apt install -f

# 모든 배포판 (tarball)
tar xzf dist/t1-keyboard-linux-<ver>.tar.gz && cd t1-keyboard-linux-<ver> && ./install.sh
```

패키지 설치는 udev 규칙을 즉시 재로딩합니다(세션에 의존하지 않고 바로 유효).

### 소스에서 설치 (모든 OS)

```bash
./install.sh              # GUI + (Linux라면) udev 규칙
./install.sh --autostart  # 다이얼/OSC 모니터를 로그인 시에도 자동 시작
```

`install.sh`는 다음을 수행합니다.

1. `~/.local/bin/t1-keyboard-config`에 본체 설치
2. `~/.local/share/applications/`에 메뉴 항목 설치(Linux)
3. Linux에서 `/etc/udev/rules.d/99-t1-keyboard.rules` 설치 후 udev 재로딩
   (이 장치 전용 usb / hidraw / input 노드 개방, macOS/Windows는 불필요)
4. 마지막에 `--selftest`를 자동 실행하여 연결 가능 여부 표시

삭제: `./uninstall.sh`

### Windows 11 / macOS (소스 실행)

```powershell
# Windows (PowerShell) - 추가 설치 없이 바로 실행
python t1-keyboard-config            # GUI
python t1-keyboard-config --selftest # 연결 진단
```

```bash
# macOS
python3 t1-keyboard-config
# PATH에 넣으려면
ln -s "$(pwd)/t1-keyboard-config" /usr/local/bin/t1-keyboard-config
```

> **건너뛴 이유**: 이 개발 환경은 Linux뿐이라 Windows/macOS용 단일 실행 파일
> (`.exe` / `.app`)은 **빌드하지 않았습니다**(실행 검증도 불가능). 위는 소스 배포 기준
> 사용법입니다. 단일 exe가 필요하면 "Windows/macOS 실행 파일 빌드"를 참조하세요.

---

## 사용법

```bash
t1-keyboard-config            # 설정 GUI (PATH에 ~/.local/bin 필요)
t1-keyboard-config --selftest # 연결·권한·쓰기 경로 자가 진단
t1-keyboard-config --watch    # T1 입력 이벤트 실시간 표시
t1-keyboard-config --monitor  # 다이얼/OSC 모니터 데몬 (포그라운드)
t1-keyboard-config --version
```

### 쓰기가 적용되는지 확인

```bash
t1-keyboard-config --watch      # 1) KEY1을 눌러 현재 코드 확인
```

GUI에서 `KEY1`을 고르고 `멀티미디어` 탭의 "재생/일시정지"를 **쓰기**합니다.
이어서

```bash
t1-keyboard-config --watch      # 2) KEY1을 한 번 더 누릅니다
```

`KEY_PLAYPAUSE`가 나오면 정상입니다(원래 코드로 되돌리려면 "없음"을 쓰기).

### GUI 사용 방법

1. 상단의 **레이어** (1/2/3) 선택
2. 왼쪽의 **물리 키** (KEY1–KEY12 / K1-L…K2-R) 선택
3. 오른쪽 탭에서 할당 방식 선택
   - `키` … 단일 키(행을 더블 클릭하면 즉시 쓰기)
   - `수정자 키` … 수정자 + 기본 키, 그룹 추가 가능(최대 5개)
   - `멀티미디어` / `마우스` / `LED`
4. 「**쓰기**」 버튼 클릭

> 매핑은 키보드 플래시에 저장되므로 **이 도구로는 읽어올 수 없습니다**.
> "현재 설정 내용"은 이 도구가 쓴 기록만 표시합니다.

### 다이얼 / VRChat OSC

1. `다이얼` 탭에서 제어할 모드 선택(마이크 / 헤드폰 / 사용자 볼륨)
2. "회전 학습" → 다이얼을 돌림(기본: REL_HWHEEL / REL_WHEEL)
3. "누름 학습" → 다이얼을 한 번 누름
4. "모니터 시작" (또는 `t1-keyboard-config --monitor` / `--autostart`)
5. `VRChat OSC` 탭에서 키별 OSC 주소를 설정하고 "..."로 키 코드 **학습**
   (학습 중 해당 T1 키를 누르면 코드가 기록됨)

볼륨 백엔드: Linux=`wpctl`, Windows=Core Audio, macOS=`osascript`; OSC는 UDP 전송.
로그: Linux `~/.local/state/t1-keyboard/monitor.log` /
Windows/macOS `%APPDATA%\t1-keyboard\state\monitor.log`

---

## 자가 진단

```bash
t1-keyboard-config --selftest
```

| 검사 항목 | 실패 시 조치 |
| --- | --- |
| platform | 실행 중인 OS / Python 버전 |
| udev rule installed (Linux) | `sudo ./install.sh` 재실행 |
| usb device present (Linux) | 케이블 / 허브 확인 |
| usb node permission (Linux) | udev 규칙 재로딩 후 재연결 후 `--selftest` 재실행 |
| config interface | 다른 프로세스가 점유하지 않는지 확인 |
| hidraw / input events | 위와 동일. `sudo udevadm trigger` |

쓰기 경로까지 실제로 시험하려면:

```bash
t1-keyboard-config --selftest --write
```

---

## 구현 메모 (프로토콜)

원본 Windows 버전은 USB **인터페이스 1 (`mi_01`)** 에 출력 리포트를 보냅니다.
이 인터페이스는 interrupt-OUT (EP 0x02)만 있으므로 OS마다 다른 경로를 사용합니다.

| OS | 경로 |
| --- | --- |
| Linux | usbfs (`USBDEVFS_SUBMITURB` → 실패 시 SET_REPORT). `usbhid`는 IF1에 바인드하지 않음 |
| Windows | `mi_01`의 HID 디바이스를 열고 `WriteFile`(벤더 `WriteReport`와 동일) |
| macOS | `IOHIDDeviceSetReport(kIOHIDReportTypeOutput)` |

프레임은 `[ReportID][payload...]`. 원본 `Download_Click`과 같은 순서입니다.

| 종류 | 페이로드 |
| --- | --- |
| 키 | `[keynum][layer<<4\|1][groupCount][groupIndex][mod][usage]` (groupCount+1개) |
| 멀티미디어 | `[keynum][layer<<4\|2][b5][b6]` |
| 마우스 | `[keynum][layer<<4\|3][buttons][x][y][wheel][pan]` |
| LED | `[0xB0][layer<<4\|8][mode]` |
| 레이어 전환 | `[0xA1][layer]` |
| 플래시 확정 | `[0xAA][0xAA]` / LED는 `[0xAA,0xA1]` |

리포트 ID는 HID 리포트 디스크립터에서 자동 판정하고, 못 구하면 원본과 같은
`3 → 0 → 2` 순서로 프로브합니다(`ReportID==0`일 때만 레이어 nibble 없음).

### 입력 이벤트 정규화

모니터/학습에서 쓰는 코드는 **Linux evdev 코드로 정규화**하여 저장합니다.

- Linux: evdev를 그대로 읽음
- Windows: Raw Input (`WM_INPUT`) → `VK_TO_EVDEV`로 변환(T1만 필터)
- macOS: IOHID 콜백 → `HID_USAGE_TO_EVDEV` / `CONSUMER_TO_EVDEV`로 변환

이러므로 `settings.json`을 OS 간 그대로 옮겨 쓸 수 있습니다.

---

## Windows/macOS 실행 파일 빌드

이 저장소는 소스 배포입니다. 단일 실행 파일이 필요하면:

```bash
pip install pyinstaller
pyinstaller --onefile --windowed --name t1-keyboard-config t1-keyboard-config
# 출력: dist/t1-keyboard-config(.exe)   ※각 OS에서 빌드해야 합니다
```

**이 환경에서는 실행할 수 없어 미빌드**입니다(Windows/macOS 실기기 또는 CI 필요).

---

## 보안 참고

`99-t1-keyboard.rules`는 **VID/PID가 일치하는 노드만** `MODE="0666"`으로 설정합니다(Linux 전용).
이렇게 하면 재로그인이나 `input` 그룹 추가 없이 동작하지만, 그 머신에 로그인한 다른 사용자도
같은 장치에 접근할 수 있습니다. 다중 사용자 환경에서는 `MODE="0660"` + `GROUP="input"`으로
바꾸고 사용자를 `input` 그룹에 넣으세요.

macOS에서 키 학습이 안 되면 "시스템 설정 → 개인정보 보호 및 보안 → **입력 모니터링**"에서
이 도구를 허용하세요.

---

## 알려진 제약

- 펌웨어에서 설정을 읽어오는 기능이 없어, 쓰기 결과는 기기에서 확인해야 합니다
- 학습(다이얼 누름 / 키 코드)은 기기 구현에 의존하므로 최초 1회씩 수행하세요
- Windows 버전의 "K3", "KEY13–16" 버튼은 원본 바이너리에서도 미구현이라 이 도구에도 없습니다
- **Windows/macOS의 쓰기·입력 백엔드는 미검증**입니다(개발 환경에 해당 OS가 없음).
  실기기에서 반드시 `--selftest`를 실행하세요. 실패 시 알림/표준 출력에 오류가 표시됩니다
- Windows 키 코드는 레이아웃 의존 VK를 evdev 코드로 변환합니다(일부 일본어 레이아웃 특수 키는 학습 불가)

---

## 저장소 구성

```
t1-keyboard-config          본체 (단일 파일 / 실행 가능 / 3 OS 공통)
99-t1-keyboard.rules        udev 규칙 (Linux 전용)
install.sh / uninstall.sh   설치 / 삭제 스크립트
tests/test_protocol.py      프로토콜 인코더 골든 테스트
tests/test_monitor.py       모니터 → OSC 통합 테스트
tests/test_platform.py      키 테이블 / 경로 / 입력 백엔드 테스트
packaging/                  .deb / pacman 패키지 정의
build-release.sh            tarball 생성
build-packages.sh           tarball + .deb + .pkg.tar.zst 일괄 생성
LICENSE                     MIT
README.md                   영어판
README.ja.md                일본어판
README.zh-CN.md             중국어(간체)판
README.ko.md                이 파일 (한국어)
```

테스트: `python3 tests/test_protocol.py` 외 (총 41건). lint: `ruff check .`

---

## 라이선스

MIT (`LICENSE` 참고). 비공식 도구이며 벤더 및 T1과 무관합니다.
