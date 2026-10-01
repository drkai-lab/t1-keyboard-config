# T1 Expression Bridge (Unity)

Unity package that connects your **T1 keyboard** to avatar expressions via OSC.
Beginner-friendly: configure everything from a GUI, no code required.

## Features

- **OSC Receiver**: Listens for OSC messages on a configurable UDP port
- **VRChat Support**: Works with `VRCExpressionParameters`
- **Generic Avatars**: Works with any `Animator` (Bool/Int/Float parameters)
- **Beginner GUI**: Menu `Tools > T1 Expression Settings` for visual configuration
- **One-Click Setup**: Menu `Tools > T1 Expression > Setup Bridge`
- **Test Trigger**: Test each mapping without running the game

## Installation

### Option 1: Unity Package Manager (recommended)

1. Open Unity Package Manager (`Window > Package Manager`)
2. Click `+` > `Add package from git URL`
3. Enter: `https://github.com/drkai-lab/t1-keyboard-config.git?path=unity`
4. Click `Add`

### Option 2: Manual Copy

Copy the `unity/` folder into your Unity project's `Assets/` directory.

## Quick Start

1. **Setup the bridge**
   - Menu: `Tools > T1 Expression > Setup Bridge`
   - This creates a `T1 Expression Bridge` GameObject in your scene

2. **Configure OSC port**
   - Select the bridge GameObject
   - Set `Listen Port` to `9000` (or your sender's port)

3. **Assign your avatar** (optional)
   - Drag your avatar's `Animator` into the `Avatar Animator` field
   - For VRChat: drag `VRCExpressionParameters` into the `VRC Parameters` field

4. **Add mappings**
   - Menu: `Tools > T1 Expression Settings`
   - Click `+ Add Mapping`
   - For each mapping:
     - **T1 Key**: Select `KEY1`..`KEY12`, `K1-L`, etc.
     - **OSC Address**: Enter the OSC address (e.g. `/avatar/parameters/Expression1`)
     - **Animator Parameter**: Enter the parameter name (e.g. `Expression1`)
     - **Type**: Choose `Bool`, `Int`, or `Float`

5. **Run your T1 keyboard tool**
   - Run `t1-keyboard-config --monitor` or `vrc-hotkey-osc`
   - Press T1 keys to trigger expressions!

## Default Mappings (vrc-hotkey-osc)

| T1 Key | OSC Address | Expression |
|--------|-------------|------------|
| Shift+1 | `/avatar/parameters/Expression1` | Expression1 |
| Shift+2 | `/avatar/parameters/Expression2` | Expression2 |
| ... | ... | ... |
| Shift+0 | `/avatar/parameters/Expression10` | Expression10 |

## Expression Types

| Type | Behavior |
|------|----------|
| `Bool` | `true` when key pressed, `false` when released |
| `Int` | Sets to `Active Value` when pressed, `0` when released |
| `Float` | Sets to `Active Value` when pressed, `0.0` when released |

## Preset Expression Names

The settings window includes a `Presets` button with common VRChat expression names:
- `Expression1`..`Expression16`
- `FaceHappy`, `FaceSad`, `FaceAngry`, `FaceSurprised`
- `FaceBlink`, `FaceSmile`, `FaceFrown`, `FaceOpenMouth`
- `HandThumbsUp`, `HandPoint`, `HandFist`, `HandOpen`
- `GimmickOn`, `GimmickOff`, `Toggle1`, `Toggle2`

## Troubleshooting

| Problem | Solution |
|---------|----------|
| No OSC received | Check firewall, ensure port matches sender |
| Expression not triggering | Verify Animator parameter name (case-sensitive) |
| VRChat not responding | Ensure `VRCExpressionParameters` is assigned |
| Debug logs not shown | Enable `Show Debug Log` in the bridge component |

## License

MIT (see repository root `LICENSE`).
