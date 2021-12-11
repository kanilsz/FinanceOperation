#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FinanceOperation.Api/FinanceOperation.Api.csproj", "FinanceOperation.Api/"]
COPY ["FinanceOperation.Infrastructure/FinanceOperation.Infrastructure.csproj", "FinanceOperation.Infrastructure/"]
COPY ["FinanceOperation.Core/FinanceOperation.Core.csproj", "FinanceOperation.Core/"]
COPY ["FinanceOperation.Domain/FinanceOperation.Domain.csproj", "FinanceOperation.Domain/"]
RUN dotnet restore "FinanceOperation.Api/FinanceOperation.Api.csproj"
COPY . .
WORKDIR "/src/FinanceOperation.Api"
RUN dotnet build "FinanceOperation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinanceOperation.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinanceOperation.Api.dll"]