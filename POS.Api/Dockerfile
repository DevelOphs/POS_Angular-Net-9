# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["POS.Api/POS.Api.csproj", "POS.Api/"]
COPY ["POS.Application/POS.Application.csproj", "POS.Application/"]
COPY ["POS.Domain/POS.Domain.csproj", "POS.Domain/"]
COPY ["POS.Infrastructure/POS.Infrastructure.csproj", "POS.Infrastructure/"]
COPY ["POS.Utilities/POS.Utilities.csproj", "POS.Utilities/"]
RUN dotnet restore "./POS.Api/POS.Api.csproj"
COPY . .
WORKDIR "/src/POS.Api"
RUN dotnet build "./POS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./POS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN ln -fs /usr/share/zoneinfo/America/Guayaquil /etc/localtime
RUN dpkg-reconfigure --frontend noninteractive tzdata

ENTRYPOINT ["dotnet", "POS.Api.dll"]
