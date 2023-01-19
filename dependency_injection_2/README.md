# Inyección de Dependencias con ASP.NET

## Motivación

Años atrás, ante la creciente adopción de la modularidad y la reutilización de los componentes, aparece un nuevo problema: la dependencia (acoplamiento) entre los componentes. Lo ideal es tratar de favorecer un grado de acoplamiento bajo, pero sin sacrificar la cohesión.

## Bases

La Inyección de Dependencias es un patrón de diseño orientado a objetos en el que se suministran objetos a una clase en lugar de ser la propia clase la que cree dichos objetos. Esos objetos cumplen contratos que necesitan nuestras clases (las vamos a llamar "servicios") para poder funcionar (de ahí el concepto de dependencia). Nuestras clases (o "servicios") no crean los objetos que necesitan, sino que se los suministra otra clase 'contenedora' que inyectará la implementación deseada a nuestro contrato.
Es decir, que es un patrón de diseño que se encarga de extraer la responsabilidad (de crear instancias) a un componente para delegarlo a otro.

En términos generales, la Inyección por Dependencias se basa en:
- Usar interfaces en vez de clases concretas: la idea es que se puedan cambiar las implementaciones de estas interfaces. De esta forma, se escribe código reutilizable y desacoplado.
- La tarea de crear los objetos dependientes que se usan dentro del servicio, se la delega a otra clase.
- Beneficios: la fácil gestión de cambios a futuro, implementación fácil en pruebas unitarias, factoría para emitir instancias de clases, prevención de fugas de memoria, entre otros.

## IoC vs DI

Tradicionalmente el programador especificaba la secuencia de decisiones y procedimientos que podrían darse durante el ciclo de vida de un programa mediante llamadas a funciones. En su lugar, en la Inversión de Control (IoC) se especifican respuestas deseadas a sucesos o solicitudes de datos concretas, dejando que algún tipo de entidad o arquitectura externa lleve a cabo las acciones de control que se requieran en el orden necesario y para el conjunto de sucesos que tengan que ocurrir.
Esta nueva filosofía es muy útil cuando se usan frameworks de desarrollo. Es el framework el que toma el control, el que define el flujo de actuación o el ciclo de vida de una petición. Es decir, es el framework quien ejecuta el código de usuario.
La inversión de control es un término genérico que puede implementarse de diferentes maneras. Por ejemplo se puede implementar mediante eventos o mediante Inyección de Dependencias (DI).
Se puede ver en este gráfico distintas implementaciones de IoC:
<p align="center">
  <img src="/dependency_injection_2/Assets/KindsOfIoC.jpg" alt="Implementaciones de IoC"/>
</p>

## En ASP.NET Core

En el entorno de .NET Core, la Inyección por Dependencias se basa en:

- El framework .NET Core incorpora el mecanismo de Inyección de Dependencias, evitando usar software de terceros.
- El sistema de inyección de dependencias de ASP.NET Core puede ser remplazado por otro.
- El sistema de inyección de dependencias de ASP.NET Core unicamente soporta la inyección por medio del constructor.
- Configuración: es en el método ConfigureServices de la clase Startup, en donde se agregan servicios (clases) al contenedor de inversión de control, quién es el encargado de proveer las instancias cuando se referencian las interfaces.

Dentro del contenedor que nos proveé ASP.NET Core existen 3 ciclos de vida básicos los cuales podemos utilizar para inicializar las dependencias desde nuestro contenedor:
- Transient: se crean cada vez que se lo referencia (se lo solicitan desde el contenedor de servicios). Esta vida útil funciona mejor para servicios ligeros y sin estado.
- Scoped: se crean una por cada solicitud del cliente (conexión). Se utiliza cuando queremos servir la misma instancia dentro del mismo contexto de una petición HTTP, pero diferente entre distintos contextos HTTP.
- Singleton: se crean la primera vez que se solicitan o cuando Startup.ConfigureServices se ejecuta y se especifica una instancia con el registro del servicio. Cada solicitud posterior utiliza la misma instancia.

# Demo

## Comandos a ejecutar

### Para compilarlo

dotnet build

### Para correrlo

dotnet run -p ./webapi_di/webapi_di.csproj

### Para probar con Swagger

http://localhost:5000/swagger/index.html

## Observaciones

Los ciclos de vida se pueden observar en los siguientes estados:

.... INCOMPLETE ....

# Links

- https://es.wikipedia.org/wiki/Inyecci%C3%B3n_de_dependencias // Buenas definiciones

- https://www.youtube.com/watch?v=rAP0RWLmko4 (fuente original del proyecto de ejemplo)

- https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0

- https://dev.to/ebarrioscode/inyeccion-de-dependencias-di-en-asp-net-core-mejores-practicas-para-escribir-codigo-reutilizable-escalable-y-desacoplado-kho

- https://dotnettutorials.net/lesson/dependency-injection-design-pattern-csharp/ // Se menciona la DI por method y property

- https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes // Explica el tiempo de vida de los servicios
