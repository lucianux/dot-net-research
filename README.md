# Interesting topics about C#

## Async / Await

Async: se aplica a la declaración de un método. Lo que indica es que un método se quiere sincronizar con métodos que se ejecutarán de forma asíncrona. Declarar un método como async es requisito indispensable para poder usar await.

Await: esta palabre clave permite que un método que ha llamado a otro método asíncrono espere a que dicho método asíncrono termine. No usamos await ni bien cuando llamamos al método asíncrono, lo hacemos más tarde cuando esperamos a que dicho método termine (y recoger el resultado).
Sobre un objeto "awaitable", es sobre el que llamaremos a await para esperarnos a que el método asíncrono finalice y a la vez obtener el resultado. Un objeto awaitable es conocido de la TPL (Task Parallel Library) que viene con .NET 4: es un objeto Task o su equivalente genérico Task<T>.
Fuente:
https://geeks.ms/etomas/2011/09/17/c-5-async-await/

The await keyword provides a non-blocking way to start a task, then continue execution when that task completes.
Fuente:
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/#dont-block-await-instead

## LINQ

LINQ (Language Integrated Query) es un conjunto de extensiones integradas en el lenguaje C#, que nos permite trabajar de manera cómoda y rápida con colecciones de datos, como si de una base de datos se tratase. Es decir, podemos llevar a cabo inserciones, selecciones y borrados, así como operaciones sobre sus elementos.

... INCOMPLETE ...

## Solid

- S: Single Responsibility Principle (SRP): define que cada modulo de software debe tener sólo una razón para cambiar. En otras palabras, cada clase debe tener sólo una responsabilidad.
- O: Open-Closed Principle (OCP): las entidades de software deben ser abiertas para la extensión, pero cerradas para la modificación.
- L: Liskov Substitution Principle (LSP): las clases derivadas deben ser sustituibles por sus clases base. Es decir, que un objeto puede ser reemplazado por un subobjeto (instancia de una subclase de la clase del primer objeto) sin romper el programa, sin dejar sus referencias inválidas.
- I: Interface Segregation Principle (ISP): dice que se deben crear interfaces detalladas que sean específicas del cliente. En otras palabras, lo que dice este principio es que se deben dividir las interfaces que son muy grandes en otras más pequeñas y específicas para que los clientes solo tengan que conocer los métodos que les interesan.
- D: Dependency Inversion Principle (DIP): el código debe depender de abstracciones, no de objetos concretos. Este principio establece dos puntos. Primero, los módulos de alto nivel no deberían importar nada de los módulos de bajo nivel. Ambos deben depender de abstracciones (por ejemplo, interfaces). Segundo, las abstracciones no deben depender de los detalles; sino que los detalles (implementaciones concretas) deberían depender de las abstracciones.

## Dependency Injection

Este mecanismo trata de evitar el acoplamiento entre clases utilizando interfaces y dejando de usar las clases concretas. Con ésto se consigue (o se intenta) que cada clase tenga una función única. También nos facilita cambiar la implementación sin tener que modificar la clase que lo usa.

En .NET Core se tiene la posibilidad de utilizar el patrón Inyección de Dependencias de forma nativa, que nos permite hacer la IoC o inversión de control sin tener que utilizar otro software de terceros. La librería que se encarga de todo ésto es: Microsoft.Extensions.DependencyInjection

Como sucede con toda librería de Inyección de Dependencias, lo único que debemos hacer es registrar de alguna manera la interfaz y la implementación a utilizar de forma que al resolverse se haga de forma automática, para luego recuperarla con el objetivo de poder trabajar con ella en la parte de código que tenga la necesidad de utilizarla.

Hay 3 tipos de inyección de dependencias
- Inyección de dependencias en parámetros de constructor.
- Inyección de propiedades (setters).
- Inyección de dependencias en parámetros de métodos.

**En ASP.NET Core**

El método ConfigureServices de la clase Startup nos permitirá configurar o registrar los servicios de aplicación, con un contenedor de Inyección por Dependencias. Se llama servicios a las clases que pertenecen a otro proyecto; hay dos tipos de servicios: los del propio Framework y los de la aplicación.

