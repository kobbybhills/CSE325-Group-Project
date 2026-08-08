# Step 1: Build using .NET 10 SDK
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["CSE325-Group-Project.csproj", "./"]
RUN dotnet restore "CSE325-Group-Project.csproj"

# Copy remaining files and build
COPY . .
RUN dotnet publish "CSE325-Group-Project.csproj" -c Release -o /app/publish

# Step 2: Run using .NET 10 Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CSE325-Group-Project.dll"]
