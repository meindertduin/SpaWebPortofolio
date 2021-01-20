FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["./SpaWebPortofolio.csproj", "app/"]
RUN dotnet restore "app/SpaWebPortofolio.csproj"
COPY . .
RUN dotnet build "/src/SpaWebPortofolio.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/SpaWebPortofolio.csproj" -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaWebPortofolio.dll"]