# Asp.NET Core Advance understanding.

## Se divide en 2 submisiones:
  - Channel 9 Net Core 101 (8 videos de la web de Microsoft)
  - Net Academy Web Api & NetCore Into (una web de la consultora G con links a tutorialespoint.com, algunos branches y tareas)

## Empecemos con la primera submisi�n: revisar los videos y documentar de "Channel 9 Net Core 101"

[Fuente: https://docs.microsoft.com/en-us/shows/NET-Core-101/]

Una serie de videos (8) en donde se explican los siguientes temas:
  - (A) �Qu� es .NET?
  - (B) Installing .NET
  - (C) What is a .NET Hello World App?
  - (D) .NET: Basic Debugging
  - (E) .NET - Adding a Class Library
  - (F) .NET - Using a NuGet Package
  - (G) .NET - Unit Testing
  - (H) .NET - Publishing an App

### (A) �Qu� es .NET?
- Development platform (language + libraries). Languages: C#, VB.NET, F#
- Open Source.
- Platforms: .NET Core (multiplatform), .NET Framework (closed-source), Xamarin/Mono, .NET Standard (conjunto de librer�as).

Tipos de apps que se pueden construir con .NET:
- Web
- Mobile
- Desktop
- Microservices
- Cloud
- Machine Learning
- Game Development
- Internet of Things

M�s info:
https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet

### (B) Installing .NET

No instalo VS ni a palos!
Prefiero VS Code, usar la consola y usar Linux.
Link para descargar el SDK de .NET Core:
https://dotnet.microsoft.com/en-us/download

### (C) What is a .NET Hello World App?

#### Ejemplo de la creaci�n de un proyecto simple de consola

*Crear una soluci�n (dentro del mismo directorio)*
- dotnet new sln -n exampleSolution

*Crear un nuevo proyecto de consola*
- dotnet new console -o exampleConsole

*Asociar el proyecto a la soluci�n*
- dotnet sln exampleSolution.sln add ./exampleConsole/exampleConsole.csproj

*Compilar la aplicaci�n (Opcional - en el siguiente paso, cuando se corre la App, tambi�n se compila)*
- dotnet build

*Correr mi aplicaci�n*
- dotnet run -p ./exampleConsole/exampleConsole.csproj

### (D) .NET: Basic Debugging

Setup del Debugging (para VS Code)
- Desde VSCode, se puede crear la carpeta .vscode, para ello se tiene que hacer: desde la pesta�a de debugging, se ejecuta el comando "create a launch.json file".
- Opcional: en VSCode, cuando se pone play, se crea el archivo tasks.json para crear la regla build.
- Opcional: se configura launch.json: setear la variable "program".

Luego, probar y jugar con el debugger de VS Code!

### (E) .NET - Adding a Class Library

#### Ejemplo de la creaci�n de un proyecto simple de consola con una referencia a una librer�a de clase

*Crear una soluci�n (dentro del mismo directorio)*
- dotnet new sln -n exampleSolution

*Crear un proyecto de consola*
- dotnet new console -o exampleConsole

*Crear una librer�a de clase*
- dotnet new classlib -o exampleLibrary

*Asociar los proyectos a la soluci�n*
- dotnet sln exampleSolution.sln add ./exampleConsole/exampleConsole.csproj
- dotnet sln exampleSolution.sln add ./exampleLibrary/exampleLibrary.csproj

*Agregar la referencia del proyecto de consola a la librer�a*
- dotnet add ./exampleConsole/exampleConsole.csproj reference ./exampleLibrary/exampleLibrary.csproj

*Correr*
- dotnet run -p ./exampleConsole/exampleConsole.csproj

*/exampleLibrary/MyLibrary.cs:*
```
using System;
namespace exampleLibrary
{
    public class MyLibrary
    {
      public static string Message()
      {
        return "Mensaje";
      }
    }
}
```

*/exampleConsole/Program.cs*
```
using System;
using exampleLibrary;
namespace exampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = MyLibrary.Message();
            Console.WriteLine("Hello World!");
            Console.WriteLine(message);
        }
    }
}
```

### (F) .NET - Using a NuGet Package
NuGet: un Package Manager

*Al proyecto del caso anterior (E), agregamos una librer�a de un tercero:*
- dotnet add ./exampleLibrary/exampleLibrary.csproj package Humanizer.Core

*Cambiar el contenido de este archivo: /exampleLibrary/MyLibrary.cs:*
```
using System;
using Humanizer;
namespace exampleLibrary
{
    public class MyLibrary
    {
      public static string Message()
      {
        return 120.ToWords();
      }
    }
}
```

### (G) .NET - Unit Testing

*Al proyecto del caso (E) o (F), creamos una proyecto de pruebas.*
- dotnet new xunit -o exampleTestProject

*Para ejecutar el proyecto de pruebas.*
- dotnet test ./exampleTestProject/exampleTestProject.csproj

*/exampleTestProject/UnitTest1.cs*
```
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
```

*En el video juega con las distintas formas de escribir un Test.*

### (H) .NET - Publishing an App

#### Para publicar una release para Window$:

*Standard way:*
- dotnet publish -c Release -r win-x64

*My way:*
- dotnet publish -c Release -r win-x64 -o ./MyRelease exampleSolution.sln

-----------------------------

## Segunda submisi�n: revisar el material y realizar las actividades de "Net Academy Web Api & NetCore Into"

__En este caso, se divide en una parte te�rica y una parte pr�ctica.__

### Parte te�rica

Web Api (.Net Framework)
- What is Web Api [Fuente: https://www.tutorialsteacher.com/webapi/what-is-web-api]
- Create Web Api Project [Fuente: https://www.tutorialsteacher.com/webapi/create-web-api-project]
- Test Web Api [Fuente: https://www.tutorialsteacher.com/webapi/test-web-api]
- Controllers [Fuente: https://www.tutorialsteacher.com/webapi/web-api-controller]
- Routing [Fuente: https://www.tutorialsteacher.com/webapi/web-api-routing]

Net Core & Web Api Core
- Overview [Fuente: https://www.tutorialsteacher.com/core/dotnet-core]
- ASP.Net Core [Fuente: https://www.tutorialsteacher.com/core/aspnet-core-introduction]
- Install Net Core [Fuente: https://www.tutorialsteacher.com/core/aspnet-core-environment-setup]
  - Please check in your environment you version is updated to 3.1
- ASP.Net Core Project [Fuente: https://www.tutorialsteacher.com/core/first-aspnet-core-application]
- ASP.Net Project Structure [Fuente: https://www.tutorialsteacher.com/core/aspnet-core-application-project-structure]
  Please include subSections wwwroot, startup, program
- Command Line Interface (CLI) [Fuente: https://www.tutorialsteacher.com/core/net-core-command-line-interface]

### Parte pr�ctica

Se divive en dos partes:
- Web Api & Net Core - Challenges After this lesson
- Net Community - Net Core Training

En la __primer parte__, "Web Api & Net Core - Challenges After this lesson", se relevaron estas tareas:
- [x] Crear una primera aplicaci�n base con Web Api Core. Consiste en realizar el paso a paso de:
  - [Fuente: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio-code#add-a-database-context-2]
- [x] Descargarse el proyecto base del repo de Globant e identificar la arquitectura de la aplicaci�n.
  - Startup process
  - Relation and communication among layers
  - Controllers
  - How data access is implemented
- [x] Correr la aplicaci�n en VS y testearla usando Postman.
- [x] Correr la aplicaci�n desde la consola y testearla usando Postman.

En la __segunda parte__, "Net Community - Net Core Training", se relev� lo siguiente: hay varios branches, algunos con documentaci�n, algunos con commits acerca del tema que toca cada branch. �stos son los branches con la informaci�n que se encontr�:
- [ ] Master - Hay documentaci�n general (de varios temas)
- [ ] Dependency Injection - No hay documentaci�n, pero hay unos commits con algo de c�digo
- [ ] Unit Tests - Hay documentaci�n, hay unit test en el c�digo.
- [ ] Filters - No hay documentaci�n, en el commit realizado no veo filters aplicados
- [ ] Security - No hay documentaci�n, en el commit hay una configuraci�n de JWT pero no se usa
- [ ] Docker - Hay documentaci�n, hay un commit relacionado a Docker.

**Lo que toca hacer es revisar estos branches para comprobar su funcionamiento**

-- Contenido de la parte te�rica (el material se basa en .NET Framework y no en .NET Core)

Web Api
- What is Web Api
  - API: is a set of subroutine definitions, protocols, and tools for building software and applications. To put it in simple terms, API is some kind of interface which has a set of functions that allow programmers to access specific features or data of an application, operating system or other services.
  - Web API: is an API over the web which can be accessed using HTTP protocol. It is a concept and not a technology. We can build Web API using different technologies such as Java, .NET etc.
  - ASP.NET Web API: The ASP.NET Web API is an extensible framework for building HTTP Apps based services that can be accessed in different applications on different platforms such as web, windows, mobile etc. It only supports HTTP protocol. Some characteristics:
    - for building RESTful services.
    - supports ASP.NET request/response pipeline.
    - maps HTTP verbs (POST, GET, PUT, PATCH, and DELETE => create, read, update, and delete) to method names.
    - supports different formats of response data (built-in support for JSON, XML, BSON format.).
    - includes new HttpClient to communicate with Web API server.
  - Main differences between ASP.NET Web API and WCF
    - Web API: Open Source. WCF: Closed Source
    - Web API: Ideal for building RESTful services. WCF: Supports RESTful services but with limitations.
    - Web API: Does not support Reliable Messaging and transaction. WCF: Supports Reliable Messaging and Transactions.
    - Web API: Web API can be configured using HttpConfiguration class but not in web.config. WCF: Uses web.config and attributes to configure a service.
  - When to choose ASP.NET Web API?
    - if you are using .NET framework 4.0 or above.
    - when you need to build RESTful HTTP based services.
  - Tambi�n se explica la diferencia entre WCF y Web API.
    
- Create Web Api Project (basado en .Net Framework y VS)
  - Creaci�n de un proyecto Web API con un proyecto MVC.
    - En VS, ir al men�: File -> New Project.. Luego en los templates, elegir Visual C# -> Web -> ASP.NET Web Application. Cuando pide el tipo de Template, seleccionar "Web API" (dado que est�n deshabilitados los checkboxes "MVC" y "Web API", va a agregar las carpetas y referencias para MVC y Web API).
  - Creaci�n de un proyecto Web API son MVC (standalone).
    - En VS, ir al men�: File -> New Project.. Luego en los templates, elegir Visual C# -> Web -> ASP.NET Web Application. Cuando pide el tipo de Template, seleccionar "Empty". Finalmente, con el Manage NuGet Packages, elegir "Microsoft ASP.NET Web API 2.2" e instalar.
    
- Test Web Api
  - Fiddler: es una debuger para generar HTTP request a una Web API y comprobar su respuesta.
  - Postman: herramienta gratuita que permite la prueba de APIs con la realizaci�n de HTTP requests. Se puede instalar en los browsers (como en Chrome), aunque tambi�n est� la versi�n standalone.

- Controllers
  - Web API Controller es similar a ASP.NET MVC Controller en el sentido que maneja requests HTTP entrantes y env�a una respuesta al que lo llam�. A diferencia de MVC que est� especializado en renderizar vistas, Web API est� orientado a devolver datos. En el caso de la Web API Controller, las clases tienen que heredar de System.Web.Http.ApiController y su nombre tiene que terminar con Controller. Con esta herencia se pueden usar m�todos de acci�n cuyos nombres coiniciden con HTTP verbs como Get, Post, Put y Delete. Se suele usar en los m�todos, los atributos: HttpGet, HttpPost, HttpPut, etc. para que la librer�a decida qu� tipo de HTTP Request enviar. Es recomendable usar nombres claros en los m�todos por m�s que tengamos la libertad de usar cualquiera, por ejemplo, el m�todo Get puede ser GetAllNames(), GetStudents() o cualquier otro nombre que empiece con Get.
    - GET .. Retrieves data.
    - POST .. Inserts new record.
    - PUT .. Updates (overwrite) existing record.
    - PATCH .. Updates record partially.
    - DELETE .. Deletes record.

- Routing
  - El routing de Web API es similar al de ASP.NET MVC. Suporta dos tipos de routing: Convention-based Routing y Attribute Routing.

.NET Core
- Overview
  - Free, cross-platform, open-source, general-purpose development platform maintained by Microsoft.
  - Caracter�sticas: Supports Multiple Languages (C#, F# y Visual Basic), Various types of applications can be developed and run on .NET Core platform (mobile, desktop, web, cloud, IoT, machine learning, microservices, game, etc.), Consistent across Architectures (Execute the code with the same behavior in different instruction set architectures, like x64, x86, and ARM), Modular Architecture (.NET Core supports modular architecture approach using NuGet packages), CLI Tools, Flexible Deployment.

ASP.NET Core
- Overview
  - ASP.NET Core is the new version of the ASP.NET web framework mainly targeted to run on .NET Core platform.
  - Caracter�sticas: cross-platform, fast, built-in IoC container, can be hosted on multiple platforms with any web server (IIS, Apache, etc.).

- Install Net Core
  - .NET Core can be installed in two ways: By installing Visual Studio 2017/2019 or by installing .NET Core Runtime or SDK.
  - .NET Core installer already contains ASP.NET Core libraries
  - Please check in your environment you version is updated to 3.1
  
- ASP.NET Core Project
  - Explica c�mo se crea un proyecto ASP.NET Core en Visual Studio, lo m�s importante: seleccionar la versi�n correcta del dotnet core, el template correcto. Luego, realiza un Restore de los paquetes NuGet. Finalmente, para correr la APP: CTRL + F5
  - En la consola se pueden levantar un template, un proyecto ASP.NET Core con el comando:
    dotnet new webapp -o example-webapp

- ASP.NET Project Structure
  - .csproj: a partir de ASP.NET Core 2.0, VS usa el archivo .csproj para manejar proyectos. Algunos de los settings inclu�dos en este archivo: versi�n target del .NET Framework, carpetas del proyecto, referencias a los paquetes NuGets, etc.
  - Dependencies: en los proyectos de ASP.NET Core 2.1, contiene todos los paquetes NuGet instalados.
    - Para mostrar los paquetes instalados, desde la consola: dotnet list [filename].sln package
    - Para (re)instalar los paquetes: dotnet restore
  - Properties: en esta secci�n se encuentra el archivo launchSettings.json contiene settings que se usan en VS (profiles de ejecuci�n en el Debug, settings para el IIS, entre otros). Los profiles se pueden editar desde las propiedades del proyecto, en la pesta�a "Debug".
  
  - wwwroot: es el root de la aplicaci�n, es una carpeta p�blica y visible al usuario, ac� pueden ir los archivos est�ticos (o en una subcarpeta, generalmente se crean carpetas con los nombres "css", "html" y "js"). Para servir archivos est�ticos se debe configurar el middleware e instalar "Microsoft.AspNetCore.StaticFiles".
  - Program.cs (archivo en ubicado en la ra�z del proyecto): es la entrada a la aplicaci�n en donde se crea el host para la aplicaci�n web. Cuando se crear el proyecto por consola, se autogenera por el template (webapp o mvc) que se aplica. Por defecto, el m�todo CreateDefaultBuilder, internamente configura Kestrel (un web server para ASP.NET Core multiplataforma y open-source), la integraci�n con IIS, el directorio ra�z y otras configuraciones. Tambi�n, se encuentran invocaciones a ConfigureAppConfiguration que carga configuraciones de archivos   appsettings.json, variables de ambiente y "user secrets", y finalmente, se encuentra la invocaci�n a ConfigureLogging que es el setup de logging para la consola y la ventana "debug".
  - Startup.cs (archivo en ubicado en la ra�z del proyecto): es parecido al global.asax, se ejecuta ni bien arranca la aplicaci�n. Se configura en el program.cs, con la invocaci�n al m�todo UseStartup<T>(). La clase Startup contiene dos m�todos importantes: ConfigureServices y Configure.
    - ConfigureServices: en este m�todo se agregan los servicios al contenedor de IoC y todo el tema de la Inyecci�n por Dependencias. Despu�s de registrar la clase, se puede usar en cualquier lugar de la aplicaci�n.
    - Configure: en este m�todo se puede configurar el Middleware (HTTP request pipeline) para que se pueda ejecutar en cada request. 
    - El m�todo ConfigureServices se llama antes que el m�todo Configure, de modo que los servicios registrados en el contenedor de IoC se pueden usar en el m�todo Configure.

- Command Line Interface (CLI)
  - Vimos varios comandos en secciones pasadas.
  
### Apendice A - Instalar Local DB

**Instalar localDB (cualquier cosa, ver la fuente)**
- Descargar la versi�n Express desde:
    - https://www.microsoft.com/es-es/sql-server/sql-server-downloads
- Luego cuando se ejecuta el instalador, usar la opci�n "Download Media" y elegir la opci�n de "LocalDB" para descargar el instalador
- Finalmente, tenemos al instalador que es sencillo de usar.

**Obtener la Instancia**
- sqllocaldb info

**Toda la info de la instancia**
- SqlLocalDB.exe info MSSQLLocalDB

**Arrancar la instancia**
- SqlLocalDB.exe start MSSQLLocalDB

**Parar la instancia**
- SqlLocalDB.exe stop MSSQLLocalDB

**Server name**
- (LocalDB)\MSSQLLocalDB

[Fuente: https://www.jasoft.org/Blog/post/que-es-sql-server-localdb-como-instalarlo-usarlo-y-actualizarlo]