Fuentes:
- https://geeks.ms/jorge/2019/02/06/inyeccion-de-dependencias-en-asp-net-core-i/
- https://geeks.ms/jorge/2019/02/07/inyeccion-de-dependencias-en-asp-net-core-ii/
- https://geeks.ms/jorge/2019/02/09/inyeccion-de-dependencias-en-asp-net-core-iii/
- https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0
- https://www.fixedbuffer.com/inyeccion-de-dependencias-en-net-framework/

## Delegate

In .NET, System.Action and System.Func types provide generic definitions for many common delegates.
The declaration of a delegate type is similar to a method signature. It has a return value and any number of parameters of any type.
A delegate can be instantiated by associating it either with a named or anonymous method.
Delegates are the basis for Events.

Fuente:
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-delegate-type -- Intro
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/ -- Base

The difference between Func and Action is simply whether you want the delegate to return a value (use Func) or not (use Action).

Fuente:
https://stackoverflow.com/questions/4317479/func-vs-action-vs-predicate

## Abstract class and methods.

The purpose of an abstract class is to provide a common definition of a base class that multiple derived classes can share.
An abstract class cannot be instantiated.
Abstract methods have no implementation.
DERIVED CLASSES OF THE ABSTRACT CLASS MUST IMPLEMENT ALL ABSTRACT METHODS. 
Fuente:
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members

## Sealed class and methods

A sealed class cannot be used as a base class.
Sealed classes prevent derivation.
This negates the virtual aspect of the member for any further derived class.

## Virtual vs Abstract

Virtual methods have an implementation and provide the derived classes with the option of overriding it. Abstract methods do not provide an implementation and force the derived classes to override the method.
So, abstract methods have no actual code in them, and subclasses HAVE TO override the method. Virtual methods can have code, which is usually a default implementation of something, and any subclasses CAN override the method using the override modifier and provide a custom implementation.
Fuente:
https://stackoverflow.com/questions/14728761/difference-between-virtual-and-abstract-methods

## Abstract class vs. Interface

* Ambas coinciden en que no se pueden instanciar. Para que sí se pueda: se debe usar otra clase que herede o implemente.
* Una clase abstracta puede tener métodos abstractos (sin implementación) y no abstractos (con implementación). En otras palabras, las clases abstractas se pueden implementar completamente, una parte o nada. En cambio, en las interfaces, no se puede implementar nada, proporcionan una abstracción total, definen un contrato.
* Una clase abstracta puede tener constructores, una interfaz no.
* Absolutamente todos los métodos declarados en una interfaz deben ser implementados por las clases que implementan la interfaz, no así en las clases abstractas.
* Una interfaz no puede tener ningún dato miembro (member data). En cambio, una clase abstracta puede contener definiciones de métodos, campos y constructores, una interfaz solo puede tener declaraciones de eventos, métodos y propiedades.
* Usando clases abstractas no podemos lograr herencia múltiple, pero si se puede usando interfaces. Dado que una clase puede implementar más de una interfaz, pero sólo extender una clase.
* Por defecto, los métodos de una interfase son abstratos y públicos. Por ésto no se puede usar ningún modificador de acceso (como public, private, protected, internal, etc.), keywords como static, virtual, abstract or sealed.
* En resumen, una clase abstracta le permite crear funcionalidades que las subclases pueden implementar o sobreescribir. Una interfaz solo le permite definir la funcionalidad como un contrato, pero no implementarla.

Fuentes:
* https://www.infoworld.com/article/2928719/when-to-use-an-abstract-class-vs-interface-in-csharp.html
* https://www.geeksforgeeks.org/difference-between-abstract-class-and-interface-in-c-sharp/

-----

# Fundamentos de POO


## Los 4 fundamentos de la programación orientada a objetos:

**Abstracción**: este principio dice que la POO busca modelar los objetos, busca atraerse y simplificar un objeto de la vida real a solo un par de atributos. En otras palabras, buscaremos transformar un objeto de la vida real en atributos (características) y sus acciones (métodos). Consiste en encontrar las partes fundamentales de un sistema para describirlas de manera simple y precisa.

