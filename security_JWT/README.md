# JWT con ASP.NET, probando con Swagger

Comandos a ejecutar
----

## Compilar

dotnet build

## Correr

dotnet run -p 

## Para generar un certificado de Dev para HTTPS

dotnet dev-certs https

## Para probar con Swagger

https://localhost:5001/swagger/index.html

## Desde Swagger:

- Ejecutar el endpoint /api/Authenticate/Login con el usuario Jesus y password 123456
- Copiar el token y pegarlo cuando se hace click arriba en el botón Authorize (anteponiendo "Bearer ").
- Listo, ahora se va a poder probar el endpoint /api/Authenticate/Get porque ya estamos autorizados.

## Un poco más:

Se puede revisar de qué se componen los tokens con esta herramienta: https://jwt.io/

Links
----

https://medium.com/nerd-for-tech/authentication-and-authorization-in-net-core-web-api-using-jwt-token-and-swagger-ui-cc8d05aef03c
https://github.com/JayKrishnareddy/AuthenticationandAuthorization/tree/master/AuthenticationandAuthorization
https://medium.com/@sajadshafi/jwt-authentication-in-c-net-core-7-web-api-b825b3aee11d

Ver:
----
- Claims ... Incluir algunos claims
- Expiration date ... Done, se configuró el JWT.
- Usar el Authorize ... Done.
- Integrar con Angular... Debe mantener el token en LocalStorage

#### Qué es json web token y cómo funciona:

https://www.youtube.com/watch?v=qXJ9jV-0wQ4

### Temas laterales que se tocaron en el trabajo de este proyecto:

- El orden de los Middlewares que se ejecutan en Startup.cs:
https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-8.0
https://stackoverflow.com/questions/59971144/is-there-a-mandatory-order-of-statements-in-the-configure-method-of-a-asp-net-co


