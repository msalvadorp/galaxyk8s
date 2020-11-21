#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as base
WORKDIR /app
ENV ASPNETCORE_URLS="http://+:8090;http://+:8091"
ENV IdentityServer__UrlServer="DEMO"
EXPOSE 8090
EXPOSE 8091

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Sol.Demo.ApiOpBanca/Sol.Demo.ApiOpBanca.csproj", "Sol.Demo.ApiOpBanca/"]
COPY ["Sol.Demo.Comunes/Sol.Demo.Comunes.csproj", "Sol.Demo.Comunes/"]
RUN dotnet restore "Sol.Demo.ApiOpBanca/Sol.Demo.ApiOpBanca.csproj"
COPY . .
WORKDIR "/src/Sol.Demo.ApiOpBanca"
RUN dotnet build "Sol.Demo.ApiOpBanca.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sol.Demo.ApiOpBanca.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sol.Demo.ApiOpBanca.dll"]