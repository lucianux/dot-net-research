# simple-api-core-app
A simple application based on ASP Net Core Web API.

## Instrucciones del paso a paso:
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1

## Comandos usados para construir la estructura base del proyecto:

*Crear una solución (dentro del mismo directorio)*
- dotnet new sln -n simple-api-core-app

*Crear un proyecto Web API usando un template*
- dotnet new webapi -o web-api-project

*Asociar los proyectos a la solución*
- dotnet sln simple-api-core-app.sln add ./web-api-project/web-api-project.csproj

*Agregar una librería de un tercero*
- dotnet add ./web-api-project/web-api-project.csproj package Microsoft.EntityFrameworkCore.InMemory --version 5.0.0

*Compilar la aplicación*
- dotnet build

*Correr la aplicación*
- dotnet run -p ./web-api-project/web-api-project.csproj

## Luego de escribir el código y se ejecuta:

*Instalar la herramienta de generación de código (la versión que te sea compatible)*
- dotnet tool install --global dotnet-aspnet-codegenerator --version 3.1.5

*Se agregan las dependencias del generador de código (las versiones que te sean compatibles)*
- dotnet add ./web-api-project/web-api-project.csproj package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 3.1.5
- dotnet add ./web-api-project/web-api-project.csproj package Microsoft.EntityFrameworkCore.Design --version 5.0.13
- dotnet add ./web-api-project/web-api-project.csproj package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.13

*Generar el controller con el generador de código (se debe entrar al proyecto Web API)*
- dotnet aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem -dc TodoContext -outDir Controllers

---

*Plataforma usada:*
- .NET Core SDK 3.1.407
- SO: Windows 10 (aunque debería andar en Linux)
