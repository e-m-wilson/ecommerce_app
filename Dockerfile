# --- Stage 1: Build and Publish ---   

# we need to install the SDK in the container
FROM mcr.Microsoft.com/dotnet/sdk:9.0 AS build 
WORKDIR /src 

# copy the csproj files/sln and restore dependencies 

COPY ecommerce_backend.sln ./
COPY ../main.API/main.API.csproj main.API/
COPY ../main.Domain/main.Domain.csproj main.Domain/
COPY ../main.Service/main.Service.csproj main.Service/
COPY ../main.Repository/main.Repository.csproj main.Repository/
RUN dotnet restore

# copy everything else and then build/publish 
COPY . .
RUN dotnet publish main.API/main.API.csproj -c Release -o /app/publish 

# --- Stage 2: building a runtime image ---
FROM mcr.Microsoft.com/dotnet/aspnet:9.0 AS runtime 
WORKDIR /app

# copy published output
COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://+:80

# expose a container port 
EXPOSE 80

# entrypoint
ENTRYPOINT ["dotnet", "main.API.dll"]