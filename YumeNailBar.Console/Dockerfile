FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["YumeNailBar.Console/YumeNailBar.Console.csproj", "YumeNailBar.Console/"]
RUN dotnet restore "YumeNailBar.Console/YumeNailBar.Console.csproj"
COPY . .
WORKDIR "/src/YumeNailBar.Console"
RUN dotnet build "YumeNailBar.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YumeNailBar.Console.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YumeNailBar.Console.dll"]
