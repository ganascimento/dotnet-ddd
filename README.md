# Dotnet MediatR

## About

This is a project template using MediatR and Microsoft's best suggestions

## Resources

- EF Core
- OData 8
- AutoMapper
- Mediatr
- SqlServer
- Identity
- JWT

## What is Mediator?

The Mediator design pattern is a behavioral pattern in software engineering that promotes loose coupling between components in a system. It centralizes communication between these components through a mediator object, rather than having them communicate directly. This mediator acts as an intermediary, facilitating interactions and reducing the dependencies between components. It enhances maintainability and extensibility, making it easier to add or modify components without affecting others. This pattern is commonly used in complex systems like graphical user interfaces, where multiple objects need to collaborate without excessive interconnections. It promotes a more organized and manageable structure, improving the overall system's scalability and flexibility

## And the lib MediatR?

MediatR is a popular open-source library in the .NET ecosystem that simplifies the implementation of the Mediator design pattern. It provides a framework for handling requests and coordinating communication between different parts of an application. Developers can use MediatR to decouple components, making it easier to organize and manage the flow of data and actions

<p align="start" style="margin-left: 30px">
  <img src="./assets/mediatr.png" width="100" />
</p>

## Test

To run this project you need docker installed on your machine, see the docker documentation [here](https://www.docker.com/).

Having all the resources installed, run the command in a terminal from the root folder of the project and wait some seconds to build project image and download the resources: `docker-compose up -d`

In terminal show this:

```console
[+] Running 3/3
 ✔ Network dotnet-mediatr_app_network    Created                          0.9s
 ✔ Container dotnet-mediatr-sqlserver-1  Started                          1.5s
 ✔ Container mediatr_app                 Started                          2.9s
```

After this, access the link below:

- Swagger project [click here](http://localhost:5000/swagger)

### Stop Application

To stop, run: `docker-compose down`
