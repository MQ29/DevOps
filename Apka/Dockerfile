FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Apka.csproj", "./"]
RUN dotnet restore "./Apka.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Apka.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Apka.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Apka.dll"]