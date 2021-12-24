# Dependency Injection

## Para ejecutarlo

dotnet run -p ./exampleDI/exampleDI.csproj

## Para agregar la librería de inyección de dependencias

cd exampleDI
dotnet add package Microsoft.Extensions.DependencyInjection

## Salida (consola)

Puede ser una de estas líneas:
Message example
Message example of Hello2

## Explicación

En este ejemplo hay 2 puntos a remarcar:
- Se utiliza la interface para obtener la clase concreta.
- Se puede cambiar la clase concreta (Hello y Hello2) que se obtiene a partir de la interface, desde el setup.

## Fuentes

https://aspnetcoremaster.com/inyeccion-de-dependencias-asp-net-core.html // Es una buena introducción

https://dev.to/ebarrioscode/inyeccion-de-dependencias-di-en-asp-net-core-mejores-practicas-para-escribir-codigo-reutilizable-escalable-y-desacoplado-kho

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0