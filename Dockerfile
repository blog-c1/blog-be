FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env 
WORKDIR /source

# Copy everything
COPY . .
# Restore as distinct layers
RUN dotnet restore "./blog-be/blog-be.csproj" --disable-parallel
# Build and publish a release
RUN dotnet publish "./blog-be/blog-be.csproj" -c Release -o /app  --no-restore

# Build runtime image
# Serve stage 
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build-env /app ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "blog-be.dll"]