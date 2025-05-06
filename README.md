# 🗓️ Mini Agenda Diaria

## Descripción

Este proyecto es una aplicación de consola en C# que funciona como una pequeña agenda diaria. Permite agregar, ver, eliminar y buscar eventos, cada uno con un título, fecha y descripción. Los eventos se almacenan en un archivo de texto (`HistorialAgenda.txt`) para mantener la persistencia de los datos entre ejecuciones.

## Objetivo

Practicar el uso de:

- Arreglos
- Manejo de fechas (`DateOnly`)
- Entrada y salida de datos por consola
- Lectura y escritura de archivos
- Condicionales, bucles y estructuras básicas
- `Array.Resize` para modificar dinámicamente el tamaño de los arreglos

## Funcionalidades

📝 **Agregar Evento**  
El usuario ingresa el título, fecha y descripción del evento. Estos datos se guardan en arreglos y se escriben en el archivo `HistorialAgenda.txt`.

📅 **Ver Eventos por Fecha**  
Se listan todas las fechas disponibles. El usuario selecciona una y se muestra el evento correspondiente.

🗑️ **Eliminar Evento**  
Se muestran todos los eventos registrados y el usuario elige cuál eliminar. El archivo se actualiza automáticamente.

🔍 **Buscar Evento por Título**  
Se ingresa un título exacto y se muestra el evento si se encuentra.

🚪 **Salir**  
Finaliza el programa.

## Ejemplo de formato en el archivo

