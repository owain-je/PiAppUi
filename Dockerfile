FROM microsoft/dotnet:runtime
WORKDIR /dotnetapp
COPY PiUi/out .
ENTRYPOINT ["dotnet", "PiUi.dll"]