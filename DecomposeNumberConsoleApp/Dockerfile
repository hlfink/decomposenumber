FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app

COPY . ./
RUN dotnet publish -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
COPY --from=base /app/publish .

ENTRYPOINT ["dotnet", "DecomposeNumberConsoleApp.dll"]