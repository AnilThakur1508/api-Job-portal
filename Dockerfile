# ---------- Build Stage ------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the .csproj and restore
COPY JobPortal/JobPortal.csproj ./JobPortal/
RUN dotnet restore ./JobPortal/JobPortal.csproj

# Copy the rest of the code
COPY JobPortal/ ./JobPortal/
WORKDIR /src/JobPortal

# Build and publish
RUN dotnet publish -c Release -o /app/publish --no-restore

# ---------- Runtime Stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published output
COPY --from=build /app/publish .

EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "JobPortal.dll"]
