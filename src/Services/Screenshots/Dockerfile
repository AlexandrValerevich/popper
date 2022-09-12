FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything from src
COPY ./Screenshots ./Screenshots
COPY ./Shared ./Shared
# Restore as distinct layers
RUN dotnet restore ./Screenshots/Screenshots.Api/Screenshots.Api.csproj
# Build and publish a release
RUN dotnet publish -c Release -o out ./Screenshots/Screenshots.sln

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80

ENTRYPOINT ["dotnet", "Screenshots.Api.dll"]