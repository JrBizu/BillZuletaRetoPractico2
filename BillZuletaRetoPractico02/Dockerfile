FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
#COPY BillZuletaRetoPractico02.csproj .
COPY ["BillZuletaRetoPractico02.csproj", "BillZuletaRetoPractico02/"]
RUN dotnet restore "./BillZuletaRetoPractico02/BillZuletaRetoPractico02.csproj"
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "BillZuletaRetoPractico02.dll"]

#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#EXPOSE 8080
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["BillZuletaRetoPractico02.csproj", "BillZuletaRetoPractico02/"]
#RUN dotnet restore "./BillZuletaRetoPractico02/BillZuletaRetoPractico02.csproj"
#COPY . .
#WORKDIR "/src/BillZuletaRetoPractico02"
#RUN dotnet build "./BillZuletaRetoPractico02.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./BillZuletaRetoPractico02.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "BillZuletaRetoPractico02.dll"]