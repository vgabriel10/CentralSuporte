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
# Nome do workflow que aparecerá na aba "Actions" do GitHub
name: Build WPF + InnoSetup

# Define quando o workflow será acionado
on:
  push:
    branches:
      - master  # Só executa quando houver um push na branch "master"

jobs:
  build:  # Nome do job
    runs-on: windows-latest  # Executa em uma máquina virtual com o Windows mais recente

    steps:  # Etapas que serão executadas dentro do job

      # Etapa 1: Faz o checkout (download) do código-fonte do repositório
      - name: Checkout código
        uses: actions/checkout@v4

      # Etapa 2: Instala o MSBuild (usado para compilar projetos .NET/WPF)
      - name: Setup MSBuild
        uses: microsoft/setup-msbuild@v1.3

      # Etapa 3: Instala o Inno Setup usando o gerenciador de pacotes Chocolatey
      - name: Instalar Inno Setup
        run: choco install innosetup --yes  # --yes aceita automaticamente os termos
        shell: powershell  # Define o shell a ser usado como PowerShell

      # Etapa 4: Restaura os pacotes NuGet definidos no arquivo de solução (.sln)
      - name: Restaurar pacotes NuGet
        run: nuget restore CentralSuporte.sln

      # Etapa 5: Compila o projeto em modo Release usando o MSBuild
      - name: Build do projeto
        run: msbuild CentralSuporte.sln /p:Configuration=Release

      # Etapa 6: Gera o instalador executando o script do Inno Setup (setup.iss)
      - name: Gerar instalador com Inno Setup
        run: |
          & "C:\Program Files (x86)\Inno Setup 6\ISCC.exe" "instalador\setup.iss"
        shell: powershell  # Define que o comando será executado em PowerShell

      # Etapa 7: Faz upload do instalador gerado como artefato do workflow
      - name: Upload do instalador como artefato
        uses: actions/upload-artifact@v4
        with:
          name: Instalador  # Nome que aparecerá no GitHub Actions
          path: instalador\Output\CentralSuporteSetup.exe  # Caminho do arquivo a ser enviado

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
