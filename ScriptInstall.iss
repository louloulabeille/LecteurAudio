; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "AudioLoulou"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Loulou Compagny"
#define MyAppExeName "LecteurAudio.exe"
#define MyAppAssocName MyAppName + ""
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{311137D0-9226-48FF-A3A5-BA0E82F4DE55}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
OutputBaseFilename=mysetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\louloulabeille\source\repos\LecteurAudio\LecteurAudio\bin\Release\net7.0-windows\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\louloulabeille\source\repos\LecteurAudio\LecteurAudio\bin\Release\net7.0-windows\GestionProcess.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\louloulabeille\source\repos\LecteurAudio\LecteurAudio\bin\Release\net7.0-windows\GestionProcess.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\louloulabeille\source\repos\LecteurAudio\LecteurAudio\bin\Release\net7.0-windows\LecteurAudio.deps.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\louloulabeille\source\repos\LecteurAudio\LecteurAudio\bin\Release\net7.0-windows\LecteurAudio.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\louloulabeille\source\repos\LecteurAudio\LecteurAudio\bin\Release\net7.0-windows\LecteurAudio.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\louloulabeille\source\repos\LecteurAudio\LecteurAudio\bin\Release\net7.0-windows\LecteurAudio.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\louloulabeille\source\repos\LecteurAudio\LecteurAudio\bin\Release\net7.0-windows\MaterialDesignColors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\louloulabeille\source\repos\LecteurAudio\LecteurAudio\bin\Release\net7.0-windows\MaterialDesignThemes.Wpf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\louloulabeille\source\repos\LecteurAudio\LecteurAudio\bin\Release\net7.0-windows\Microsoft.Xaml.Behaviors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\louloulabeille\source\repos\LecteurAudio\LecteurAudio\bin\Release\net7.0-windows\MusiqueBOL.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\louloulabeille\source\repos\LecteurAudio\LecteurAudio\bin\Release\net7.0-windows\MusiqueBOL.pdb"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

