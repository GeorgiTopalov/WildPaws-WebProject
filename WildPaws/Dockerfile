#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WildPaws/WildPaws.csproj", "WildPaws/"]
COPY ["WildPaws.Core/WildPaws.Core.csproj", "WildPaws.Core/"]
COPY ["WildPaws.Infrastructure/WildPaws.Infrastructure.csproj", "WildPaws.Infrastructure/"]
RUN dotnet restore "WildPaws/WildPaws.csproj"
COPY . .
WORKDIR "/src/WildPaws"
RUN dotnet build "WildPaws.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WildPaws.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WildPaws.dll"]