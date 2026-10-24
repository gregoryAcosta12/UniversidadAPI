<div align="center">

# 🎓 UniversidadAPI - Backend Core Enterprise

### 🏗️ Sistema de Gestión Universitaria de Alto Rendimiento y Escalabilidad

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![JWT](https://img.shields.io/badge/Security-JWT_Bearer-000000?style=for-the-badge&logo=json-web-tokens&logoColor=white)]()
[![SQL Server](https://img.shields.io/badge/SQL_Server-Entity_Framework-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)]()

<br />

> 🏛️ **Arquitectura:** N-Capas (N-Tier) / Clean Architecture
> 🔐 **Seguridad:** Autenticación basada en Roles (RBAC) con JSON Web Tokens.
> ⚡ **Rendimiento:** Asincronismo completo (Async/Await) y consultas optimizadas.

</div>

---

## 📖 Tabla de Contenidos

1. [Filosofía del Proyecto](#-filosofía-del-proyecto)
2. [Arquitectura del Sistema (N-Capas)](#-arquitectura-del-sistema-n-capas)
3. [Desglose Técnico de las Capas](#-desglose-técnico-de-las-capas)
4. [Seguridad, JWT y RBAC](#-seguridad-jwt-y-rbac)
5. [Diagrama Entidad-Relación (ER)](#-diagrama-entidad-relación-er)
6. [Manejo Global de Errores](#-manejo-global-de-errores)
7. [Stack Tecnológico](#-stack-tecnológico)
8. [Guía de Instalación y Despliegue](#-guía-de-instalación-y-despliegue)

---

## 🧠 Filosofía del Proyecto

Este no es un backend monolítico tradicional. Fue diseñado desde cero bajo los principios de **Clean Architecture** (Arquitectura Limpia) y **Domain-Driven Design (DDD)** simplificado. 

El objetivo principal es garantizar que el sistema pueda crecer sin volverse inmantenible. **Las reglas de negocio están aisladas de la base de datos y de la interfaz HTTP.** Si mañana la universidad decide cambiar SQL Server por PostgreSQL o migrar a una arquitectura de microservicios, la capa de negocio (`Business`) no tendrá que cambiar ni una sola línea de código.

---

## 🏗️ Arquitectura del Sistema (N-Capas)

El sistema está dividido en **5 proyectos interdependientes** con un flujo de dependencias unidireccional (de afuera hacia adentro):

```text
UniversidadAPI (Solución)
│
├── 📦 UniversidadAPI.Entities      # 1. Dominio (El núcleo)
├── 🗄️ UniversidadAPI.DataAccess    # 2. Persistencia de Datos
├── ⚙️ UniversidadAPI.Business      # 3. Lógica de Negocio
├── 🛡️ UniversidadAPI.Infrastructure # 4. Servicios Transversales
└── 🚀 UniversidadAPI.Presentation  # 5. API REST (Capa expuesta)


Desglose Técnico de las Capas
1. 📦 UniversidadAPI.Entities (Capa de Dominio)
Es el corazón del software. No depende de absolutamente nada (ni siquiera de Entity Framework).

POCOs (Plain Old CLR Objects): Clases puras de C# como Estudiante, Profesor, Materia.

Reglas de Dominio Básicas: Relaciones de navegación (ej. Un Estudiante tiene muchas Inscripciones).

Interfaces de Repositorio: Define los contratos (ej. IEstudianteRepository) pero no su implementación. Esto permite aplicar Inversión de Dependencias (el principio "D" de SOLID).

2. 🗄️ UniversidadAPI.DataAccess (Capa de Persistencia)
Aquí vive Entity Framework Core. Se encarga de traducir los objetos de C# a tablas de SQL Server.

DbContext: UniversidadDbContext configura las entidades, llaves primarias, foráneas y relaciones Many-to-Many (ej. Estudiante - Materia).

Repositorios: Implementan las interfaces de Entities. Usan LINQ to Entities y métodos asíncronos (ToListAsync, FirstOrDefaultAsync) para no bloquear los hilos del servidor.

Seed Data: Contiene la lógica para poblar la base de datos con roles iniciales y usuarios de prueba (Admin, Profesor, Estudiante) al crear la DB por primera vez.

3. ⚙️ UniversidadAPI.Business (Capa de Negocio)
El cerebro del sistema. Aquí ocurren las validaciones complejas.

Services: Implementan las reglas de negocio. Ejemplo: Al inscribir a un estudiante, el InscripcionService verifica que no exceda los 18 créditos, que la materia tenga cupos disponibles y que no esté ya inscrito.

DTOs (Data Transfer Objects): Objetos como EstudianteCreateDto, EstudianteResponseDto. Evitan exponer la entidad de la base de datos directamente al frontend (previniendo Overposting attacks).

AutoMapper: Traduce automáticamente de Entity a DTO y viceversa.

FluentValidation: Valida los DTOs (ej. "El email debe tener formato válido", "La contraseña debe tener 8 caracteres") antes de llegar al controlador.

4. 🛡️ UniversidadAPI.Infrastructure (Servicios Transversales)
Contiene herramientas que dan soporte a toda la app pero no son lógica de negocio pura.

JwtGenerator: Clase encargada de crear el Token con los Claims del usuario.

PasswordHasher: Implementación de BCrypt para encriptar contraseñas (Nunca se guarda texto plano).

GlobalExceptionMiddleware: Intercepta cualquier error no controlado y devuelve un JSON estandarizado en lugar de una pantalla de error HTML de IIS.

DependencyInjection: Extensión AddInfrastructure() que registra todos los servicios de esta capa.

5. 🚀 UniversidadAPI.Presentation (Capa de Presentación)
Es una API RESTful. No renderiza HTML, solo devuelve JSON.

Controllers: Reciben las peticiones HTTP, validan el modelo (ModelState.IsValid), llaman al Service y devuelven los códigos de estado correctos (200 OK, 201 Created, 400 BadRequest, 401 Unauthorized, 404 NotFound).

Swagger / OpenAPI: Documentación viva. Cada controlador tiene anotaciones [ProducesResponseType] para que el frontend sepa qué esperar.

🔐 Seguridad y Autenticación (JWT + RBAC)
La API está protegida mediante el estándar industrial JWT (JSON Web Tokens). Ningún endpoint sensible es accesible sin un token válido.

🔄 Flujo de Autenticación Completo
Login: El Frontend envía { username, password } a POST /api/Auth/login.

Validación: La capa Business busca al usuario en la DB y compara la contraseña usando BCrypt.Verify().

Generación de Token: Si es correcto, Infrastructure genera un JWT firmado con una clave secreta (HMAC SHA256) que incluye Claims:

sub (ID del usuario)

name (Nombre de usuario)

role (ADMIN, PROFESOR, ESTUDIANTE)

exp (Fecha de expiración, usualmente 2 horas).

Autorización: El Frontend envía el token en el header: Authorization: Bearer <token>.

Validación en Middleware: El middleware de ASP.NET Core valida la firma del token y extrae el rol.
