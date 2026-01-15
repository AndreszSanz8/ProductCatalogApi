
API REST para la gestión de un catálogo de productos y su stock, desarrollada como parte de una prueba técnica backend.
La solución está diseñada siguiendo buenas prácticas, principios de Clean Architecture y preparada para ser replicable, mantenible y lista para producción.

Proveer una API que permita:
Administrar productos
Consultar información de catálogo
Controlar y actualizar stock
Exponer endpoints claros y consistentes para consumo por aplicaciones web, móviles u otros servicios
El foco de la solución está en la calidad técnica, claridad del diseño y facilidad de despliegue.

La solución está organizada siguiendo Clean Architecture, separando responsabilidades en capas bien definidas:
Api_ProductCatalog
│
├── Api_ProductCatalog.Api           → Capa de presentación (Controllers, Swagger)
├── Api_ProductCatalog.Application   → Casos de uso, DTOs, servicios, validaciones
├── Api_ProductCatalog.Domain        → Entidades y contratos de dominio
├── Api_ProductCatalog.Infrastructure→ Persistencia (EF Core, Repositorios)
└── tests
    ├── Api_ProductCatalog.Api.UnitTests
    └── Api_ProductCatalog.Application.UnitTests
Beneficios de esta arquitectura
Bajo acoplamiento
Alta testabilidad
Independencia de base de datos e infraestructura
Fácil escalabilidad y mantenimiento

.NET 8
ASP.NET Core Web API
Entity Framework Core
SQL Server (agnóstico a proveedor)
FluentValidation
Swagger / OpenAPI
xUnit + Moq (tests unitarios)

Product
- Id
- Name
- Description
- Price
- Stock
- IsActive

La eliminación de productos se maneja como eliminación lógica (IsActive).

Método	Endpoint	Descripción
POST	/api/products	Crear un producto
GET	/api/products	Listar productos
GET	/api/products/{id}	Obtener producto por ID
PATCH	/api/products/{id}/stock	Actualizar stock
DELETE	/api/products/{id}	Eliminar producto
Todos los contratos request/response están definidos mediante DTOs.

Las validaciones de entrada se realizan con FluentValidation, separadas del controlador, por ejemplo:
Nombre obligatorio
Precio mayor a 0
Stock no negativo
Esto garantiza:
Controladores limpios
Errores consistentes
Validaciones centralizadas

Se incluyen pruebas unitarias para:
Servicios de aplicación
Controladores API
Herramientas utilizadas:
xUnit
Moq
Las pruebas están organizadas dentro de la carpeta tests/.

La API expone documentación interactiva mediante Swagger:
https://localhost:{puerto}/swagger

Incluye:
Descripción de endpoints
Tipos de datos
Códigos de respuesta
Ejemplos de uso

1️⃣ Clonar repositorio
git clone https://github.com/AndreszSanz8/ProductCatalogApi.git
cd ProductCatalogApi
2️⃣ Configurar conexión a base de datos
En appsettings.json:
{
  "ConnectionStrings": {
    "Default": "Server=.;Database=ProductCatalogDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}

dotnet ef database update \
--project Api_ProductCatalog.Infrastructure \
--startup-project Api_ProductCatalog.Api
4️⃣ Ejecutar la API
dotnet run --project Api_ProductCatalog.Api

La solución es agnóstica a infraestructura, preparada para ser desplegada en:
Azure
AWS
Contenedores Docker
Entornos on-premise

Clean Architecture para separación de responsabilidades
EF Core como ORM por productividad y control
Eliminación lógica para trazabilidad
Validaciones desacopladas del controlador
Diseño orientado a pruebas

Decisiones técnicas
Arquitectura limpia para desacoplar dominio
EF Core por rapidez y mantenibilidad
FluentValidation para validación temprana
Swagger para documentación viva
 

Andrés Sanz
Backend Developer
Prueba técnica – Fundación delamujer