FROM mcr.microsoft.com/dotnet/aspnet:6.0

LABEL org.label-schema.vcs-url="https://fynzie.com"
LABEL org.label-schema.vendor="fynzie"
LABEL org.label-schema.name="Fynzie"

COPY /publish /app
WORKDIR /app

ENTRYPOINT ["dotnet", "StockManagement.Api.dll"]