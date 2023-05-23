#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TaskManagerApp.API/TaskManagerApp.API.csproj", "src/TaskManagerApp.API/"]
COPY ["src/TaskManagerApp.Application/TaskManagerApp.Application.csproj", "src/TaskManagerApp.Application/"]
COPY ["src/TaskManagerApp.Domain/TaskManagerApp.Domain.csproj", "src/TaskManagerApp.Domain/"]
COPY ["src/TaskManagerApp.Infra/TaskManagerApp.Infra.csproj", "src/TaskManagerApp.Infra/"]
RUN dotnet restore "src/TaskManagerApp.API/TaskManagerApp.API.csproj"
COPY . .
WORKDIR "/src/src/TaskManagerApp.API"
RUN dotnet build "TaskManagerApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManagerApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagerApp.API.dll"]