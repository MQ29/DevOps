# Etap bazowy (runtime environment)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etap budowania (build environment)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiowanie pliku projektu i przywracanie zale¿noœci
COPY ["ApkaNowa.csproj", "./"]
RUN dotnet restore "./ApkaNowa.csproj"

# Kopiowanie pozosta³ych plików projektu i budowanie aplikacji
COPY . .
WORKDIR "/src"
RUN dotnet publish "./ApkaNowa.csproj" -c Release -o /app/publish

# Etap koñcowy (final image)
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ApkaNowa.dll"]
