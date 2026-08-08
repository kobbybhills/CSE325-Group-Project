# Step 1: Build using .NET 9 SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["CSE325-Group-Project.csproj", "./"]
RUN dotnet restore "CSE325-Group-Project.csproj"

# Copy remaining files and publish
COPY . .
RUN dotnet publish "CSE325-Group-Project.csproj" -c Release -o /app/publish

# Step 2: Run using .NET 9 ASP.NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CSE325-Group-Project.dll"]
