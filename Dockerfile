# Build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
COPY . /src
WORKDIR /src
RUN dotnet restore
RUN dotnet publish -c Release -o /release

# Install
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=builder /release /app
WORKDIR /app

# Config
EXPOSE 80

# Run
ENTRYPOINT dotnet BoozeApi.dll