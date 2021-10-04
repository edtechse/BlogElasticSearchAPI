#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
  
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

ARG SONAR_PROJECT_KEY=blog-elasticsearch
ARG SONAR_OGRANIZAION_KEY=edtechproject
ARG SONAR_HOST_URL=https://sonarcloud.io
ARG SONAR_TOKEN=863ffca8fba735527dfd85c37598e4d5a14c61d8

WORKDIR /src

RUN apt-get update && apt-get install -y openjdk-11-jdk
RUN dotnet tool install --global dotnet-sonarscanner
RUN dotnet tool install --global coverlet.console --version 1.7.2 
ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet sonarscanner begin \
  /k:"$SONAR_PROJECT_KEY" \
  /o:"$SONAR_OGRANIZAION_KEY" \
  /d:sonar.host.url="$SONAR_HOST_URL" \
  /d:sonar.login="$SONAR_TOKEN" \
  /d:sonar.cs.opencover.reportsPaths=/coverage.opencover.xml
  
COPY ["BlogElasticSearchService.csproj", ""]
RUN dotnet restore "./BlogElasticSearchService.csproj"
COPY . .
WORKDIR "/src/."

FROM build AS publish
RUN dotnet publish "BlogElasticSearchService.csproj" -c Release -o /app/publish

RUN dotnet sonarscanner end /d:sonar.login=863ffca8fba735527dfd85c37598e4d5a14c61d8

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogElasticSearchService.dll"]
