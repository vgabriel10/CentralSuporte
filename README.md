# 🔧 Automatização de Build e Instalador com GitHub Actions

Este projeto utiliza **GitHub Actions** para compilar a aplicação WPF em .NET 8 e gerar automaticamente um instalador `.exe` usando o **Inno Setup**, sempre que um `push` for feito na branch `master`.

---

## ⚙️ Pré-requisitos

- Aplicação WPF compilável via `msbuild`
- Script de instalação configurado (`instalador/setup.iss`)
- Estrutura de diretórios esperada:

![image](https://github.com/user-attachments/assets/e1b737ff-8252-4efb-8d71-92ffe2b7ccd7)
---

## 🛠️ Workflow GitHub Actions

O arquivo `.github/workflows/build.yml` define as etapas de automação:

```yaml
name: Build WPF + InnoSetup

on:
  push:
    branches:
      - master

jobs:
  build:
    runs-on: windows-latest

    steps:
      - name: Checkout código
        uses: actions/checkout@v4

      - name: Setup MSBuild
        uses: microsoft/setup-msbuild@v1.3

      - name: Instalar Inno Setup
        run: choco install innosetup --yes
        shell: powershell

      - name: Restaurar pacotes NuGet
        run: nuget restore CentralSuporte.sln

      - name: Build do projeto
        run: msbuild CentralSuporte.sln /p:Configuration=Release

      - name: Gerar instalador com Inno Setup
        run: |
          & "C:\Program Files (x86)\Inno Setup 6\ISCC.exe" "instalador\setup.iss"
        shell: powershell

      - name: Upload do instalador como artefato
        uses: actions/upload-artifact@v4
        with:
          name: Instalador
          path: instalador\Output\CentralSuporteSetup.exe
```
## 🧾 Exemplo de setup.iss
``` iss
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
📌 Importante: Use caminhos relativos, pois o GitHub Actions não reconhece caminhos absolutos da sua máquina local.

```

## 🚀 Como funciona
Faça um push na branch master.

O GitHub Actions inicia o processo de build.

Ao final, acesse a aba Actions → Workflow Run → Artifacts.

Faça o download do instalador gerado: CentralSuporteSetup.exe.
