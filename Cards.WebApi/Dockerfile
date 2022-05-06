#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cards.WebApi/Cards.WebApi.csproj", "Cards.WebApi/"]
COPY ["Cards.Dal.Ef.Implememtation/Cards.Dal.Ef.Implememtation.csproj", "Cards.Dal.Ef.Implememtation/"]
COPY ["Cards.Dal.Contracts/Cards.Dal.Contracts.csproj", "Cards.Dal.Contracts/"]
RUN dotnet restore "Cards.WebApi/Cards.WebApi.csproj"
COPY . .
WORKDIR "/src/Cards.WebApi"
RUN dotnet build "Cards.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cards.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cards.WebApi.dll"]
