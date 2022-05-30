#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ClaySmartLockSolution.API/ClaySmartLockSolution.API.csproj", "ClaySmartLockSolution.API/"]
COPY ["ClaySmartLockSolution.Core/ClaySmartLockSolution.Core.csproj", "ClaySmartLockSolution.Core/"]
COPY ["ClaySmartLockSolution.Application/ClaySmartLockSolution.Application.csproj", "ClaySmartLockSolution.Application/"]
COPY ["ClaySmartLockSolution.Infrastructure/ClaySmartLockSolution.Infrastructure.csproj", "ClaySmartLockSolution.Infrastructure/"]
RUN dotnet restore "ClaySmartLockSolution.API/ClaySmartLockSolution.API.csproj"
COPY . .
WORKDIR "/src/ClaySmartLockSolution.API"
RUN dotnet build "ClaySmartLockSolution.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClaySmartLockSolution.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClaySmartLockSolution.API.dll"]