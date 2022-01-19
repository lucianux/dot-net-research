# Interesting topics

## Async / Await

Async: se aplica a la declaración de un método. Lo que indica es que un método se quiere sincronizar con métodos que se ejecutarán de forma asíncrona. Declarar un método como async es requisito indispensable para poder usar await.

Await: esta palabre clave permite que un método que ha llamado a otro método asíncrono se espere a que dicho método asíncrono termine. No usamos await cuando llamamos al método asíncrono, lo hacemos más tarde cuando queremos esperarnos a que dicho método termine (y recoger el resultado).

## LINQ

... INCOMPLETE ...

## Solid

... INCOMPLETE ...

## Delegate

In .NET, System.Action and System.Func types provide generic definitions for many common delegates.
The declaration of a delegate type is similar to a method signature. It has a return value and any number of parameters of any type.
A delegate can be instantiated by associating it either with a named or anonymous method.
Delegates are the basis for Events.

https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-delegate-type -- Intro
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/ -- Base

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

## Ejemplo de la creación de un proyecto de consola

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
