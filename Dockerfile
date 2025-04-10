# Use the official .NET 8 SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the .csproj file and restore the dependencies (via nuget)
COPY vlm.csproj .
RUN dotnet restore vlm.csproj

# Copy the rest of the application code
COPY . .

# Build the application
RUN dotnet build vlm.csproj -c Release -o /app/build

# Publish the application
RUN dotnet publish vlm.csproj -c Release -o /app/publish

# Use the official .NET 8 runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory
WORKDIR /app

# Copy the published app from the build container
COPY --from=build /app/publish .

# Expose the port the app will run on
EXPOSE 80

# Set the entry point to the app
ENTRYPOINT ["dotnet", "vlm.dll"]
