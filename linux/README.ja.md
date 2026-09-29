# T1 Keyboard Config

T1 ミニキーボード(USB VID `1189` / PID `8890`)向けの **クロスプラットフォーム設定ツール**です。
ベンダー製 Windows 版 `MINI KeyBoard.exe` のプロトコルを解析し、**Tkinter(標準ライブラリ)** で
書き直した単一ファイルの Python アプリです。追加のランタイム依存はありません。

[English](README.md) | 日本語 | [简体中文](README.zh-CN.md) | [한국어](README.ko.md)

| 対応 OS | 状態 |
| --- | --- |
| Linux (Arch / Omarchy 推奨) | 実機検証済み(書き込み・モニタ・GUI) |
| Windows 11 | 実装済み **未検証**(この環境に Windows が無いため) |
| macOS | 実装済み **未検証**(この環境に macOS が無いため) |

- キー割り当て(最大5グループのコンボ)、修飾キー、マルチメディア、マウス、LED
- レイヤー 1/2/3 の切替と書き込み
- ダイヤル操作 → 音量 / VRChat OSC
- キー → VRChat OSC マッピング
- 設定ファイルは 3 OS 間で互換(evdev コードに正規化して保存)

---

## 動作要件

| 項目 | Linux | Windows 11 | macOS |
| --- | --- | --- | --- |
| Python | 3.9 以上 | 3.9 以上 (python.org / winget) | 3.9 以上 (python.org / brew) |
| GUI | Tkinter (`tk`) | Tkinter (同梱) | Tkinter (`python-tk`) |
| 書き込み経路 | usbfs (`/dev/bus/usb`) | HID (`WriteFile`) | IOHID (`SetReport`) |
| 音量操作 | `wpctl` (任意) | Core Audio (内蔵) | `osascript` (内蔵) |
| 追加パッケージ | なし | なし | なし |

```bash
# Arch
sudo pacman -S tk pipewire-utils
# Debian / Ubuntu
sudo apt install python3-tk
# Windows / macOS は Tkinter が既定で入っていることが多い
python3 -c "import tkinter; print('ok')"
```

---

## インストール

### Linux: 配布パッケージ 3 種類

`./build-packages.sh` が `../dist/` に生成します。

```bash
# Arch Linux (pacman)
sudo pacman -U dist/t1-keyboard-config-<ver>-1-x86_64.pkg.tar.zst

# Debian / Ubuntu (dpkg)
sudo dpkg -i dist/t1-keyboard-config_<ver>_amd64.deb   # 依存不足なら sudo apt install -f

# どのディストリでも (tarball)
tar xzf dist/t1-keyboard-linux-<ver>.tar.gz && cd t1-keyboard-linux-<ver> && ./install.sh
```

パッケージ版は udev ルールを自動で再読込します(セッションに影響されず即時有効)。

### ソースから(全 OS 共通)

```bash
./install.sh              # GUI + (Linux なら) udev ルール
./install.sh --autostart  # ダイヤル/OSC 監視をログイン時にも自動起動
```

`install.sh` は次を行います。

1. `~/.local/bin/t1-keyboard-config` に本体を配置
2. `~/.local/share/applications/` にメニュー項目(「T1 キーボード設定」)を配置(Linux)
3. Linux では `/etc/udev/rules.d/99-t1-keyboard.rules` を入れて udev を再読込
   (このデバイス専用の usb / hidraw / input ノードを開放。macOS/Windows は不要)
4. 最後に `--selftest` を自動実行して接続可否を表示

アンインストール: `./uninstall.sh`

### Windows 11 / macOS (ソース実行)

```powershell
# Windows (PowerShell) - 追加インストール不要、そのまま実行
python t1-keyboard-config            # GUI
python t1-keyboard-config --selftest # 接続診断
```

```bash
# macOS
python3 t1-keyboard-config
# メニューに置く場合
ln -s "$(pwd)/t1-keyboard-config" /usr/local/bin/t1-keyboard-config
```

