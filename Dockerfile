FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS build
WORKDIR /build
EXPOSE 80
COPY BankingAPIs .
WORKDIR /build/BankingAPIs

RUN sudo dotnet publish "BankingAPIs" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /build/BankingAPIs ./


ENTRYPOINT ["dotnet", "BankingAPIs"]