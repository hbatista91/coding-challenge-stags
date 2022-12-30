#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DevicesProject.API/DevicesProject.API.csproj", "DevicesProject.API/"]
RUN dotnet restore "DevicesProject.API/DevicesProject.API.csproj"
COPY . .
WORKDIR "/src/DevicesProject.API"
RUN dotnet build "DevicesProject.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevicesProject.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevicesProject.API.dll"]