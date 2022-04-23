#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OSM-Web-Service/OSM-Web-Service.csproj", "OSM-Web-Service/"]
RUN dotnet restore "OSM-Web-Service/OSM-Web-Service.csproj"
COPY . .
WORKDIR "/src/OSM-Web-Service"
RUN dotnet build "OSM-Web-Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OSM-Web-Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OSM-Web-Service.dll"]