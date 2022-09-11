FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything from src
COPY . ./
# Restore as distinct layers
RUN dotnet restore ./GifFiles/GifFiles.Api/GifFiles.Api.csproj
# Build and publish a release
RUN dotnet publish -c Release -o out ./GifFiles/GifFiles.sln

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "GifFiles.Api.dll"]