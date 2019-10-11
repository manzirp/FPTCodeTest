FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["FPTCodeTest.Services/FPTCodeTest.Services.csproj", "FPTCodeTest.Services/"]
COPY ["FPTCodeTest.Data/FPTCodeTest.Data.csproj", "FPTCodeTest.Data/"]
RUN dotnet restore "FPTCodeTest.Services/FPTCodeTest.Services.csproj"
COPY . .
WORKDIR "/src/FPTCodeTest.Services"
RUN dotnet build "FPTCodeTest.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FPTCodeTest.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FPTCodeTest.Services.dll"]