**Encapsulamiento**: es la cualidad de los objetos de ocultar los detalles de implementación y su estado interno del mundo exterior
Características:
* Esconde detalles de implementación.
* Protege el estado interno de los objetos.
* Un objeto sólo muestra su “cara visible” por medio de su protocolo.
* Los métodos y su estado quedan escondidos para cualquier otro objeto. Es el objeto quien decide qué se publica.
* Facilita modularidad y reutilización.

**Herencia**: es el mecanismo por el cual las subclases reutilizan el comportamiento y estructura reunido en sus superclases. En otras palabras, permite que una clase pueda servir como plantilla para la creación de futuras clases.
La herencia permite:
* Crear una nueva clase como refinamiento de otra.
* Diseñar e implementar sólo la diferencia que presenta la nueva clase.
* Abstraer las similitudes en común.

**Polimorfismo**: un solo nombre de una clase o método puede representar diferentes implementaciones, pero solo una interfaz. Es decir, comportamientos diferentes, asociados a objetos distintos, pueden compartir el mismo nombre; al llamarlos por ese nombre se utilizará el comportamiento correspondiente al objeto que se esté usando. Dicho de otro modo, las referencias y las colecciones de objetos pueden contener objetos de diferentes tipos, y la invocación de un comportamiento en una referencia producirá el comportamiento correcto para el tipo real del objeto referenciado.

Fuente:

https://medium.com/@cancerian0684/what-are-four-basic-principles-of-object-oriented-programming-645af8b43727

## Cohesión y acoplamiento

... INCOMPLETE ...

## MVC

... INCOMPLETE ...

Fuentes:

- https://si.ua.es/es/documentacion/asp-net-mvc-3/1-dia/modelo-vista-controlador-mvc.html
- https://developer.mozilla.org/es/docs/Glossary/MVC
- https://desarrolloweb.com/articulos/que-es-mvc.html

-----

# Comandos de consola

Pasos generales:

Armar los proyectos, compilar, configurar el debugging.

## Creando un Proyecto .NET

### Crear la solución (crea una carpeta con el archivo .sln)
dotnet new sln -o PaymentFacilities

### Crear los proyectos (más info con dotnet new -l)
dotnet new webapi -o PaymentFacilities.WebApi
dotnet new classlib -o PaymentFacilities.Core
dotnet new classlib -o PaymentFacilities.SharedKernel
dotnet new classlib -o PaymentFacilities.Infraestructure

### Agregar un proyecto a la solución
dotnet sln PaymentFacilities.sln add ./PaymentFacilities.WebApi/PaymentFacilities.WebApi.csproj
dotnet sln PaymentFacilities.sln add ./PaymentFacilities.Core/PaymentFacilities.Core.csproj
dotnet sln PaymentFacilities.sln add ./PaymentFacilities.SharedKernel/PaymentFacilities.SharedKernel.csproj
dotnet sln PaymentFacilities.sln add ./PaymentFacilities.Infraestructure/PaymentFacilities.Infraestructure.csproj

### Agregar referencias
dotnet add ./PaymentFacilities.Core/PaymentFacilities.Core.csproj reference ./PaymentFacilities.SharedKernel/PaymentFacilities.SharedKernel.csproj
dotnet add ./PaymentFacilities.WebApi/PaymentFacilities.WebApi.csproj reference ./PaymentFacilities.SharedKernel/PaymentFacilities.SharedKernel.csproj
dotnet add ./PaymentFacilities.WebApi/PaymentFacilities.WebApi.csproj reference ./PaymentFacilities.Infraestructure/PaymentFacilities.Infraestructure.csproj
dotnet add ./PaymentFacilities.WebApi/PaymentFacilities.WebApi.csproj reference ./PaymentFacilities.Core/PaymentFacilities.Core.csproj
dotnet add ./PaymentFacilities.Infraestructure/PaymentFacilities.Infraestructure.csproj reference ./PaymentFacilities.SharedKernel/PaymentFacilities.SharedKernel.csproj
dotnet add ./PaymentFacilities.Infraestructure/PaymentFacilities.Infraestructure.csproj reference ./PaymentFacilities.Core/PaymentFacilities.Core.csproj

