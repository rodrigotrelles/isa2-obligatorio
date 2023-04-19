# Explicación del tablero y su vínculo con el proceso de ingeniería

Para esta entrega tenemos dos tableros:

- Isa 2 - Deuda técnica
- Isa 2 - Documentación

A continuación se detallarán las propiedades de cada uno y su vínculo con el proceso.

## Deuda técnica

En el tablero de deuda técnica tenemos 6 columnas:

### To do
La columna que contiene las tareas ingresadas para comenzar a trabajar. Los tickets en esta columna tienen una descripción y fecha de creación para que una vez que pasen a Done se puedan calcular las métricas correspondientes.

### In progress
En esta columna se encuentran todos los tickets que están siendo desarrollados. El desarrollo implica la codificación de la funcionalidad en todas las puntas del sistema. 

Los tickets de esta columna tienen registrada la fecha en la que se pasó a esta columna, para posterior calculo de métricas.

### PR
En esta columna se encuentran los tickets que completaron su desarrollo desde el punto de vista del desarrollador asignado. Mientras estén en esta columna, los tickets son sujetos a las siguientes validaciones:

- Code review por un desarrollador distinto al que realizó la tarea. Se requiere una aprobación para poder mergear el ticket.
- Ejecución de pruebas unitarias de .NET por parte del pipeline de Github Actions.
- Ejecución de linters tanto para el código .NET como el código Angular.

En caso de que cualquiera de las validaciones falle, es obligatorio corregir antes de hacer merge.

### Test
En esta columna, un tester debe ejecutar las pruebas manuales pertinentes para asegurar la calidad de la funcionalidad desarrollada. En caso de no ser aprobado, el ticket vuelve a la columna de In progress con un comentario para resolver la incidencia detectada.

### Review
En esta columna, los tickets pasan por una revisión del PO del proyecto. En caso de ser aprobados, pueden continuar hasta la siguiente columna. Si los tickets fallan, son regresados a la columna In progress con un comentario para resolver la incidencia.

### Done
En esta columna, los tickets fueron desarrollados y completaron todas las validaciones pertinentes para poder ser considerados una tarea finalizada.

Se registra la fecha en la que se mueve el ticket a esta columna para posterior cálculo de métricas.

## Documentación

El tablero de documentación posee cuatro columnas:

- To do
- In progress
- PR
- Done

Las cuatro columnas comparten su justificación con las columnas de igual nombre en el tablero de deuda técnica. No se utilizan columnas de Test ni Review porque en este caso, las tareas no corresponden a un desarrollo que requiera testing o aprobación del PO.