; Inno Setup script for T1 Keyboard Config (Windows 11)
; Builds an installer with start-menu entry, optional logon autostart and
; a clean uninstaller.

#define AppName "T1 Keyboard Config"
#define AppVersion "1.1.0"
#define AppPublisher "drkai-lab"
#define AppURL "https://github.com/drkai-lab/t1-keyboard-config"

[Setup]
AppId={{B7E2C1A0-3F4D-4E5A-9B8C-1D2E3F4A5B6C}
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
OutputBaseFilename=t1-keyboard-config-{#AppVersion}-setup
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
UninstallDisplayIcon={app}\t1-keyboard-config-gui.exe
ArchitecturesInstallIn64BitMode=x64compatible

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "autostart"; Description: "Start at logon"; GroupDescription: "Autostart"; Flags: unchecked

[Files]
Source: "..\dist-win\t1-keyboard-config.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\dist-win\t1-keyboard-config-gui.exe"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\t1-keyboard-config-gui.exe"
Name: "{group}\Uninstall {#AppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#AppName}"; Filename: "{app}\t1-keyboard-config-gui.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\t1-keyboard-config-gui.exe"; Description: "{cm:LaunchProgram,{#AppName}}"; Flags: nowait postinstall skipifsilent

[Registry]
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "T1 Keyboard Config"; ValueData: """{app}\t1-keyboard-config-gui.exe"""; Tasks: autostart
