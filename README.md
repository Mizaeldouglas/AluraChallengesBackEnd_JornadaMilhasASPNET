Jornada Milhas API
===

Projeto de uma API REST completa para gerenciamento de uma loja de roupas, incluindo:

- **Depoimentos:** CRUD completo (Criação, Leitura, Atualização e Exclusão) e tambem mostrar os 3 ultimos depoimentos.



## Screenshots

![Captura de Tela 2024-04-08 às 21 40 22](https://github.com/Mizaeldouglas/AluraChallengesBackEnd_JornadaMilhasASPNET/assets/89351018/42bf5459-e879-4a03-bb3c-5b3db404e7b4)


## Stack utilizada

- **C# .NET 7.0:** Linguagem de programação moderna e robusta.
- **Entity Framework Core:** Framework de mapeamento objeto-relacional para acesso a bancos de dados.
- **SQL Server:** Banco de dados relacional confiável e escalável.
- **Swagger:** Ferramenta para documentação e teste da API.

**Pacotes NuGet:**

- **Microsoft.EntityFrameworkCore:** Framework Entity Framework Core.
- **Microsoft.EntityFrameworkCore.SqlServer:** Provedor Entity Framework para SQL Server.

## Exemplo de Estrutura da API

```c#
    http://localhost:{host}
        /depoimentos        // Get All
        /depoimentos/{id}   // Get By Id
        /depoimentos        // Post
        /depoimentos/{id}   // Put
        /depoimentos/{id}   // Delete
        /depoimentos-home   // Get Last 3 Testimonial
            
    http://localhost:{host}
        /destinos        // Get All
        /destinos/{id}   // Get By Id
        /destinos        // Post
        /destinos/{id}   // Put
        /destinos/{id}   // Delete
        /destinos/search?name={name} // Get by name ("destinos/search?name=limeira")
```


## Instalação
- Certifique-se de ter o .NET SDK instalado em sua máquina. Você pode baixar o SDK em https://dotnet.microsoft.com/download.

- A versão do .NET que esta nesse Projeto é o .NET 7.0

- O comando específico para instalar o .NET 7.0 pelo terminal depende do sistema operacional que você está usando.

### No Windows:
- Com PowerShell:
```bash
  Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
  Install-Module dotnet
  Import-Module dotnet
  Install-Package dotnet-sdk-7.0
  ```
- Com Prompt de Comando:

```bash  
dotnet-install.ps1 -InstallSDK 7.0
```
### No macOS:
```bash  
brew install dotnet/core/dotnet-sdk7
```
### No Linux:

- Com Ubuntu:
```bash  
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install dotnet-sdk-7.0
```
- Com outras distros:
- Consulte a documentação do .NET para obter instruções específicas para sua distro: https://docs.microsoft.com/pt-br/dotnet/core/install/linux.

### Observações:

- Certifique-se de ter um gerenciador de pacotes instalado em sua máquina.
- O comando dotnet-install.ps1 só está disponível no Windows.
- O comando brew só está disponível no macOS.
- Os comandos para Linux podem variar dependendo da sua distro.

### Clonar o repositorio
```bash
git clone https://github.com/Mizaeldouglas/JornadaMilhas-aluraChallengeBackend-DotNet7.git
cd JornadaMilhas-aluraChallengeBackend-DotNet7
```

### Instalação do Entity Framework Core via NuGet:

Adicione a seguinte seção após a etapa de clonar o repositório:

- Instalar o Entity Framework
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
- Observação: Se você instalou o EF Core globalmente (```dotnet tool install --global dotnet-ef```),poderá usar comandos do EF Core diretamente na linha de comando.


### Iniciar o projeto na sua maquina

```bash
  dotnet restore
  dotnet build
  dotnet run
```
