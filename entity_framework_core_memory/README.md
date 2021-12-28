# Entity Framework Core in Memory

## Para crear el proyecto MVC

dotnet new mvc -o exampleEntityFrameworkCoreMemory

## Para instalar la librería de Entity Framework Core (compatible con NET CORE 3.1)

dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 3.1.22

## Para ejecutarlo

dotnet run -p ./exampleEntityFrameworkCoreMemory/exampleEntityFrameworkCoreMemory.csproj

## Salida (web)

https://localhost:5001/
Se muestra una grilla con la info cargada.

## Explicación

Configuración:
- AppDbContext.cs
- Startup.cs
- Program.cs

Modelos:
- Album.cs
- Artist.cs

Carga de datos:
- DbInitializer.cs

Vista:
- HomeController.cs
- Index.cshtml

## Fuentes

https://dev.to/ebarrioscode/base-de-datos-en-memoria-con-asp-net-core-3-0-mvc-entity-framework-core-3950

