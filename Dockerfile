FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /build
COPY GreetingApi/ GreetingApi/
WORKDIR /build/GreetingApi
RUN dotnet restore GreetingApi.csproj && \
    dotnet build -c Release --no-restore && \
    dotnet publish -c Release --no-build -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://*:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "GreetingApi.dll"]