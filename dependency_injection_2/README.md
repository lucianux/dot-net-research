# Dependency Injection con ASP.NET

Comandos a ejecutar
----

## Para compilarlo

dotnet build

## Para correrlo

dotnet run -p ./webapi_di/webapi_di.csproj

## Para probar con Swagger

http://localhost:5000/swagger/index.html

---

# Inyección de dependencias

## Motivación

Años atrás, ante la creciente adopción de la modularidad y la reutilización de los componentes, aparece un nuevo problema: la dependencia (acoplamiento) entre los componentes. Lo ideal es tratar de favorecer un grado de acoplamiento bajo, pero sin sacrificar la cohesión.

## Bases

Es un patrón de diseño orientado a objetos en el que se suministran objetos a una clase en lugar de ser la propia clase la que cree dichos objetos. Esos objetos cumplen contratos que necesitan nuestras clases para poder funcionar (de ahí el concepto de dependencia). Nuestras clases no crean los objetos que necesitan, sino que se los suministra otra clase 'contenedora' que inyectará la implementación deseada a nuestro contrato.
Es decir, que es un patrón de diseño que se encarga de extraer la responsabilidad de crear instancias a un componente para delegarlo a otro.

En términos generales, la Inyección por Dependencias:
- Usar interfaces en vez de clases concretas: la idea es puedan cambiar las implementaciones. De esta forma, se escribe código reutilizable y desacoplado.
- Beneficios: la fácil gestión de cambios a futuro, implementación fácil en pruebas unitarias, factoría para emitir instancias de clases, prevención de fugas de memoria, entre otros.

## En ASP.NET Core

En el entorno de .NET Core, la Inyección por Dependencias se basa en:

- El framework .NET Core incorpora el mecanismo de Inyección de Dependencias, evitando usar software de terceros.
- El sistema de inyección de dependencias de ASP.NET Core puede ser remplazado por otro.
- El sistema de inyección de dependencias de ASP.NET Core unicamente soporta la inyección por medio del constructor.
- Configuración: es en el método ConfigureServices de la clase Startup, en donde se agregan servicios (clases) al contenedor de inversión de control, quién es el encargado de proveer las instancias de los tipos a los cuales le decimos en el inicio de la aplicación (Startup).

Dentro del contenedor que nos proveé ASP.NET Core existen 3 ciclos de vida básicos los cuales podemos utilizar para inicializar las dependencias desde nuestro contenedor:
- Transient: se crean cada vez que se lo referencia (se lo solicitan desde el contenedor de servicios). Esta vida útil funciona mejor para servicios ligeros y sin estado.
- Scoped: se crean una vez por solicitud del cliente (conexión). Se utiliza cuando queremos servir la misma instancia dentro del mismo contexto de una petición HTTP, pero diferente entre distintos contextos HTTP.
- Singleton: se crean la primera vez que se solicitan o cuando Startup.ConfigureServices se ejecuta y se especifica una instancia con el registro del servicio. Cada solicitud posterior utiliza la misma instancia.

## Ejemplo práctico

.... INCOMPLETE ....

Links
----

https://www.youtube.com/watch?v=rAP0RWLmko4 (fuente original del proyecto de ejemplo)

https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0
