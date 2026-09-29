# T1 Keyboard Config

T1 迷你键盘(USB VID `1189` / PID `8890`)的**跨平台配置工具**。
我们逆向了厂商的 Windows 版 `MINI KeyBoard.exe`，并用 **Tkinter（仅标准库）**
重写为单文件 Python 应用，无任何运行时依赖。

[English](README.md) | [日本語](README.ja.md) | 简体中文 | [한국어](README.ko.md)

| 目标系统 | 状态 |
| --- | --- |
| Linux（推荐 Arch / Omarchy） | 实机验证完成（写入、监听、GUI） |
| Windows 11 | 已实现，**未验证**（本环境没有 Windows 机器） |
| macOS | 已实现，**未验证**（本环境没有 macOS 机器） |

- 按键映射（每个键最多 5 组组合）、修饰键、多媒体、鼠标、LED
- 层 1/2/3 切换与烧录
- 旋钮操作 → 音量 / VRChat OSC
- 按键 → VRChat OSC 映射
- `settings.json` 可在 3 种系统间通用（统一按 Linux evdev 编码保存）

---

## 运行要求

| 项目 | Linux | Windows 11 | macOS |
| --- | --- | --- | --- |
| Python | 3.9+ | 3.9+（python.org / winget） | 3.9+（python.org / brew） |
| 图形界面 | Tkinter（`tk`） | Tkinter（自带） | Tkinter（`python-tk`） |
| 写入通道 | usbfs（`/dev/bus/usb`） | HID（`WriteFile`） | IOHID（`SetReport`） |
| 音量控制 | `wpctl`（可选） | Core Audio（内置） | `osascript`（内置） |
| 附加软件包 | 无 | 无 | 无 |

```bash
# Arch
sudo pacman -S tk pipewire-utils
# Debian / Ubuntu
sudo apt install python3-tk
# Windows / macOS 通常已自带 Tkinter
python3 -c "import tkinter; print('ok')"
```

---

## 安装

### Linux：三种预编译包

由 `./build-packages.sh` 生成到 `../dist/`。

```bash
# Arch Linux (pacman)
sudo pacman -U dist/t1-keyboard-config-<ver>-1-x86_64.pkg.tar.zst

# Debian / Ubuntu (dpkg)
sudo dpkg -i dist/t1-keyboard-config_<ver>_amd64.deb   # 缺依赖时执行 sudo apt install -f

# 任意发行版（tarball）
tar xzf dist/t1-keyboard-linux-<ver>.tar.gz && cd t1-keyboard-linux-<ver> && ./install.sh
```

包方式安装会立即重载 udev 规则（不依赖会话，马上生效）。

### 从源码安装（所有系统）

```bash
./install.sh              # 图形界面 +（Linux 上的）udev 规则
./install.sh --autostart  # 登录时自动启动旋钮/OSC 监听
```

`install.sh` 会执行：

1. 把程序安装到 `~/.local/bin/t1-keyboard-config`
2. 在 `~/.local/share/applications/` 安装菜单项（Linux）
3. 在 Linux 上安装 `/etc/udev/rules.d/99-t1-keyboard.rules` 并重载 udev
   （只开放本设备的 usb / hidraw / input 节点，macOS/Windows 不需要）
4. 最后自动运行 `--selftest` 报告设备是否可用

卸载：`./uninstall.sh`

### Windows 11 / macOS（直接从源码运行）

```powershell
# Windows (PowerShell) - 无需安装其它组件
python t1-keyboard-config            # 图形界面
python t1-keyboard-config --selftest # 连接自检
```

```bash
# macOS
python3 t1-keyboard-config
# 如需加入 PATH
ln -s "$(pwd)/t1-keyboard-config" /usr/local/bin/t1-keyboard-config
```

> **为什么没有 `.exe` / `.app`**：本开发环境只有 Linux，因此 Windows 和 macOS 的
> 单文件程序**没有构建**（也无法在此测试）。分发方式如上所述为源码分发。
> 需要单文件程序时请参阅下面的“构建 Windows/macOS 可执行文件”。

---

## 使用方法

```bash
t1-keyboard-config            # 配置图形界面（需将 ~/.local/bin 加入 PATH）
t1-keyboard-config --selftest # 设备、权限、写入通道自检
t1-keyboard-config --watch    # 实时显示 T1 的输入事件
t1-keyboard-config --monitor  # 旋钮/OSC 监听守护进程（前台）
t1-keyboard-config --version
```

### 验证写入是否生效

```bash
t1-keyboard-config --watch      # 1) 按下 KEY1，查看当前编码
```

在图形界面中选择 `KEY1`，打开 `多媒体` 选项卡，选择“播放/暂停”并点击**写入**。
然后再次执行

```bash
t1-keyboard-config --watch      # 2) 再按一次 KEY1
```

若显示 `KEY_PLAYPAUSE` 即为正常（写入“无”可恢复原编码）。

### 图形界面操作说明

1. 在顶部选择**层**（1/2/3）
2. 在左侧选择**物理按键**（KEY1–KEY12 / K1-L…K2-R）
3. 在右侧选项卡选择分配方式
   - `按键` … 单个按键（双击某行可立即写入）
   - `修饰键` … 修饰键 + 基础键，可添加多个组合（最多 5 组）
   - `多媒体` / `鼠标` / `LED`
4. 点击「**写入**」

> 映射保存在键盘闪存中，**本工具无法读回**。
> “当前设置”只显示本工具写入过的记录。

### 旋钮 / VRChat OSC

