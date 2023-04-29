#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV InterviewAPIDb "Server=100.64.9.218,1433;Database=InterviewAPIDb;Trusted_Connection=false;TrustServerCertificate=True;User Id=sa;Password=Pa\$\$w0rd2019;"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InterviewAPI/InterviewAPI.csproj", "InterviewAPI/"]
COPY ["Interview.Infrastructure/Interview.Infrastructure.csproj", "Interview.Infrastructure/"]
COPY ["Interview.ApplicationCore/Interview.ApplicationCore.csproj", "Interview.ApplicationCore/"]
RUN dotnet restore "InterviewAPI/InterviewAPI.csproj"
COPY . .
WORKDIR "/src/InterviewAPI"
RUN dotnet build "InterviewAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterviewAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterviewAPI.dll"]
