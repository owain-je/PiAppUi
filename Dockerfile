FROM microsoft/dotnet:1.1.4-runtime
WORKDIR /dotnetapp
COPY PiUi/out .
ENTRYPOINT ["dotnet", "PiUi.dll"]