1. 在 `旋钮` 选项卡选择要控制的模式（麦克风 / 耳机 / 用户音量）
2. 点击“学习旋转”并转动旋钮（默认：REL_HWHEEL / REL_WHEEL）
3. 点击“学习按下”并按一下旋钮
4. 点击“开始监听”（或运行 `t1-keyboard-config --monitor` / `--autostart`）
5. 在 `VRChat OSC` 选项卡为每个按键设置 OSC 地址，并点击“...”**学习**键值
   （学习时按下 T1 上对应的按键）

音量后端：Linux=`wpctl`、Windows=Core Audio、macOS=`osascript`；OSC 通过 UDP 发送。
日志：Linux `~/.local/state/t1-keyboard/monitor.log` /
Windows/macOS `%APPDATA%\t1-keyboard\state\monitor.log`

---

## 自检

```bash
t1-keyboard-config --selftest
```

| 检查项 | 失败时的处理 |
| --- | --- |
| platform | 报告运行系统 / Python 版本 |
| udev rule installed (Linux) | 重新执行 `sudo ./install.sh` |
| usb device present (Linux) | 检查线缆 / 集线器 |
| usb node permission (Linux) | 重载 udev 规则后重新插拔，再跑一次 `--selftest` |
| config interface | 检查是否有其它进程占用设备 |
| hidraw / input events | 同上；`sudo udevadm trigger` |

需要实际尝试一次无害写入时：

```bash
t1-keyboard-config --selftest --write
```

---

## 实现说明（协议）

原 Windows 版向 **USB 接口 1（`mi_01`）** 发送输出报告。
该接口只有 interrupt-OUT（EP 0x02），因此各系统使用不同通道：

| 系统 | 通道 |
| --- | --- |
| Linux | usbfs（`USBDEVFS_SUBMITURB`，失败时回退 SET_REPORT）。`usbhid` 不会绑定 IF1 |
| Windows | 打开 `mi_01` 上的 HID 设备并 `WriteFile`（与厂商 `WriteReport` 相同） |
| macOS | `IOHIDDeviceSetReport(kIOHIDReportTypeOutput)` |

帧格式为 `[ReportID][负载...]`，与原版 `Download_Click` 的顺序一致。

| 类型 | 负载 |
| --- | --- |
| 按键 | `[keynum][layer<<4\|1][groupCount][groupIndex][mod][usage]`（共 groupCount+1 组） |
| 多媒体 | `[keynum][layer<<4\|2][b5][b6]` |
| 鼠标 | `[keynum][layer<<4\|3][buttons][x][y][wheel][pan]` |
| LED | `[0xB0][layer<<4\|8][mode]` |
| 层切换 | `[0xA1][layer]` |
| 烧录确认 | `[0xAA][0xAA]`；LED 为 `[0xAA,0xA1]` |

报告 ID 优先从 HID 报告描述符自动识别；取不到时按原版顺序 `3 → 0 → 2` 探测
（`ReportID==0` 时不使用层 nibble）。

### 输入事件的统一编码

监听与学习使用的编码统一归一化为 **Linux evdev 编码**。

- Linux：直接读取 evdev
- Windows：Raw Input（`WM_INPUT`）→ `VK_TO_EVDEV` 转换（只过滤 T1）
- macOS：IOHID 回调 → `HID_USAGE_TO_EVDEV` / `CONSUMER_TO_EVDEV` 转换

因此 `settings.json` 可原样跨系统使用。

---

## 构建 Windows/macOS 可执行文件

本仓库以源码形式分发。需要单文件程序时：

```bash
pip install pyinstaller
pyinstaller --onefile --windowed --name t1-keyboard-config t1-keyboard-config
# 输出：dist/t1-keyboard-config(.exe)   ※必须在各自系统上构建
```

**本环境未构建**（需要真实的 Windows/macOS 机器或 CI）。

---

## 安全说明

`99-t1-keyboard.rules` **只对 VID/PID 匹配的节点**设置 `MODE="0666"`（仅 Linux）。
这样无需重新登录或加入 `input` 组即可使用，但同一台机器上登录的其他用户也能访问该设备。
多用户环境请改为 `MODE="0660"` + `GROUP="input"`，并把使用者加入 `input` 组。

macOS 上按键学习无效时，请在“系统设置 → 隐私与安全性 → **输入监控**”中允许本工具。

---

## 已知限制

- 固件不提供设置读回，写入结果必须在设备上确认
- 学习（旋钮按压 / 键值）依赖硬件实现，首次使用时各做一次即可
- Windows 版的“K3”“KEY13–16”按键在原程序中也未实现，因此本工具同样没有
- **Windows/macOS 的写入与输入后端未经验证**（开发环境没有对应系统）。
  请务必在实机上运行 `--selftest`，失败信息会显示在通知/标准输出中
- Windows 键值是把与布局相关的 VK 转换为 evdev 编码（日文布局的部分特殊键无法学习）

---

## 仓库结构

```
t1-keyboard-config          程序本体（单文件 / 可执行 / 三系统通用）
99-t1-keyboard.rules        udev 规则（仅 Linux）
install.sh / uninstall.sh   安装 / 卸载脚本
tests/test_protocol.py      协议编码器黄金测试
tests/test_monitor.py       监听 → OSC 集成测试
tests/test_platform.py      键值表 / 路径 / 输入后端测试
packaging/                  .deb 与 pacman 打包定义
build-release.sh            生成 tarball
build-packages.sh           一键生成 tarball + .deb + .pkg.tar.zst
LICENSE                     MIT
README.md                   英语版
README.ja.md                日语版
README.zh-CN.md             本文件（简体中文）
README.ko.md                韩语版
```

测试：`python3 tests/test_protocol.py` 等（共 41 件）。代码检查：`ruff check .`

---

## 许可证

MIT（见 `LICENSE`）。非官方工具，与厂商及 T1 无关。
