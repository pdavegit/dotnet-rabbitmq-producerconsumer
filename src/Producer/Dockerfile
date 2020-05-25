FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["Producer/Producer.csproj", "Producer/"]
COPY ["Consumer/Consumer.csproj", "Consumer/"]

RUN dotnet restore Producer/Producer.csproj
COPY . .
WORKDIR "/src/Producer"
RUN dotnet build  --no-restore -c $BUILD_CONFIGURATION -o out
RUN dotnet publish --no-restore -c $BUILD_CONFIGURATION -o out

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 
WORKDIR /app
COPY --from=build /src/Producer/out .
ENTRYPOINT [ "dotnet", "Producer.dll" ]

