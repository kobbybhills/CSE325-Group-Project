FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["CSE325-Group-Project.csproj", "./"]
RUN dotnet restore "CSE325-Group-Project.csproj"

COPY . .
RUN dotnet publish "CSE325-Group-Project.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CSE325-Group-Project.dll"]
