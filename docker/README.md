# Docker

## Bases

Docker es una herramienta que automatiza el despliegue de aplicaciones dentro de contenedores de software, proporcionando una capa adicional de abstracción y automatización de virtualización de aplicaciones en múltiples sistemas operativos.

### Contenedores

Los contenedores funcionan como una unidad estándar de despliegue, los cuales pueden contener diferentes códigos fuente y dependencias. Una ventaja es que permite a los desarrolladores cambiar de ambiente con pocas o ninguna modificación en el paquete de transporte.
Los contenedores son aplicaciones aisladas adentro de un Sistema Operativo compartido. Con los contenedores, los recursos pueden ser aislados, los servicios restringidos, y se otorga a los procesos la capacidad de tener una visión casi completamente privada del sistema operativo con su propio identificador de espacio de proceso, la estructura del sistema de archivos, y las interfaces de red.
Otro beneficio es la escalabilidad: se puede escalar rápidamente creando nuevos contenedores para tareas a corto plazo. Desde el punto de vista de una aplicación, instanciar una imagen (crear un contenedor) es similar a instanciar un proceso como un servicio o una web app.
En resumen, los contenedores ofrecen beneficios como el aislamiento, la portabilidad, la agilidad, la escalabilidad y el control en todo el flujo de trabajo del ciclo de vida de la aplicación.

### Imágenes

Pero antes del contenedor, está la imagen del contenedor. Éste es un paquete con todas las dependencias e información necesaria para crear un contenedor. O sea, una imagen incluye todas las dependencias (como los frameworks) más la configuración de su ejecución y despliegue que usará un contenedor a la hora de correrlo. Usualmente, una imagen se compone de varias imágenes base que son capas apiladas una encima de la otra para formar el sistema de archivos del contenedor. Una imagen es inmutable una vez que ha sido creada, es un artefacto estático, no así el contenedor que es una instancia de una imagen, artefacto activo y dinámico.

Hay dos formas de obtener una imagen, una es mediante un Registry y otra es construyendo una por Dockerfile. En la primer opción, se usa un Registry que es un servicio que provee acceso a imágenes de Docker; el que se usa casi siempre es Docker Hub. En la segunda opción, se usa un Dockerfile que es un archivo de texto que contiene instrucciones para construir una imagen Docker, es como un script batch.

### Compose

Docker Compose es una herramienta para definir y levantar aplicaciones Docker con múltiples contenedores. Usa archivos YAML para configurar los servicios de la aplicación, realiza el proceso de creación y arranque de todos los contenedores con un sólo comando. Con Compose puedes crear diferentes contenedores y al mismo tiempo, en cada contenedor, diferentes servicios, unirlos a un volúmen común, iniciarlos y apagarlos, etc.
En vez de utilizar Docker via una serie inmemorizable de comandos bash y scripts, Docker Compose te permite mediante archivos YAML para poder instruir al Docker Engine a realizar tareas, programaticamente. Y esta es la clave, la facilidad para dar una serie de instrucciones, y luego repetirlas en diferentes ambientes.

# Demo

## Comandos básicos para administrar contenedores e imágenes

$ sudo docker version
// Devuelve la versión del cliente y la versión del servidor

$ sudo docker run hello-world
// La primera vez que lo corremos va hacia el Docker Hub y lo descarga.
// Si lo ejecutamos por segunda vez, lo encuentra localmente y no hace falta buscarlo al repo de imágenes.

$ sudo docker ps -a
// Reviso todos los contenedores

$ sudo docker container rm 9161
// Elimino un contenedor específico de Docker que empieza con el ID "9161" 

$ sudo docker images -a
// Listar todas las imágenes

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
- sudo docker image ls

*Levantando la imagen recién creada*
- sudo docker run helloworld:v1

*Revisando todos los contenedores:*
- sudo docker ps -a

## Apendice A - Más comandos Docker que pueden servir

*Borrando todos los contenedores*
- sudo docker rm $(sudo docker ps -aq)

*Limpiando recursos que no se usan*
- sudo docker system prune -a

*Borrando volumenes sin usar*
- sudo docker volume prune

*Borrando todas las imagenes*
- sudo docker rmi $(sudo docker images -q)

*Ver logs:*
- sudo docker logs {CONTAINER_ID}

*Acceder al Filesystem de un contenedor:*
- sudo docker exec -t -i 897 /bin/bash

## Apendice B - Comandos de Docker Compose

*Para levantar todo*
- docker compose up --build -d

*Para bajar todo lo levantado*
- docker-compose down

# Links

- https://en.wikipedia.org/wiki/Docker_(software)

- https://hub.docker.com/_/microsoft-dotnet-core

- https://learn.microsoft.com/en-us/dotnet/architecture/microservices/container-docker-introduction/docker-terminology

