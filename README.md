1. Product Catalog API



API REST para la gestión de productos, desarrollada con .NET 8, Arquitectura Limpia, Entity Framework Core y SQLite.

Incluye documentación con Swagger y está desplegada en la nube mediante Docker.



2\. Demo en producción



3\. Swagger UI:

https://productcatalogapi-6kwr.onrender.com/swagger



4\. Arquitectura



El proyecto sigue una Arquitectura Limpia con separación de responsabilidades:



Api\_ProductCatalog.Domain

Api\_ProductCatalog.Application

Api\_ProductCatalog.Infrastructure

Api\_ProductCatalog.Api





Domain: Entidades y reglas de negocio



Application: Servicios, DTOs y lógica de aplicación



Infrastructure: Acceso a datos (EF Core, SQLite)



Api: Controladores, middlewares y configuración



5\. Tecnologías usadas



.NET 8



ASP.NET Core Web API



Entity Framework Core



SQLite



Docker



Swagger



GitHub + Render



6\. Base de datos



Se utiliza SQLite para facilitar el despliegue en la nube sin depender de infraestructura externa.



La base de datos se genera automáticamente mediante migraciones de EF Core.



7\. Cómo ejecutar el proyecto localmente

7.1. Clonar el repositorio

git clone https://github.com/AndreszSanz8/ProductCatalogApi.git

cd ProductCatalogApi



7.2. Restaurar dependencias

dotnet restore



7.3. Ejecutar migraciones

dotnet ef database update \\

&nbsp; --project Api\_ProductCatalog.Infrastructure \\

&nbsp; --startup-project Api\_ProductCatalog.Api



7.4. Ejecutar la API

dotnet run --project Api\_ProductCatalog.Api



7.5. Abrir Swagger

https://localhost:5001/swagger



8\. Endpoints principales

Método	Ruta			Descripción

POST	/api/products		Crear producto

GET	/api/products		Listar productos

GET	/api/products/{id}	Obtener producto

DELETE	/api/products/{id}	Eliminar producto

PUT	/api/products/{id}	Actualizar producto



9\. Validaciones



Se aplican validaciones mediante DataAnnotations:



Campos obligatorios



Longitud máxima



Rangos de valores



Esto garantiza integridad de datos.



10\. Despliegue



La aplicación está desplegada en Render usando:



Docker



SQLite



Puerto dinámico



11\. Autor



Jhoan Andrés Prieto Sánchez

Desarrollador Full Stack .NET

GitHub: https://github.com/AndreszSanz8

