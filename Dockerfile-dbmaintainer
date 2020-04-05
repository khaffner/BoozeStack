FROM mcr.microsoft.com/powershell:lts-alpine-3.10

COPY UpdateDB.ps1 /src/

ENTRYPOINT [ "pwsh", "-File" , "/src/UpdateDB.ps1" ]