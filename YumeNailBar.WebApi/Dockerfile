FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["YumeNailBar.WebApi/YumeNailBar.WebApi.csproj", "YumeNailBar.WebApi/"]
COPY ["YumeNailBar.Application/YumeNailBar.Application.csproj", "YumeNailBar.Application/"]
COPY ["YumeNailBar.Domain/YumeNailBar.Domain.csproj", "YumeNailBar.Domain/"]
COPY ["YumeNailBar.Infrastructure/YumeNailBar.Infrastructure.csproj", "YumeNailBar.Infrastructure/"]
RUN dotnet restore "YumeNailBar.WebApi/YumeNailBar.WebApi.csproj"
COPY . .
WORKDIR "/src/YumeNailBar.WebApi"
RUN dotnet build "YumeNailBar.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YumeNailBar.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YumeNailBar.WebApi.dll"]
