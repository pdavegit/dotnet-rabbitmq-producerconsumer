FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /src

COPY ["Producer/Producer.csproj", "Producer/"]
COPY ["Consumer/Consumer.csproj", "Consumer/"]

RUN dotnet restore Consumer/Consumer.csproj
COPY . .
WORKDIR "/src/Consumer"
RUN dotnet publish  --no-restore -c $BUILD_CONFIGURATION -o out

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 
WORKDIR /app
COPY --from=build /src/Consumer/out .

ENTRYPOINT [ "dotnet", "Consumer.dll" ]
