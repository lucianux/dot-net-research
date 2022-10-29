FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY ./exampleConsole/exampleConsole.csproj /app/
COPY ./exampleConsole/Program.cs /app/

WORKDIR app

RUN dotnet publish -c Release -o dist exampleConsole.csproj

ENTRYPOINT ["dotnet", "dist/exampleConsole.dll"]

