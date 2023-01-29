# Dot Net Core

En esta sección se presentan las diferencias entre .NET Framework vs .NET Core, y por otro lado, se explican las características de ASP.NET Core.

## Estructura de un proyecto en ASP.NET Core 2

### Archivo .csproj

Este archivo para manejar proyectos. Algunos de los settings incluídos en este archivo: versión target del .NET Framework, carpetas del proyecto, referencias a los paquetes NuGets, entre otros.

### Dependencies
Contiene todos los paquetes NuGet instalados o que se necesitan obtener para que funcione la aplicación. Algunos de los comandos para manejar las dependencias son:

Agregar una dependencia:
```
dotnet add package Microsoft.EntityFrameworkCore
```
Eliminar una dependencia:
```
dotnet remove package Microsoft.EntityFrameworkCore
```
Listar referencias a paquetes (dependencias):
```
dotnet list [filename].csproj package
```



## Diferencias con .NET Framework

- Carga del archivo de configuración
- Native dependency injection
- Guardado de archivos estáticos.
- Se reemplaza Global.asax por Program.cs: ahí se setea la clase Startup.cs, la cual tiene los métodos Configure y ConfigureServices.

Fuentes:

https://www.youtube.com/watch?v=4FrKuVvISVQ -- ASP.NET Core 2

https://www.tutorialsteacher.com/core/aspnet-core-application-project-structure

https://learn.microsoft.com/en-us/aspnet/core/migration/proper-to-2x/?view=aspnetcore-7.0

