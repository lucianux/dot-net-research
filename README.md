# Comandos de consola

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
