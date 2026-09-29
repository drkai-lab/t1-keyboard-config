# T1 Keyboard Config for Linux

T1 ミニキーボード(USB VID `1189` / PID `8890`)向けの **Linux ネイティブ設定ツール**です。
ベンダー製 Windows 版 `MINI KeyBoard.exe` のプロトコルを解析し、GTK4 + libadwaita で
書き直した単一ファイルの Python アプリです。Windows / Wine は不要です。

- キー割り当て(最大5グループのコンボ)、修飾キー、マルチメディア、マウス、LED
- レイヤー 1/2/3 の切替と書き込み
- ダイヤル操作 → 音量 / VRChat OSC
- キー → VRChat OSC マッピング
- 依存は Python 標準ライブラリ + PyGObject (GTK4/Adw)

---

## 動作要件

| 項目 | 内容 |
| --- | --- |
| OS | Linux (systemd + udev, Arch / Omarchy 推奨) |
| Python | 3.9 以上 |
| GUI | GTK 4 + libadwaita (PyGObject) |
| 音量操作 | `wpctl` (pipewire-utils) — 任意 |
| セッション | X11 / Wayland どちらも可 |

```bash
# Arch
sudo pacman -S python-gobject libadwaita pipewire-utils
# Debian / Ubuntu
sudo apt install python3-gi gir1.2-gtk-4.0 gir1.2-adw-1
```

---

## インストール

配布パッケージ 3 種類から使えます(`./build-packages.sh` で `../dist/` に生成)。

```bash
# Arch Linux (pacman)
sudo pacman -U dist/t1-keyboard-config-<ver>-1-x86_64.pkg.tar.zst

# Debian / Ubuntu (dpkg)
sudo dpkg -i dist/t1-keyboard-config_<ver>_amd64.deb   # 依存不足なら sudo apt install -f

# どのディストリでも (tarball)
tar xzf dist/t1-keyboard-linux-<ver>.tar.gz && cd t1-keyboard-linux-<ver> && ./install.sh
```

パッケージ版は udev ルールを自動で再読込します(セッションに影響されず即時有効)。

### ソースからインストール

```bash
./install.sh              # GUI + udev ルール
./install.sh --autostart  # ダイヤル/OSC 監視をログイン時にも自動起動
```

`install.sh` は次を行います。

1. `~/.local/bin/t1-keyboard-config` に本体を配置
2. `~/.local/share/applications/` にメニュー項目(「T1 キーボード設定」)を配置
3. `/etc/udev/rules.d/99-t1-keyboard.rules` を入れて udev を再読込
   (このデバイス専用の usb / hidraw / input ノードを開放)
4. 最後に `--selftest` を自動実行して接続可否を表示

アンインストール: `./uninstall.sh`

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

デスクトップメニューの「**T1 キーボード設定**」からも起動できます。

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
2. 「**回転を学習**」→ ダイヤルを回す(既定では REL_HWHEEL/REL_WHEEL を使用)
3. 「**押し込みを学習**」→ ダイヤルを1回押す
4. 「**監視開始**」(または `t1-keyboard-config --monitor` / `--autostart`)
5. `VRChat OSC` タブでキーごとに OSC アドレスを設定し、必要な行を「...」で**学習**
   (T1 のそのキーを押すと evdev コードが記録されます)

音量は `wpctl`、OSC は UDP 送信(外部ライブラリ不使用)です。
ログ: `~/.local/state/t1-keyboard/monitor.log`

---

## 自己診断

```bash
t1-keyboard-config --selftest
```

| 検査項目 | 失敗時の対処 |
| --- | --- |
| udev rule installed | `sudo ./install.sh` を再実行 |
| usb device present | ケーブル / ハブを確認 |
| usb node permission | udev ルール再読込後、抜け挿し(`--selftest` 再実行) |
| config interface | 別プロセスが usbfs を掴んでいないか確認 |
| hidraw / input events | 同上。`sudo udevadm trigger` |

書き込み経路まで実際に試す場合:

```bash
t1-keyboard-config --selftest --write
```

---

## 実装メモ(プロトコル)

元の Windows 版は USB **インターフェース 1 (mi_01)** に対して出力レポートを送ります。
このインターフェースは interrupt-OUT (EP 0x02) のみで Linux カーネルの `usbhid` は
バインドしないため、`/dev/bus/usb/BBB/DDD` (usbfs) に直接 URB を投げます
(INTERRUPT URB → 失敗時 SET_REPORT コントロール転送にフォールバック)。

フレームは `[ReportID][payload...]`。元版 `Download_Click` と同じ並びです。

| 種別 | ペイロード |
| --- | --- |
| キー | `[keynum][layer<<4\|1][groupCount][groupIndex][mod][usage]` (groupCount+1 本) |
| マルチメディア | `[keynum][layer<<4\|2][b5][b6]` |
| マウス | `[keynum][layer<<4\|3][buttons][x][y][wheel][pan]` |
| LED | `[0xB0][layer<<4\|8][mode]` |
| レイヤー切替 | `[0xA1][layer]` |
| フラッシュ確定 | `[0xAA][0xAA]` / LED は `[0xAA][0xA1]` |

レポートIDは HID レポートディスクリプタを取得して自動判定し、
取れなければ元版と同じ `3 → 0 → 2` の順でプローブします。
(`ReportID==0` の場合のみレイヤー nibble を付けません)

テスト: `python3 tests/test_protocol.py`(プロトコル 29 件)/ `python3 tests/test_monitor.py`(モニタ→OSC 2 件)

---

## セキュリティ上の注意

`99-t1-keyboard.rules` は **VID/PID が一致するノードのみ** を `MODE="0666"` にします。
これにより再ログインや `input` グループ追加なしで動きますが、そのマシンにログインできる
他のユーザーも同デバイスへアクセスできます。複数ユーザー環境では `MODE="0660"` +
`GROUP="input"` に変更し、利用者を `input` グループに入れてください。

---

## 既知の制限

- ファームウェアからの設定読み出しは存在しないため、書き込み結果は本体側で確認する必要があります
- 学習(ダイヤル押し込み / キーコード)は本体の実装に依存するため、初回に1回ずつ実施してください
- Windows 版の「K3」「KEY13〜16」ボタンは元バイナリでも未実装のため本ツールにもありません

---

## ファイル構成

```
t1-keyboard-config          本体 (単一ファイル / 実行可能)
99-t1-keyboard.rules        udev ルール
install.sh / uninstall.sh   インストーラ / アンインストーラ
tests/test_protocol.py      プロトコルエンコーダのゴールデンテスト
packaging/                  .deb / pacman 用のパッケージ定義
build-release.sh            tarball 生成
build-packages.sh           tarball + .deb + .pkg.tar.zst 一括生成
LICENSE                     MIT
README.md                   このファイル
```

パッケージ再生成: `./build-packages.sh`(要 `ar` / `makepkg`)。
lint: `ruff check .`、テスト: `python3 tests/test_protocol.py` ほか。

---

## ライセンス

MIT(参照: `LICENSE`)。非公式ツールです。ベンダーおよび T1 とは関係ありません。
