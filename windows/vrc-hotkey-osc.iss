; Inno Setup script for VRChat OSC hotkey daemon (Windows 11)
; Builds an installer with start-menu entry and a clean uninstaller.

#define AppName "VRChat OSC Hotkey"
#define AppVersion "1.0.0"
#define AppPublisher "drkai-lab"
#define AppURL "https://github.com/drkai-lab/t1-keyboard-config"

[Setup]
AppId={{A1B2C3D4-E5F6-7890-ABCD-EF1234567890}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
AppPublisherURL={#AppURL}
AppSupportURL={#AppURL}
AppUpdatesURL={#AppURL}
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
DisableProgramGroupPage=yes
OutputDir=..\dist-win
OutputBaseFilename=vrc-hotkey-osc-{#AppVersion}-setup
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
UninstallDisplayIcon={app}\vrc-hotkey-osc.exe
ArchitecturesInstallIn64BitMode=x64compatible

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "autostart"; Description: "Start at logon"; GroupDescription: "Autostart"; Flags: unchecked

[Files]
Source: "..\dist-win\vrc-hotkey-osc.exe"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\vrc-hotkey-osc.exe"
Name: "{group}\Uninstall {#AppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#AppName}"; Filename: "{app}\vrc-hotkey-osc.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\vrc-hotkey-osc.exe"; Description: "{cm:LaunchProgram,{#AppName}}"; Flags: nowait postinstall skipifsilent

[Registry]
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "VRChat OSC Hotkey"; ValueData: """{app}\vrc-hotkey-osc.exe"""; Tasks: autostart

[UninstallDelete]
Type: filesandordirs; Name: "{userappdata}\vrc-hotkey-osc"
