#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["Az204.WebApi/Az204.WebApi.csproj", "Az204.WebApi/"]
RUN dotnet restore "Az204.WebApi/Az204.WebApi.csproj"
COPY . .
WORKDIR "/src/Az204.WebApi"
RUN dotnet build "Az204.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Az204.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Az204.WebApi.dll"]