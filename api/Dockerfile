# Use the official .NET 6 SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /app

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Set the ASPNETCORE_URLS environment variable to listen on port 80
EXPOSE 80
ENTRYPOINT ["dotnet", "api.dll"]