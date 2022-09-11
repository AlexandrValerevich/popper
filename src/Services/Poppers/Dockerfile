FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything from src
COPY . ./
# Restore as distinct layers
RUN dotnet restore ./Poppers/Poppers.Api/Poppers.Api.csproj
# Build and publish a release
RUN dotnet publish -c Release -o out ./Poppers/Poppers.sln

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "Poppers.Api.dll"]