> **スキップ理由**: この開発環境は Linux のみのため、Windows/macOS 向けの
> 単体実行ファイル(`.exe` / `.app`)は**生成していません**(実行検証も不能)。
> 上記はソース配布での利用手順です。単体 exe が要る場合のビルド手順は
> 「Windows/macOS 向けの exe を作る場合」を参照してください。

---

## 起動方法

```bash
t1-keyboard-config            # 設定 GUI (PATH に ~/.local/bin が必要)
t1-keyboard-config --selftest # 接続・権限・書き込み経路の自己診断
t1-keyboard-config --watch    # T1 の入力イベントをライブ表示 (動作確認)
t1-keyboard-config --monitor  # ダイヤル/OSC 監視デーモン (フォアグラウンド)
t1-keyboard-config --version
```

### 動作確認(書き込みが効いているか)

```bash
t1-keyboard-config --watch      # 1) KEY1 を押して現在のコードを確認
```

GUI で `KEY1` を選び、`マルチメディア` タブの「再生/一時停止」を**書き込み**。
続けて

```bash
t1-keyboard-config --watch      # 2) もう一度 KEY1 を押す
```

で `KEY_PLAYPAUSE` が出ていれば正常です(元のコードに戻すには「無効」を書き込み)。

### GUI の使い方

1. 上部の**レイヤー** (1/2/3) を選ぶ
2. 左の**物理キー** (KEY1〜KEY12 / K1-L〜K2-R) を選ぶ
3. 右のタブで割り当てを選ぶ
   - `キー` … 単打キー(行をダブルクリックですぐ書き込み)
   - `修飾キー` … 修飾キー + ベースキー、複数グループ追加可(最大5)
   - `マルチメディア` / `マウス` / `LED`
4. 「**書き込み**」を押す

> マッピングはキーボード本体のフラッシュに保存されるため、**このツールでは読み戻せません**。
> 「現在の設定内容」は本ツールが書き込んだ記録のみを表示します。

### ダイヤル / VRChat OSC

1. `ダイヤル` タブで使うモードを選ぶ(マイク / イヤーマフ / ユーザー音量)
2. 「**回転を学習**」→ ダイヤルを回す(既定は REL_HWHEEL / REL_WHEEL)
3. 「**押し込みを学習**」→ ダイヤルを1回押す
4. 「**監視開始**」(または `t1-keyboard-config --monitor` / `--autostart`)
5. `VRChat OSC` タブでキーごとに OSC アドレスを設定し、必要な行を「...」で**学習**
   (T1 のそのキーを押すとコードが記録されます)

音量は Linux=`wpctl`、Windows=Core Audio、macOS=`osascript`、OSC は UDP 送信です。
ログ: Linux `~/.local/state/t1-keyboard/monitor.log` /
Windows/macOS `%APPDATA%\t1-keyboard\state\monitor.log`

---

## 自己診断

```bash
t1-keyboard-config --selftest
```

| 検査項目 | 失敗時の対処 |
| --- | --- |
| platform | 実行中の OS / Python バージョン |
| udev rule installed (Linux) | `sudo ./install.sh` を再実行 |
| usb device present (Linux) | ケーブル / ハブを確認 |
| usb node permission (Linux) | udev ルール再読込後、抜け挿し(`--selftest` 再実行) |
| config interface | 別プロセスが掴んでいないか確認 |
| hidraw / input events | 同上。`sudo udevadm trigger` |

書き込み経路まで実際に試す場合:

```bash
t1-keyboard-config --selftest --write
```

---

## 実装メモ(プロトコル)

元の Windows 版は USB **インターフェース 1 (mi_01)** に対して出力レポートを送ります。
このインターフェースは interrupt-OUT (EP 0x02) のみで、OS ごとに次の経路を使います。

| OS | 経路 |
| --- | --- |
| Linux | usbfs (`USBDEVFS_SUBMITURB` → 失敗時 SET_REPORT)。`usbhid` は IF1 にバインドしません |
| Windows | `mi_01` の HID デバイスを開き `WriteFile`(= ベンダー版の `WriteReport` と同じ) |
| macOS | `IOHIDDeviceSetReport(kIOHIDReportTypeOutput)` |

フレームは `[ReportID][payload...]`。元版 `Download_Click` と同じ並びです。

