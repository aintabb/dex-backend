FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

COPY . ./

ENV App__Self__JwtAuthority = ' '

ENV App__Self__IdentityApplications = [ ]

ENV App__Api__DeXApiUrl = ' '

ENV App__Frontend__RedirectUrisFrontend = [ ]

ENV App__Frontend__PostLogoutUrisFrontend = [ ]

RUN dotnet publish IdentityServer/6_IdentityServer.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "6_IdentityServer.dll"]