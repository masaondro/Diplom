FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["VKR/VKR.csproj", "VKR/"]
RUN dotnet restore "VKR/VKR.csproj"
COPY . .
WORKDIR "/src/VKR"
RUN dotnet build "VKR.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VKR.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VKR.dll"]
