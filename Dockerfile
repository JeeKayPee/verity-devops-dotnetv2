#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["sample-ui-pipeline-v1/sample-ui-pipeline-v1.csproj", "sample-ui-pipeline-v1/"]
RUN dotnet restore "sample-ui-pipeline-v1/sample-ui-pipeline-v1.csproj"
COPY . .
WORKDIR "/src/sample-ui-pipeline-v1"
RUN dotnet build "sample-ui-pipeline-v1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "sample-ui-pipeline-v1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "sample-ui-pipeline-v1.dll"]