FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FinanceOperation.Api/FinanceOperation.Api.csproj", "FinanceOperation.Api/"]
COPY [Directory.Build.props] .
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