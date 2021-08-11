FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MigrationHelper/MigrationHelper.csproj", "MigrationHelper/"]
RUN dotnet restore "MigrationHelper/MigrationHelper.csproj"
COPY . .
WORKDIR "/src/MigrationHelper"
RUN dotnet build "MigrationHelper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MigrationHelper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MigrationHelper.dll"]
