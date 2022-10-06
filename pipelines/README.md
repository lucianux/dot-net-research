# Pipelines

## HOW-TO

Lista de cosas a realizar:
- Crear una cuenta y una organización.
- Crear un proyecto público.
- Crear un Pipeline.

## Crear una organización.
Para crear una organización, primero uno se debe loguear con la cuenta de Microsoft (...@outlook.com) o una cuenta GitHub.
https://learn.microsoft.com/en-us/azure/devops/user-guide/sign-up-invite-teammates?view=azure-devops

Generé mi workspace en https://dev.azure.com/lucianux

## Crear un proyecto público.
Crear un proyecto sencillo con nombre y descripción.
En Repo poner GIT, el resto no es relevante.
https://learn.microsoft.com/en-us/azure/devops/organizations/public/create-public-project?view=azure-devops#add-a-public-project-to-your-organization

## Crear un Pipeline.
Se debe hacer un fork en GitHub del proyecto: https://github.com/MicrosoftDocs/pipelines-dotnet-core
Luego, ir a la parte de Pipelines de Azure DevOps y seleccionar New Pipeline.
Luego, nos pide que seleccionemos la fuente de código, seleccionamos GitHub.
Luego, seleccionamos el repo que hicimos fork (previamente nos va a pedir que nos logueemos).
Luego, seleccionamos en la configuración del Pipeline, un "ASP.NET Core".
Finalmente, "Save and run".
https://learn.microsoft.com/en-us/azure/devops/pipelines/create-first-pipeline?view=azure-devops&tabs=net%2Ctfs-2018-2%2Cbrowser#create-your-first-net-core-pipeline

## Pedir un job para procesar nuestro pipeline.
Se debe llenar un form (https://aka.ms/azpipelines-parallelism-request) y esperar a que respondan el pedido (toma de 2 a 3 días hábiles según dicen).
https://stackoverflow.com/questions/68033977/errorno-hosted-parallelism-has-been-purchased-or-granted

## Teoría

Azure Pipelines automatically builds and tests code projects to make them available to others.
Azure Pipelines combines continuous integration (CI) and continuous delivery (CD) to test and build your code and ship it to any target.
- Continuous Integration (CI): is the practice used by development teams of automating merging and testing code.
- Continuous Delivery (CD) is a process by which code is built, tested, and deployed to one or more test and production environments.

Use Azure Pipelines to deploy your code to multiple targets. Targets include virtual machines, environments, containers, on-premises and cloud platforms, or PaaS services.
Once you have continuous integration in place, the next step is to create a release definition to automate the deployment of your application to one or more environments. This automation process is again defined as a collection of tasks.

