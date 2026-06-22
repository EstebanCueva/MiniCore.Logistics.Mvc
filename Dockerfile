FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY MiniCore.Logistics.Mvc.csproj ./
RUN dotnet restore MiniCore.Logistics.Mvc.csproj

COPY . ./
RUN dotnet publish MiniCore.Logistics.Mvc.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "MiniCore.Logistics.Mvc.dll"]
