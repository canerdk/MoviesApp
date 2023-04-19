#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Movie/Movie.Api/Movie.Api.csproj", "src/Services/Movie/Movie.Api/"]
COPY ["src/Services/Movie/Movie.Business/Movie.Business.csproj", "src/Services/Movie/Movie.Business/"]
COPY ["src/Services/Movie/Movie.DataAccess/Movie.DataAccess.csproj", "src/Services/Movie/Movie.DataAccess/"]
COPY ["src/Services/Movie/Movie.Entities/Movie.Entities.csproj", "src/Services/Movie/Movie.Entities/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.csproj", "src/BuildingBlocks/EventBus/"]
RUN dotnet restore "src/Services/Movie/Movie.Api/Movie.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Movie/Movie.Api"
RUN dotnet build "Movie.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Movie.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Movie.Api.dll"]