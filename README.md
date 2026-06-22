# Mini Core Logística MVC

Aplicación pequeña desarrollada con **ASP.NET Core MVC** para calcular el costo total de envíos por repartidor dentro de un rango de fechas.

## MVC utilizado

- Framework: ASP.NET Core MVC
- Lenguaje: C#
- Vista: Razor Views
- Base de datos: SQLite con seed automático mediante Entity Framework Core

## Descripción del problema

Una empresa de logística necesita conocer el costo generado por los envíos realizados por cada repartidor en un período determinado. Cada envío tiene un peso en kilogramos y pertenece a una zona. Cada zona tiene una tarifa fija por kilogramo.

La fórmula aplicada es:

```text
Costo del envío = peso_kg * tarifa_por_kg
Costo total = suma de todos los costos de envío filtrados por fecha
```

## Estructura MVC del proyecto

```text
MiniCore.Logistics.Mvc/
├── Controllers/
│   ├── HomeController.cs
│   └── ShipmentCostsController.cs
├── Data/
│   └── LogisticsDbContext.cs
├── Models/
│   ├── DeliveryDriver.cs
│   ├── DeliveryZone.cs
│   └── Shipment.cs
├── Services/
│   ├── IShipmentCostService.cs
│   ├── ShipmentCostAccumulator.cs
│   └── ShipmentCostService.cs
├── ViewModels/
│   ├── ShipmentCostFilterViewModel.cs
│   ├── ShipmentCostPageViewModel.cs
│   └── ShipmentCostResultViewModel.cs
├── Views/
│   └── ShipmentCosts/
│       └── Index.cshtml
├── wwwroot/css/site.css
├── Database/logistics_schema_and_seed.sql
└── Program.cs
```

## Cómo correr localmente

### Requisitos

- .NET 8 SDK instalado

### Comandos

```bash
dotnet restore
dotnet run
```

Luego abre en el navegador:

```text
http://localhost:5088
```

La base SQLite se crea automáticamente al iniciar el proyecto. El archivo generado se llama `logistics.db`.

## Fechas recomendadas para probar

```text
Fecha Inicio: 2025-05-01
Fecha Fin:    2025-05-31
```

Resultado esperado principal:

- Andrés Hidalgo: 5 envíos, 32 kg, zona Norte, tarifa $1.50, costo $48.00
- Camila Torres: 3 envíos, 18 kg, zona Sur, tarifa $2.00, costo $36.00
- Daniela Molina: envíos en varias zonas, calculados por envío según su zona

Luis Andrade no aparece en mayo porque su envío seed está registrado en junio.

## Link del video

Pendiente de agregar:

```text
https://youtube.com/...
```

## Link del proyecto deployado

Pendiente de agregar:

```text
https://tu-proyecto.onrender.com
```

## Documentación oficial

- ASP.NET Core MVC: https://learn.microsoft.com/en-us/aspnet/core/mvc/overview
- Tutorial oficial MVC: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc
- Descarga .NET: https://dotnet.microsoft.com/en-us/download

## Videos de referencia

- FreeCodeCamp - How to Build an ASP.NET Core MVC Web App: https://www.youtube.com/watch?v=QtiM87MV27w
- Microsoft .NET Videos: https://dotnet.microsoft.com/en-us/learn/videos

## Contacto

- Correo institucional UDLA: alumno.apellido@udla.edu.ec
- Correo alternativo: tu.correo@gmail.com
