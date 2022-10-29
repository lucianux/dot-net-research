# Docker

#### Link semilla:
#### https://learn.microsoft.com/en-us/dotnet/architecture/microservices/container-docker-introduction/

## Comandos básicos para administrar contenedores

$ sudo docker version
// Devuelve la versión del cliente y la versión del servidor

$ sudo docker run hello-world
// La primera vez que lo corremos va hacia el Docker Hub y lo descarga.
// Si lo ejecutamos por segunda vez, lo encuentra localmente y no hace falta buscarlo al repo de imágenes.

$ sudo docker ps -a
// Reviso todos los contenedores

$ sudo docker container rm 9161
// Elimino un contenedor específico de Docker que empieza con el ID "9161" 

## Creando una ejemplo sencillo de una aplicación dotnet dentro de un contenedor Docker

*Crear una solución (dentro del mismo directorio)*
- dotnet new sln -n exampleSolution

*Crear un proyecto de consola*
- dotnet new console -o exampleConsole

*Asociar el proyecto a la solución*
- dotnet sln exampleSolution.sln add ./exampleConsole/exampleConsole.csproj

*Hacer una pequeña prueba, corriend la aplicación*
- dotnet run -p ./exampleConsole/exampleConsole.csproj

*Creando la imagen*
- sudo docker build -t helloworld:v1 .

*Revisando las imagenes*
- sudo docker images -f reference=helloworld

*Levantando la imagen recién creada*
- sudo docker run helloworld:v1

*Revisando todos los contenedores:*
- sudo docker ps -a

Links
-----

https://hub.docker.com/_/microsoft-dotnet-core

