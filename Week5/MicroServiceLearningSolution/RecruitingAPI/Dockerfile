#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV RecruitingAPIDb "Server=1,1433;Database=RecruitingAPIDb;Trusted_Connection=false;TrustServerCertificate=True;User Id=sa;Password=Pa\$\$w0rd2019;"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RecruitingAPI/RecruitingAPI.csproj", "RecruitingAPI/"]
COPY ["Recruiting.Infrastructure/Recruiting.Infrastructure.csproj", "Recruiting.Infrastructure/"]
COPY ["Recruiting.ApplicationCore/Recruiting.ApplicationCore.csproj", "Recruiting.ApplicationCore/"]
RUN dotnet restore "RecruitingAPI/RecruitingAPI.csproj"
COPY . .
WORKDIR "/src/RecruitingAPI"
RUN dotnet build "RecruitingAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecruitingAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecruitingAPI.dll"]
