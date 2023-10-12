
# Base image
From mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /app
EXPOSE 80 

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

#final image
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet","EngieTestCC.dll"]
