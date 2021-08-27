FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WizeGo.sln", "./"]
COPY ["WizeGo.APi/WizeGo.APi.csproj", "./WizeGo.APi/"]
COPY ["WizeGo.UnitTests/WizeGo.UnitTests.csproj", "./WizeGo.UnitTests/"]
RUN dotnet restore "WizeGo.sln"

COPY . .
WORKDIR /src
RUN dotnet build

FROM build AS testrunner
WORKDIR /src/WizeGo.UnitTests
CMD ["dotnet", "test", "--logger:trx"]

FROM build AS test
WORKDIR /src/WizeGo.UnitTests
RUN dotnet test --logger:trx

FROM build AS publish
WORKDIR /src
RUN dotnet publish "WizeGo.sln" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WizeGo.APi.dll"]