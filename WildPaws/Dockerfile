#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["WildPaws/WildPaws.csproj", "WildPaws/"]
#COPY ["WildPaws.Core/WildPaws.Core.csproj", "WildPaws.Core/"]
#COPY ["WildPaws.Infrastructure/WildPaws.Infrastructure.csproj", "WildPaws.Infrastructure/"]
#RUN dotnet restore "WildPaws/WildPaws.csproj"
#COPY . ./
#WORKDIR "/src/WildPaws"
#RUN dotnet build "WildPaws.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "WildPaws.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#
#COPY ./entrypoint.sh ./entrypoint.sh 
#RUN chmod +x ./entrypoint.sh
#ENTRYPOINT ["/bin/bash", "./entrypoint.sh"]