### Agregar librerías
dotnet add ./PaymentFacilities.Infraestructure/PaymentFacilities.Infraestructure.csproj package Autofac --version 5.2.0
dotnet add ./PaymentFacilities.WebApi/PaymentFacilities.WebApi.csproj package Autofac.Extensions.DependencyInjection --version 6.0.0
dotnet add ./PaymentFacilities.Infraestructure/PaymentFacilities.Infraestructure.csproj package MediatR
dotnet add ./PaymentFacilities.SharedKernel/PaymentFacilities.SharedKernel.csproj package MongoDB.Driver --version 2.11
dotnet add ./PaymentFacilities.Infraestructure/PaymentFacilities.Infraestructure.csproj package Autofac.Extensions.DependencyInjection --version="6.0.0"

### Correr
dotnet run -p ./PaymentFacilities.WebApi/PaymentFacilities.WebApi.csproj

### Pruebas
http://localhost:5000/api/WeatherForecast
http://localhost:5000/api/PaymentFacilities
http://localhost:3000/api/PaymentFacilities/getPaymentFacility/1

Fuente:

https://stackoverflow.com/questions/36343223/create-c-sharp-sln-file-with-visual-studio-code

-----

## Ejemplo de la creación de un proyecto simple de consola

### Crear una solución (dentro del mismo directorio)
dotnet new sln -n exampleSolution

### Crear un nuevo proyecto de consola
dotnet new console -o exampleConsole

### Asociar el proyecto a la solución
dotnet sln exampleSolution.sln add ./exampleConsole/exampleConsole.csproj

### Correr mi aplicación:
dotnet run -p ./exampleConsole/exampleConsole.csproj

### Compilar la aplicación
dotnet build

### Abrir el proyecto con VS Code (ubicado en la raíz): 
code .

### Otra forma de abrir una solución de .NET Core en VS Code: abrir la carpeta raíz (la que contiene el .sln) y ahí escanea todos los archivos.

### No olvidar de agregar el .gitignore en la raíz (donde está la solución) con este contenido:
[https://github.com/github/gitignore/blob/main/VisualStudio.gitignore](https://github.com/github/gitignore/blob/main/VisualStudio.gitignore)

## Ejemplo de la creación de un proyecto de Testing

### Crear un proyecto de pruebas:
dotnet new xunit -o exampleTestProject

### Para ejecutar el proyecto de pruebas:
dotnet test ./exampleTestProject/exampleTestProject.csproj

*/exampleTestProject/UnitTest1.cs*
...
using System;
using Xunit;
namespace exampleTestProject
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      Assert.True(true);
    }
  }
}
...

-----

## Comandos útiles en .NET Core

### Run
dotnet run
dotnet run -p ./PaymentFacilities.WebApi/PaymentFacilities.WebApi.csproj

### Build
dotnet build

### Clean
dotnet clean

### Test
dotnet test

### Restore
dotnet restore

### Show installed packages
dotnet list [filename].sln package

### Publish a release
dotnet publish -c Release

-----

## Debugging

- En VSCode, se crea la carpeta .vscode desde la pestaña de debugging (cuando se ejecuta el comando "create a launch.json file").
- Opcional - En VSCode, cuando se pone play, se crea el archivo tasks.json para crear la regla build.
- Opcional - se configura launch.json: setear la variable "program".

-----

## Instalando .NET 5.0 (= Core 4.0) en Linux

### Primero, bajar:
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

### Segundo, instalar:
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-5.0

### Tercero, check:
dotnet --list-sdks
dotnet --list-runtimes
dotnet --info

### Opcional
sudo apt-get install -y dotnet-sdk-3.1

Fuentes:

https://docs.microsoft.com/en-us/dotnet/core/install/how-to-detect-installed-versions?pivots=os-linux
https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2004-

TargetFrameworks en .csproj:

https://docs.microsoft.com/en-us/dotnet/core/project-sdk/msbuild-props#targetframeworks
https://docs.microsoft.com/en-us/dotnet/standard/frameworks
