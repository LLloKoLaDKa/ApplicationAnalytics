#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AA.API/AA.API.csproj", "AA.API/"]
COPY ["AA.Services/AA.Services.csproj", "AA.Services/"]
COPY ["AA.EntitiesCore/AA.EntitiesCore.csproj", "AA.EntitiesCore/"]
COPY ["AA.Domain/AA.Domain.csproj", "AA.Domain/"]
RUN dotnet restore "AA.API/AA.API.csproj"
COPY . .
WORKDIR "/src/AA.API"
RUN dotnet build "AA.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AA.API.csproj" -c Release -o /app/publish

EXPOSE 5000

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AA.API.dll"]