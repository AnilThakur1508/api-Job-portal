# ---------- Build Stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the .csproj and restore dependencies
COPY JobPortal/JobPortal.csproj ./JobPortal/
RUN dotnet restore ./JobPortal/JobPortal.csproj

# Copy the rest of the application
COPY JobPortal/ ./JobPortal/
WORKDIR /src/JobPortal

# Publish the application
RUN dotnet publish -c Release -o /app/publish --no-restore

# ---------- Runtime Stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published output
COPY --from=build /app/publish .

# Expose the port expected by Render or cloud provider
EXPOSE 80

# Set the environment variable for ASP.NET Core to listen on port 80
ENV ASPNETCORE_URLS=http://+:80

# Optional: Set environment for Production
ENV DOTNET_ENVIRONMENT=Production

# Optional: Use a non-root user for security (commented out if not preconfigured)
# RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
# USER appuser

# Start the application
ENTRYPOINT ["dotnet", "JobPortal.dll"]
