#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Sleipnir.Api/Sleipnir.Api.csproj", "Sleipnir.Api/"]
COPY ["Sleipnir.Dtos/Sleipnir.Dtos.csproj", "Sleipnir.Dtos/"]
RUN dotnet restore "Sleipnir.Api/Sleipnir.Api.csproj"
COPY . .
WORKDIR "/src/Sleipnir.Api"
RUN dotnet build "Sleipnir.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sleipnir.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sleipnir.Api.dll"]