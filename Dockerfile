# Usar a base correta do runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# Expor as portas usadas pela aplicação
EXPOSE 5100
EXPOSE 5101

ENV ASPNETCORE_HTTP_PORTS=5100
ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar apenas arquivos relevantes primeiro para otimizar cache
COPY ["renault.risk.manager.sln", "./"]
COPY ["renault.risk.manager.Api/renault.risk.manager.Api.csproj", "renault.risk.manager.Api/"]
COPY ["renault.risk.manager.Application/renault.risk.manager.Application.csproj", "renault.risk.manager.Application/"]
COPY ["renault.risk.manager.Domain/renault.risk.manager.Domain.csproj", "renault.risk.manager.Domain/"]
COPY ["renault.risk.manager.Infrastructure/renault.risk.manager.Infrastructure.csproj", "renault.risk.manager.Infrastructure/"]

# Restaurar dependências
RUN dotnet restore "renault.risk.manager.sln"

# Copiar todo o restante do código
COPY . .

# Compilar o código
WORKDIR "/src/renault.risk.manager.Api"
RUN dotnet build "renault.risk.manager.Api.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "renault.risk.manager.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Configurar a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "renault.risk.manager.Api.dll"]
