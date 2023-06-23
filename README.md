# TMA API

Task Manager App API (TMA API) is a web application that allows the processing and handling of TMA's SPA (Single-page application) data, with read/write operations to a SQL database.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to install the software and how to install them.

- [.NET 7.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

- [Microsoft® SQL Server® 2019](https://www.microsoft.com/en-us/download/details.aspx?id=101064)

- [Azure Data Studio](https://azure.microsoft.com/pt-br/products/data-studio)

- [Postman](https://www.postman.com/downloads/)

- [(Optional) Visual Studio 2022](https://visualstudio.microsoft.com/en-us/vs/)

- [(Optional) Docker](https://www.docker.com/products/docker-desktop)

## Running

### Backend (.NET) application

Edit appsettings.Development.json and enter your connection string or set your Environment.

For running the Api you must go to `src/TaskManagerApp.API` and run:

```powershell
dotnet run
```

OR run the `TaskManagerApp.API` profile in VS 2022

### Endpoints & Postman Setup

To test the endpoints of the API, import the Postman collection located in `docs/postman` for reference

The collection's requests have dummy data to test the endpoints, the only necessary config is to make sure you have a SQL database instance with the same name as the one in the connection string in `appsettings.Development.json`, and that you have set the collection's Authorization to `Type: Bearer Token` and `Token: {a JWT token generated from the POST /api/Auth/login endpoint}`

You can check if a token is valid by debugging it in [jwt.io](https://jwt.io/)

Here's a valid token for reference and testing purposes:

```json
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1hdGhldXMiLCJlbWFpbCI6Im1AbS5jb20iLCJVc2VySWQiOiIyIiwicm9sZSI6IkFETUlOIiwibmJmIjoxNjg3NDU0OTUxLCJleHAiOjE2OTAwNDY5NTEsImlhdCI6MTY4NzQ1NDk1MX0.grG3OYNUCuNb6EPm7ugE-bL0pWIMPfwW8KxYgZQymWs
```

Decoded:

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

### Database

To create a database from the existing migrations, run the following command:

```powershell
dotnet ef database update
```

OR run the `Update-Database` command in VS 2022 Package Manager Console

### (Optional) Docker Compose

To create container instances of the SQL server and the API, first check that you correctly set up a `.env` file at the root of the project, with the same variables as the `.env.example` file.

Then, run the following command:

```powershell
docker-compose up --build -d
```

You can test if the container instances are up, and if the database is correctly created, by calling the GET `/health` endpoint of the API

## Architecture

The backend application is a REST API built with .NET 7.0. Following the Clean Architecture principles, the application is divided into 4 layers:

### Presentation

The Presentation/API layer is the entry point of the application. It is responsible for receiving the requests and sending the responses to the client. It is also responsible for the authentication and authorization of the requests.

### Application

The Application layer is responsible for the application's business rules. It is responsible for the communication between the API and the Domain layer.

### Domain

The Domain layer is the core of the application. It is responsible for the entities of the application and their validations.

### Infrastructure

The Infrastructure layer is responsible for the communication with the database, it uses Entity Framework Core as the ORM to perform the operations in the database.

## Built With

- [.NET 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://fluentvalidation.net/)

## Formatting

The solution's formatter is [CSharpier](https://csharpier.com/docs/About), to format the code, run the following command:

```powershell
dotnet csharpier .
```

## Unit Tests

Unit tests for utility classes are located in tests/TaskManagerApp.Tests.Unit

You can run them via the VS 2022 Test Explorer

## E2E Tests

E2E tests are located in tests/TaskManagerApp.Tests.E2E, they were built with [Selenium WebDriver](https://www.selenium.dev/documentation/webdriver/)

You can run them via the VS 2022 Test Explorer

## Contributing

Feel free to submit a pull request with any improvements you see fit, suggestions are also welcome!
