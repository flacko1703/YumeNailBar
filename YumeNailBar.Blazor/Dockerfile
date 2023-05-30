FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["YumeNailBar.Blazor/YumeNailBar.Blazor.csproj", "YumeNailBar.Blazor/"]
RUN dotnet restore "YumeNailBar.Blazor/YumeNailBar.Blazor.csproj"
COPY . .
WORKDIR "/src/YumeNailBar.Blazor"
RUN dotnet build "YumeNailBar.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YumeNailBar.Blazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YumeNailBar.Blazor.dll"]
