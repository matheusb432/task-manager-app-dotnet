# TMA API

Task Manager App API (TMA API) is a web application that allows the processing and handling of TMA's SPA data, with read/write operations to a remote database.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to install the software and how to install them.

- [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

- [Microsoft® SQL Server® 2019](https://www.microsoft.com/en-us/download/details.aspx?id=101064)

- [Azure Data Studio](https://azure.microsoft.com/pt-br/products/data-studio)

- [Visual Studio 2022](https://visualstudio.microsoft.com/en-us/vs/)

## Running

### Backend (.NET) application

Edit appsettings.Development.json and enter your connection string or set your Environment.

For running the Api you must go to `src/TaskManagerApp.API` and run:

```powershell
dotnet run
```

OR simply run the `TaskManagerApp.API` profile in VS 2022

## Architecture

The backend application is a REST API built with .NET 6.0. Following the Clean Architecture principles, the application is divided into 4 layers:

- **Presentation**: The Presentation/API layer is the entry point of the application. It is responsible for receiving the requests and sending the responses to the client. It is also responsible for the authentication and authorization of the requests.

- **Application**: The Application layer is responsible for the application's business rules. It is responsible for the communication between the API and the Domain layer.

- **Domain**: The Domain layer is the core of the application. It is responsible for the entities of the application and their validations.

- **Infrastructure**: The Infrastructure layer is responsible for the communication with the database, it uses Entity Framework Core as the ORM to perform the operations in the database.

### Built With

- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://fluentvalidation.net/)

## Formatting

The solution's formatter is [CSharpier](https://csharpier.com/docs/About), to format the code, run the following command:

```powershell
dotnet csharpier .
```
