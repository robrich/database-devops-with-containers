FROM microsoft/dotnet:2.1-sdk-alpine AS build

WORKDIR /src
COPY WebApp.csproj .
RUN dotnet restore WebApp.csproj

COPY . .
RUN dotnet build WebApp.csproj -c Release
RUN dotnet publish WebApp.csproj -c Release -o /app


FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS runtime

ENV ASPNETCORE_URLS https://+:5001;http://+:5000
EXPOSE 5000
EXPOSE 5001

# untrusted dev cert
COPY --from=build /root/.dotnet/corefx/cryptography /root/.dotnet/corefx/cryptography

WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "WebApp.dll"]
