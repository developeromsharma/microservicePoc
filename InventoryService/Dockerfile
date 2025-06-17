# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY InventoryService.API/InventoryService.API.csproj ./InventoryService.API/
RUN dotnet restore ./InventoryService.API/InventoryService.API.csproj

# Copy all files
COPY . .

# Build the project
WORKDIR /app/InventoryService.API
RUN dotnet publish -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Expose the port (if you use 5092 in launchSettings.json)
EXPOSE 5281

ENTRYPOINT ["dotnet", "InventoryService.API.dll"]
