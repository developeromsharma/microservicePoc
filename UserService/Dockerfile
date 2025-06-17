# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY UserService.API/UserService.API.csproj ./UserService.API/
RUN dotnet restore ./UserService.API/UserService.API.csproj

# Copy all files
COPY . .

# Build the project
WORKDIR /app/UserService.API
RUN dotnet publish -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Expose the port (if you use 5092 in launchSettings.json)
EXPOSE 5092

ENTRYPOINT ["dotnet", "UserService.API.dll"]
