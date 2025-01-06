# Etap bazowy (runtime environment)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etap budowania (build environment)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Przywracanie zale¿noœci
COPY ["ApkaNowa.csproj", "./"]
RUN dotnet restore "./ApkaNowa.csproj"

# Kopiowanie kodu Ÿród³owego
COPY . . 

# Publikacja aplikacji
RUN dotnet publish "./ApkaNowa.csproj" -c Release -o /app/publish

# Etap koñcowy (runtime environment z SDK i narzêdziami)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

# Instalacja dotnet-ef CLI
RUN dotnet tool install --global dotnet-ef

# Dodanie œcie¿ki dla narzêdzi dotnet
ENV PATH="$PATH:/root/.dotnet/tools"

# Kopiowanie opublikowanej aplikacji z etapu build
COPY --from=build /app/publish .

# Uruchomienie aplikacji
ENTRYPOINT ["dotnet", "ApkaNowa.dll"]
