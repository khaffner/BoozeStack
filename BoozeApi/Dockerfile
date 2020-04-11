# Build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
COPY . /src
WORKDIR /src
RUN dotnet restore
RUN dotnet publish -c Release -o /release

# Install
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=builder /release /app
COPY --from=builder /src/Entrypoint.sh /app
RUN chmod +x /app/Entrypoint.sh

# Config
EXPOSE 80

# Run
ENTRYPOINT /app/Entrypoint.sh