FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build

WORKDIR /src
COPY ./src .

RUN dotnet restore Timely.Api/Timely.Api.csproj
RUN dotnet build --configuration Release --no-restore Timely.Api/Timely.Api.csproj
RUN dotnet publish --configuration Release --no-build Timely.Api/Timely.Api.csproj --output /publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS runtime

WORKDIR /app
COPY --from=build /publish .

EXPOSE 8080

ENTRYPOINT [ "dotnet", "Timely.Api.dll" ]