| 種別 | ペイロード |
| --- | --- |
| キー | `[keynum][layer<<4\|1][groupCount][groupIndex][mod][usage]` (groupCount+1 本) |
| マルチメディア | `[keynum][layer<<4\|2][b5][b6]` |
| マウス | `[keynum][layer<<4\|3][buttons][x][y][wheel][pan]` |
| LED | `[0xB0][layer<<4\|8][mode]` |
| レイヤー切替 | `[0xA1][layer]` |
| フラッシュ確定 | `[0xAA][0xAA]` / LED は `[0xAA,0xA1]` |

レポートIDは HID レポートディスクリプタから自動判定し、取れなければ
元版と同じ `3 → 0 → 2` の順でプローブします(`ReportID==0` の場合のみレイヤー nibble なし)。

### 入力イベントの正規化

モニタ/学習で使うコードは **Linux evdev コードに正規化**して保存します。

- Linux: evdev をそのまま読む
- Windows: Raw Input (`WM_INPUT`) → `VK_TO_EVDEV` で変換(T1 のみにフィルタ)
- macOS: IOHID コールバック → `HID_USAGE_TO_EVDEV` / `CONSUMER_TO_EVDEV` で変換

これにより `settings.json` は OS をまたいでそのまま使えます。

---

## Windows/macOS 向けの exe を作る場合

このリポジトリはソース配布です。単体実行ファイルが必要な場合:

```bash
pip install pyinstaller
pyinstaller --onefile --windowed --name t1-keyboard-config t1-keyboard-config
# 生成物: dist/t1-keyboard-config(.exe)   ※各 OS 上でビルドする必要があります
```

**この環境では実行できないため未生成**です(Windows/macOS の実機または CI が必要)。

---

## セキュリティ上の注意

`99-t1-keyboard.rules` は **VID/PID が一致するノードのみ** を `MODE="0666"` にします(Linux のみ)。
これにより再ログインや `input` グループ追加なしで動きますが、そのマシンにログインできる
他のユーザーも同デバイスへアクセスできます。複数ユーザー環境では `MODE="0660"` +
`GROUP="input"` に変更し、利用者を `input` グループに入れてください。

macOS でキー学習が動かない場合は「システム設定 → プライバシーとセキュリティ →
**入力モニタリング**」で本ツールを許可してください。

---

## 既知の制限

- ファームウェアからの設定読み出しは存在しないため、書き込み結果は本体側で確認する必要があります
- 学習(ダイヤル押し込み / キーコード)は本体の実装に依存するため、初回に1回ずつ実施してください
- Windows 版の「K3」「KEY13〜16」ボタンは元バイナリでも未実装のため本ツールにもありません
- **Windows/macOS の書き込み・入力バックエンドは未検証**です(開発環境に該当 OS が無いため)。
  実機で `--selftest` を必ず実行してください。失敗時はエラー内容がトースト/標準出力に出ます
- Windows のキーコードはキーボードレイアウト依存の VK を evdev に変換しています
  (日本語配列の特殊キーなど一部は学習対象外)

---

## リポジトリ構成

```
t1-keyboard-config          本体 (単一ファイル / 実行可能 / 3 OS 共通)
99-t1-keyboard.rules        udev ルール (Linux のみ)
install.sh / uninstall.sh   インストーラ / アンインストーラ
tests/test_protocol.py      プロトコルエンコーダのゴールデンテスト
tests/test_monitor.py       モニタ → OSC の結合テスト
tests/test_platform.py      キーテーブル / パス / 入力バックエンドのテスト
packaging/                  .deb / pacman 用のパッケージ定義
build-release.sh            tarball 生成
build-packages.sh           tarball + .deb + .pkg.tar.zst 一括生成
LICENSE                     MIT
README.md                   英語版
README.ja.md                このファイル (日本語)
README.zh-CN.md             簡体字中国語版
README.ko.md                韓国語版
```

テスト: `python3 tests/test_protocol.py` ほか(計41件)。lint: `ruff check .`

---

## ライセンス

MIT(参照: `LICENSE`)。非公式ツールです。ベンダーおよび T1 とは関係ありません。
