# 📑 Sumário

- [Objetivo da aplicação](#objetivo-da-aplicação)
- [Como Rodar](#como-rodar)
- [Como gerar o instalador](#-automatização-de-build-e-instalador-com-github-actions)
- [Padrões utilizados](#padrões-utilizados)
- [Bibliotecas utilizadas](#-bibliotecas-utilizadas)

## 🎯 Objetivo da aplicação

A **Central de Suporte** é uma aplicação desktop desenvolvida em **WPF** para o gerenciamento de atendimentos de chamados.  
Ela foi projetada para atender tanto os usuários que abrem chamados quanto a equipe de suporte responsável pela resolução, funcionando como uma ponte eficiente entre solicitante e atendente.  

Seu objetivo é simplificar o processo de comunicação, acompanhamento e conclusão de chamados, garantindo maior agilidade e organização no suporte.

## ▶️ Como Rodar

Para executar a aplicação, é recomendado utilizar o **Visual Studio 2022** e o **Docker**.  

1. Certifique-se de que o **Docker Desktop** esteja instalado e em execução.  
2. Acesse o diretório raiz da aplicação pelo terminal.  
3. Rode o comando abaixo para instanciar o **MongoDB** localmente:  

```bash
docker-compose up
```

## 🛠️ Padrões utilizados

A aplicação segue padrões e boas práticas para organizar o código e facilitar a manutenção:

- **MVVM**: Separação entre interface, lógica de apresentação e dados.  
- **Services**: Contém a lógica de negócio da aplicação.  
- **Repository**: Responsável pelo acesso e manipulação dos dados no banco.  
- **Validator**: Valida os dados antes de serem processados ou persistidos.   

### Bibliotecas utilizadas

- **Microsoft.Xaml.Behaviors.Wpf**: Permite criar **Behaviors** reutilizáveis para a interface WPF.  
- **MongoDB.Driver**: Driver oficial do MongoDB para .NET, usado para comunicação com o banco.  
- **WPF-UI**: Biblioteca para melhorar a aparência da interface do usuário, proporcionando componentes e estilos prontos para WPF.



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
