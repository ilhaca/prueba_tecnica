# API REST en .NET Core
Esta desarrollado en .NET Core 3.1 y Entity Framework Core con la arquitectura DDD, donde aplico conceptos de buenas practicas y algunos patrones de diseño.

### Conceptos, Tecnologias, Herramientas Aplicados en el proyecto:

* Clean Code
* Patron de diseño Repository
* Inyeccion de dependencias
* Unit Test 
* arquitectura DDD

### Pasos a seguir para ejecutar el proyecto

Una vez descargado, simplemente ejecutar la Api para poder tener activo el Backend

A continuación con algun programa tipo Postman, pueden hacerse peticiónes a los endpoints siguientes
POST:https://localhost:44375/api/inventory/ - Añadir en el cuerpo un json ej: 
{
    "Name" : "Illán",
    "Description" : "Description"
}
GET: https://localhost:44375/api/inventory/all
GET: https://localhost:44375/api/inventory/?id=1

### Siguientes pasos de desarrollo:
* AutoMapper - He inicializado la clase pero no me ha dado tiempo a hacer una implementación lógica
* Constantes de proyecto - hubiera sido ideal algunos datos hardcodeados hacerlos constantes globales de proyecto para una estructuración mas limpia
* Swagger - Implementar el swagger a traves de inyeccion de dependencias en la startup

### Paquetes de terceros utilizados:
* Microsoft.EntityFrameworkCore - base de datos en memoria y modelos de base de datos

