FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["sh.Labs.BlazorApp/sh.Labs.BlazorApp.csproj", "sh.Labs.BlazorApp/"]
RUN dotnet restore "sh.Labs.BlazorApp/sh.Labs.BlazorApp.csproj"
COPY . .
WORKDIR "/src/sh.Labs.BlazorApp"
RUN dotnet build "sh.Labs.BlazorApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "sh.Labs.BlazorApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "sh.Labs.BlazorApp.dll"]