# Guion sugerido para video de 5 a 12 minutos

## 1. Presentación del problema

Hola, mi nombre es [tu nombre]. En este video voy a explicar un mini core desarrollado con ASP.NET Core MVC. El objetivo es calcular el costo total de envíos por repartidor dentro de un rango de fechas, usando la tarifa por kilogramo de cada zona de entrega.

## 2. Explicación del MVC

El proyecto usa el patrón Model View Controller. En Models están las entidades que representan las tablas Repartidor, Envios y Zonas. En Controllers está ShipmentCostsController, que recibe las fechas desde la vista. En Views está Index.cshtml, que muestra el formulario y la tabla de resultados.

## 3. Mostrar estructura del proyecto

Mostrar brevemente las carpetas:

- Models
- Data
- Services
- ViewModels
- Controllers
- Views
- wwwroot

Explicar que Data contiene el DbContext y los datos iniciales. Services contiene la lógica del cálculo para no cargar el controlador con reglas de negocio.

## 4. Explicar lógica del cálculo

La lógica filtra los envíos cuya fecha_envio esté entre Fecha Inicio y Fecha Fin. Luego, por cada envío, multiplica peso_kg por tarifa_por_kg. Finalmente agrupa los resultados por repartidor y zona.

Fórmula:

Costo = peso_kg × tarifa_por_kg

## 5. Demostración funcionando

Ejecutar el proyecto y abrir la pantalla principal. Ingresar:

- Fecha Inicio: 2025-05-01
- Fecha Fin: 2025-05-31

Mostrar la tabla con Andrés, Camila y Daniela. Explicar que Luis no aparece porque no tiene envíos en ese rango.

## 6. Cierre

Con este ejercicio se demuestra cómo MVC separa responsabilidades: el modelo representa los datos, el controlador coordina la solicitud y la vista muestra el resultado final al usuario.
