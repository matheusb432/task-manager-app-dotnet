# TMA API

A API do Task Manager App (TMA API) é uma aplicação web que permite o processamento e manipulação de dados do TMA SPA (aplicação de página única), com operações de leitura/gravação em um banco de dados SQL.

## Iniciando

Estas instruções ajudarão você a ter uma cópia do projeto em execução na sua máquina local para fins de desenvolvimento e teste.

### Pré-requisitos

O que você precisa para instalar o software e como instalá-los.

- [.NET 7.0 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0)

- [Microsoft® SQL Server® 2019](https://www.microsoft.com/pt-br/download/details.aspx?id=101064)

- [Azure Data Studio](https://azure.microsoft.com/pt-br/products/data-studio)

- [Postman](https://www.postman.com/downloads/)

- [(Opcional) Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/)

- [(Opcional) Docker](https://www.docker.com/products/docker-desktop)

## Executando

### Aplicação Backend (.NET)

Edite o arquivo appsettings.Development.json e insira sua string de conexão ou configure seu Ambiente.

Para executar a API, vá até `src/TaskManagerApp.API` e execute:

```powershell
dotnet run
```

OU execute o perfil `TaskManagerApp.API` no VS 2022

### Endpoints & Configuração do Postman

Para testar os endpoints da API, importe a coleção do Postman localizada em docs/postman para referência.

As requisições da coleção têm dados fictícios para testar os endpoints. A única configuração necessária é garantir que você tenha uma instância de banco de dados SQL com o mesmo nome que o da string de conexão em appsettings.Development.json, e que você tenha configurado a autorização da coleção para Tipo: Bearer Token e Token: {um token JWT gerado a partir do endpoint POST /api/Auth/login}.

Você pode verificar se um token é válido, analisando-o em jwt.io.

Aqui está um token válido para referência e fins de teste:

```json

eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1hdGhldXMiLCJlbWFpbCI6Im1AbS5jb20iLCJVc2VySWQiOiIyIiwicm9sZSI6IkFETUlOIiwibmJmIjoxNjg3NDU0OTUxLCJleHAiOjE2OTAwNDY5NTEsImlhdCI6MTY4NzQ1NDk1MX0.grG3OYNUCuNb6EPm7ugE-bL0pWIMPfwW8KxYgZQymWs

```

Decodificado:

```json
{
  "unique_name": "matheus",
  "email": "m@m.com",
  "UserId": "2",
  "role": "ADMIN",
  "nbf": 1687454951,
  "exp": 1690046951,
  "iat": 1687454951
}
```

### Banco de Dados

Para criar um banco de dados a partir das migrações existentes, execute o seguinte comando:

```powershell
dotnet ef database update
```

OU execute o comando Update-Database no Console do Gerenciador de Pacotes do VS 2022.

### (Opcional) Docker Compose

Para criar instâncias de contêiner do servidor SQL e da API, primeiro verifique se você configurou corretamente um arquivo `.env` na raiz do projeto, com as mesmas variáveis do arquivo `.env.example`.

Em seguida, execute o seguinte comando:

```powershell
docker-compose up --build -d
```

Você pode testar se as instâncias do contêiner estão ativas e se o banco de dados foi criado corretamente, chamando o endpoint `GET /health` da API.

## Arquitetura

A aplicação backend é uma API REST construída com .NET 7.0. Seguindo os princípios da Arquitetura Limpa, a aplicação é dividida em 4 camadas:

### Apresentação

A camada de Apresentação/API é o ponto de entrada da aplicação. É responsável por receber as requisições e enviar as respostas para o cliente. Também é responsável pela autenticação e autorização das requisições.

### Aplicação

A camada de Aplicação é responsável pelas regras de negócio da aplicação. É responsável pela comunicação entre a API e a camada de Domínio.

### Domínio

A camada de Domínio é o núcleo da aplicação. É responsável pelas entidades da aplicação e suas validações.

### Infraestrutura

A camada de Infraestrutura é responsável pela comunicação com o banco de dados, utiliza o Entity Framework Core como ORM para realizar as operações no banco de dados.

## Construído com

- [.NET 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://fluentvalidation.net/)

## Formatação

O formatador da solução é o CSharpier, para formatar o código, execute o seguinte comando:

```powershell
dotnet csharpier .
```

## Testes Unitários

Testes unitários para classes utilitárias estão localizados em `tests/TaskManagerApp.Tests.Unit`.

Você pode executá-los através do Explorador de Testes do VS 2022.

## Testes E2E

Os testes E2E estão localizados em tests/TaskManagerApp.Tests.E2E, eles foram construídos com[Selenium WebDriver](https://www.selenium.dev/documentation/webdriver/)

Você pode executá-los através do Explorador de Testes do VS 2022.

## Contribuindo

Sinta-se à vontade para enviar um pull request com quaisquer melhorias que achar adequadas, sugestões também são bem-vindas!
