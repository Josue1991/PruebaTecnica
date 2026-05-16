# 📦 Sistema de Gestión de Inventario

> Aplicación web fullstack para gestión de inventario desarrollada con **ASP.NET Core Web API** y **Blazor WebAssembly**.

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/Blazor-WebAssembly-512BD4?logo=blazor)](https://blazor.net/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-512BD4)](https://docs.microsoft.com/ef/)
[![SQLite](https://img.shields.io/badge/SQLite-3.x-003B57?logo=sqlite)](https://www.sqlite.org/)

---

## 🚀 Tecnologías

### Backend (RestApi)
- 🔹 **ASP.NET Core 8** - Framework web moderno y de alto rendimiento
- 🔹 **Entity Framework Core** - ORM para acceso a datos
- 🔹 **SQLite** - Base de datos ligera y eficiente
- 🔹 **ASP.NET Core Identity** - Sistema de autenticación y autorización
- 🔹 **Swagger/OpenAPI** - Documentación interactiva de la API

### Frontend (Blazzor)
- 🔸 **Blazor WebAssembly** - SPA con C# en el navegador
- 🔸 **Bootstrap 5** - Framework CSS responsive
- 🔸 **MudBlazor** - Componentes UI modernos
- 🔸 **JavaScript Interop** - Sistema de notificaciones personalizado

---

## ✨ Funcionalidades

### Gestión de Productos
- ✅ **CRUD completo** de productos
- ✅ **Validación de datos** con DataAnnotations
- ✅ **Código SKU único** por producto
- ✅ **Resaltado visual** de productos con stock bajo (< 10 unidades)
- ✅ **Formato de moneda** en dólares ($)

### Control de Inventario
- 📊 **Registro de movimientos** (Compras/Ventas)
- 📊 **Historial completo** de movimientos por producto
- 📊 **Validación de stock** - Previene ventas con stock insuficiente
- 📊 **Actualización automática** del stock según tipo de movimiento

### Interfaz de Usuario
- 🎨 **Diseño responsive** compatible con dispositivos móviles
- 🎨 **Notificaciones en tiempo real** con alertas del navegador
- 🎨 **Navegación intuitiva** entre vistas
- 🎨 **Validación de formularios** en tiempo real

---

## 📁 Estructura del Proyecto

```text
PruebaTecnica/
├── 📂 RestApi/                      # API REST Backend
│   ├── Controllers/                 # Controladores de API
│   │   ├── ProductoController.cs
│   │   └── MovimientoStockController.cs
│   ├── Data/                        # Contexto de base de datos
│   │   └── ApplicationDbContext.cs
│   ├── Entities/                    # Modelos de entidades
│   │   ├── Producto.cs
│   │   └── Movimientos.cs
│   ├── DTO/                         # Data Transfer Objects
│   ├── Enums/                       # Enumeraciones
│   └── Migrations/                  # Migraciones de EF Core
│
├── 📂 Blazzor/                      # Proyecto Blazor Server
│   ├── Components/
│   │   └── Layout/                  # Layouts y navegación
│   ├── Data/                        # Servicios del servidor
│   └── Program.cs
│
└── 📂 Blazzor.Client/               # Proyecto Blazor WebAssembly
    ├── Pages/                       # Páginas Razor
    │   ├── Productos.razor          # Lista de productos
    │   ├── CrearProducto.razor      # Formulario de creación
    │   └── DetallesProducto.razor   # Detalles y movimientos
    ├── Servicios/                   # Servicios del cliente
    │   ├── ProductoService.cs
    │   └── NotificationService.cs
    └── Modelos/                     # DTOs del cliente
```

---

## 🛠️ Instalación y Configuración

### Prerrequisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)

### 1️ Clonar el repositorio

```bash
git clone https://github.com/Josue1991/PruebaTecnica.git
cd PruebaTecnica/PreubaTecnica
```

### 2️ Restaurar paquetes NuGet

```bash
dotnet restore
```

### 3️ Aplicar migraciones de base de datos

```bash
cd RestApi
dotnet ef database update
```

O desde la **Consola del Administrador de Paquetes** en Visual Studio:

```powershell
Update-Database
```

### 4️⃣ Configurar proyectos de inicio múltiples

En Visual Studio:
1. Click derecho en la **Solución**
2. Seleccionar **"Configurar proyectos de inicio..."**
3. Elegir **"Varios proyectos de inicio"**
4. Configurar:
   - ✅ **RestApi** → `Start`
   - ✅ **Blazzor** → `Start`

### 5️⃣ Ejecutar la aplicación

Presiona **F5** o ejecuta:

```bash
# Terminal 1 - API
cd RestApi
dotnet run

# Terminal 2 - Blazor
cd Blazzor/Blazzor
dotnet run
```

### 6️⃣ Acceder a la aplicación

- 🌐 **Frontend Blazor:** https://localhost:7065
- 📡 **API REST:** https://localhost:7243
- 📚 **Swagger UI:** https://localhost:7243/swagger

---

## 🔌 API Endpoints

### 📦 Productos

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/products` | Obtener todos los productos |
| `GET` | `/api/products/{id}` | Obtener producto por ID |
| `POST` | `/api/products` | Crear nuevo producto |
| `PUT` | `/api/products/{id}` | Actualizar producto existente |
| `DELETE` | `/api/products/{id}` | Eliminar producto |


### 📊 Movimientos de Stock

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/products/{productId}/movements` | Obtener movimientos de un producto |
| `POST` | `/api/products/{productId}/movements` | Registrar nuevo movimiento |

---

## 📋 Modelos de Datos

### Producto (DTO)

```json
{
  "id": 1,
  "descripcion": "Laptop Dell XPS 15",
  "codigo": "DELL-XPS-001",
  "categoria": "Electrónica",
  "cantidadStock": 15,
  "precioUnitario": 1299.99,
  "creado": "2024-05-16T10:30:00Z"
}
```

### Movimiento de Stock (DTO)

```json
{
  "productId": 1,
  "tipo": 1,
  "cantidad": 5,
  "razon": "Venta a cliente corporativo"
}
```

**Tipos de Movimiento:**
- `1` = Vendido (Resta del stock)
- `2` = Comprado (Suma al stock)

---

## 🔒 Reglas de Negocio

| Regla | Descripción |
|-------|-------------|
| 🔑 **Codigo Único** | El código de producto debe ser único en toda la base de datos |
| ❌ **No stock negativo** | No se permite registrar ventas si el stock es insuficiente |
| 📜 **Historial completo** | Todos los movimientos quedan registrados permanentemente |
| 🔴 **Alerta de stock bajo** | Productos con menos de 10 unidades se resaltan en rojo |
| ✅ **Validación de datos** | Todos los campos requeridos son validados antes de guardar |

---

## 🎯 Características Técnicas

### Backend
- ✅ **Arquitectura RESTful** - Endpoints bien definidos y documentados
- ✅ **Repository Pattern** - Separación de lógica de negocio
- ✅ **DTO Pattern** - Transferencia segura de datos
- ✅ **CORS habilitado** - Permite comunicación cross-origin
- ✅ **Manejo de errores** - Respuestas HTTP apropiadas

### Frontend
- ✅ **Renderizado híbrido** - Server + WebAssembly
- ✅ **Componentes reutilizables** - Arquitectura modular
- ✅ **Validación client-side** - Feedback inmediato al usuario
- ✅ **Manejo de estado** - Actualización reactiva de UI
- ✅ **Navegación programática** - Experiencia fluida

---

## 🧪 Pruebas

### Probar con Swagger UI

1. Navega a: https://localhost:7243/swagger
2. Expande los endpoints
3. Click en "Try it out"
4. Completa los parámetros
5. Click en "Execute"

### Probar manualmente

```bash
# Crear un producto
curl -X POST "https://localhost:7243/api/products" \
  -H "Content-Type: application/json" \
  -d '{
    "descripcion": "Mouse Logitech",
    "codigo": "LOG-M01",
    "categoria": "Accesorios",
    "cantidadStock": 50,
    "precioUnitario": 29.99
  }'

# Obtener todos los productos
curl -X GET "https://localhost:7243/api/products"

# Registrar un movimiento
curl -X POST "https://localhost:7243/api/products/1/movements" \
  -H "Content-Type: application/json" \
  -d '{
    "tipo": 1,
    "cantidad": 5,
    "razon": "Venta regular"
  }'
```

---

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Por favor:

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

---

## 📝 Licencia

Este proyecto fue desarrollado como prueba técnica.

---

## 👤 Autor

**Josue Carranza**

- GitHub: [@Josue1991](https://github.com/Josue1991)
- Proyecto: [PruebaTecnica](https://github.com/Josue1991/PruebaTecnica)

---

## 🙏 Agradecimientos

- ASP.NET Core Team
- Blazor Community
- MudBlazor Contributors

---

