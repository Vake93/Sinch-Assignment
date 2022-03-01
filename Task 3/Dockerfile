FROM alpine:3.14 AS base
RUN apk add --no-cache bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_GCHeapHardLimit=10000000

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine3.14 AS api.build
WORKDIR /PolishNotation.API
ADD PolishNotation.API /PolishNotation.API
RUN dotnet publish "PolishNotation.API.csproj" --runtime alpine-x64 -c Release --self-contained true -o /PolishNotation.API/publish

FROM base AS final
WORKDIR /app
COPY --from=api.build /PolishNotation.API/publish /app
ENTRYPOINT ["/app/PolishNotation.API"]