FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EasyTracker.API/EasyTracker.API.csproj", "EasyTracker.API/"]
COPY ["EasyTracker.BLL/EasyTracker.BLL.csproj", "EasyTracker.BLL/"]
COPY ["EasyTracker.DAL/EasyTracker.DAL.csproj", "EasyTracker.DAL/"]
RUN dotnet restore "EasyTracker.API/EasyTracker.API.csproj"
COPY . .
WORKDIR "/src/EasyTracker.API"
RUN dotnet build "EasyTracker.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyTracker.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyTracker.API.dll"]
