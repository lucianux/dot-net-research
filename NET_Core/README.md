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

### Properties

En esta carpeta se encuentra el archivo launchSettings.json que contiene settings que se usan en VS (profiles de ejecución en el Debug, settings para el IIS, entre otros). Los profiles se pueden editar desde las propiedades del proyecto, en la pestaña "Debug".

### wwwroot

Es una carpeta pública y visible al usuario, acá pueden ir los archivos estáticos (o en una subcarpeta, generalmente se crean carpetas con los nombres "css", "html" y "js"). Para servir archivos estáticos se debe configurar el middleware e instalar "Microsoft.AspNetCore.StaticFiles".

### Program.cs

Es un archivo ubicado en la raíz del proyecto. Es la entrada a la aplicación en donde se crea el host para la aplicación web. Cuando se crear el proyecto por consola, se autogenera por el template (webapp o mvc) que se aplica. Por defecto, el método CreateDefaultBuilder, internamente configura Kestrel (un web server para ASP.NET Core multiplataforma y open-source), la integración con IIS, el directorio raíz y otras configuraciones. También, se encuentran invocaciones a ConfigureAppConfiguration que carga configuraciones de archivos appsettings.json, variables de ambiente y "user secrets", y finalmente, se encuentra la invocación a ConfigureLogging que es el setup de logging para la consola y la ventana "debug".

### Startup.cs

Es un archivo ubicado en la raíz del proyecto que se asemeja al archivo global.asax, se ejecuta ni bien arranca la aplicación. Se configura en el program.cs, con la invocación al método UseStartup(). La clase Startup contiene dos métodos importantes: ConfigureServices y Configure.

### ConfigureServices

En este método se agregan los servicios al contenedor de IoC y todo el tema de la Inyección por Dependencias. Después de registrar la clase, se puede usar en cualquier lugar de la aplicación.

### Configure

En este método se puede configurar el Middleware (HTTP request pipeline) para que se pueda ejecutar en cada request.
El método ConfigureServices se llama antes que el método Configure, de modo que los servicios registrados en el contenedor de IoC se pueden usar en el método Configure.

[...INCOMPLETE ...]

## Diferencias con .NET Framework

- Carga del archivo de configuración
- Native dependency injection
- Guardado de archivos estáticos.
- Se reemplaza Global.asax por Program.cs: ahí se setea la clase Startup.cs, la cual tiene los métodos Configure y ConfigureServices.

Fuentes:

https://www.youtube.com/watch?v=4FrKuVvISVQ -- ASP.NET Core 2

https://www.tutorialsteacher.com/core/aspnet-core-application-project-structure

https://learn.microsoft.com/en-us/aspnet/core/migration/proper-to-2x/?view=aspnetcore-7.0

