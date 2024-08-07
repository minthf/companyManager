### Company Manager System

This project is designed for managing company employees

#### Architecture of application
The project consists of 4 parts:
 - Application
 - Domain
 - Infrastructure
 - WebUI

##### Domain
This layer is responsible for entities and interfaces for working with them.
##### Infrastructure
This layer is responsible for database, migrations and implementation of repositories.
##### Application
This layer is responsible for business-logic. Various services are located here
##### WebUi
This layer is responsible for the external representation.

#### Running application
The repository contains a Dockerfile and a docker-compose, you can use them to run the application using docker.
Here is example how to run application using docker-compose:
```dcoker-compose up --build```
After build you can use swagger on the link:
http://localhost:8080/swagger/index.html

You can also run the application through visual studio or dotnet run, if you have already installed PostgreSQL.
Don't forget to change your database connection strings before running!