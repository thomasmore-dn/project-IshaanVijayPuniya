FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# ENV ASPNETCORE_URLS=http://localhost:8000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["aspnet/aspnet.csproj", "aspnet/"]
RUN dotnet restore "aspnet/aspnet.csproj"
COPY . .
WORKDIR "/src/aspnet"
RUN dotnet build "aspnet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aspnet.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN dotnet tool install -g Microsoft.dotnet-httprepl
RUN dotnet dev-certs https --trust
# The 2 Run I have added are for generating a tsl or https certificate because when I was running 
#my maui app it could not parse tls packet header

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aspnet.dll"]
