#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Users.API/Users.API.csproj", "Users.API/"]
COPY ["Common/Common.csproj", "Common/"]
RUN dotnet restore "Users.API/Users.API.csproj"
COPY . .
WORKDIR "/src/Users.API"
RUN dotnet build "Users.API.csproj" -c Development -o /app/build

FROM build AS publish
RUN dotnet publish "Users.API.csproj" -c Development -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Users.API.dll"]