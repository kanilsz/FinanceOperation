FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["FinanceOperation.BlazorWebAssembly/FinanceOperation.BlazorWebAssembly.csproj", "FinanceOperation.BlazorWebAssembly/"]
RUN dotnet restore "FinanceOperation.BlazorWebAssembly/FinanceOperation.BlazorWebAssembly.csproj"
COPY . .
WORKDIR "/src/FinanceOperation.BlazorWebAssembly"

COPY . .
RUN dotnet build "FinanceOperation.BlazorWebAssembly/FinanceOperation.BlazorWebAssembly.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinanceOperation.BlazorWebAssembly/FinanceOperation.BlazorWebAssembly.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY "FinanceOperation.BlazorWebAssembly/nginx.conf" /etc/nginx/nginx.conf