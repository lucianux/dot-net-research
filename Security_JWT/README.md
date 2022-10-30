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

Links
----

https://medium.com/nerd-for-tech/authentication-and-authorization-in-net-core-web-api-using-jwt-token-and-swagger-ui-cc8d05aef03c
https://github.com/JayKrishnareddy/AuthenticationandAuthorization/tree/master/AuthenticationandAuthorization
