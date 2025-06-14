[Setup]
AppName=CentralSuporte
AppVersion=1.0
DefaultDirName={pf}\CentralSuporte
DefaultGroupName=CentralSuporte
OutputDir=.\Output
OutputBaseFilename=CentralSuporteSetup
Compression=lzma
SolidCompression=yes

[Files]
Source: "..\CentralSuporte\bin\Release\net8.0-windows\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs
