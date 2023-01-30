# Dot Net Core

En esta sección se presentan las diferencias entre .NET Framework vs .NET Core, y por otro lado, se explican las características de ASP.NET Core.

## Estructura de un proyecto en ASP.NET Core 2

### Archivo .csproj

Este archivo sirve para gestionar un proyecto. Éstos son algunos de los settings incluídos en este archivo: versión target del .NET Framework, carpetas del proyecto, referencias a los paquetes NuGets, entre otros.

### Dependencies

Contiene todos los paquetes NuGet instalados o aquellos que se necesitan obtener para que funcione la aplicación. Algunos de los comandos para manejar las dependencias son:

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

Es una carpeta pública y visible al usuario, en donde pueden ir los archivos estáticos (o en una subcarpeta, generalmente se crean carpetas con los nombres "css", "html" y "js"). Para alojar archivos estáticos se debe configurar el middleware e instalar el paquete "Microsoft.AspNetCore.StaticFiles".

### Program.cs

Es un archivo que está ubicado en la raíz del proyecto. Funciona como una entrada a la aplicación, en donde se crea el host para la aplicación web. Por defecto, el método CreateDefaultBuilder, internamente configura Kestrel (un web server para ASP.NET Core multiplataforma y open-source), la integración con IIS, el directorio raíz y otras configuraciones. También, se encuentran invocaciones a ConfigureAppConfiguration que carga configuraciones de archivos appsettings.json, variables de ambiente y "user secrets", y finalmente, se encuentra la invocación a ConfigureLogging que es el setup de logging para la consola y la ventana "debug".

[...AGREGAR MÁS INFO, EN LO POSIBLE ...]

### Startup.cs

Es un archivo ubicado en la raíz del proyecto que se asemeja al archivo global.asax, dado que se ejecuta ni bien arranca la aplicación. Se configura en el program.cs, con la invocación al método UseStartup(). La clase Startup contiene dos métodos importantes: ConfigureServices y Configure, que a continuación se explicarán.

#### ConfigureServices (en Startup.cs)

En este método se registran las clases dependientes en el contenedor IoC incorporado. Una vez registradas las clases, pueden ser usadas en cualquier lugar de la aplicación. En este método se incluye el parámetro IServiceCollection para registrar los servicios al contenedor IoC.

#### Configure (en Startup.cs)

ASP.NET Core introdujo los componentes de MIDDLEWARE para definir un request pipeline, el cual será ejecutado en cada request. Entonces, es en este método (Configure()) que se configura el MIDDLEWARE (HTTP request pipeline) para que se pueda ejecutar en cada request. Se lo hace usando una instancia de IApplicationBuilder que provee el contenedor IoC incorporado. En la versión por defecto, se puede ver algunos componentes middleware registrados como: UseDeveloperExceptionPage, UseSwagger, UseSwaggerUI, UseHttpsRedirection, UseRouting, UseAuthorization y UseEndpoints. Un dato no menor es que el método ConfigureServices se llama antes que el método Configure, de modo que los servicios registrados en el contenedor de IoC se puedan usar en el método Configure.

### appsettings.json

Este archivo es el mismo que web.config o app.config de las tradicionales aplicaciones .NET, es decir, es el archivo de configuración de la aplicación web en ASP.NET Core, usado para guardar settings como connections strings, parámetros de la aplicación, etc.

## appsettings.Development.json

En caso de que se quiera configurar algunos parámetros basados en el ambiente entonces se lo puede hacer en el archivo appsettings.{Environment}.json, donde se puede crear n número de ambientes como development, staging, production, etc.

## Diferencias con .NET Framework

- Carga del archivo de configuración
- Native dependency injection
- Guardado de archivos estáticos.
- Se reemplaza Global.asax por Program.cs: ahí se setea la clase Startup.cs, la cual tiene los métodos Configure y ConfigureServices.

Fuentes:

https://www.youtube.com/watch?v=4FrKuVvISVQ -- ASP.NET Core 2

https://www.tutorialsteacher.com/core/aspnet-core-application-project-structure

https://learn.microsoft.com/en-us/aspnet/core/migration/proper-to-2x/?view=aspnetcore-7.0

https://www.integrativesystems.com/features-of-dot-net-core/

https://dotnettutorials.net/lesson/asp-net-core-web-api-files-and-folders/

