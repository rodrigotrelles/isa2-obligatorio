# Configuración del pipeline y su vínculo con el tablero
A continuación explicaremos la configuración elegida para el pipeline y su vinculación con el nuevo tablero y nuestro nuevo proceso de ingeniería.

## Configuración del pipeline

(REALIZAR LOS AJUSTES NECESARIOS)

El pipeline fue configurado utilizando Github Actions y se divide en dos workflows: uno para .NET y otro para Angular.

Durante su configuración, fue necesario aplicar cambios tanto a nivel de backend como de frontend debido a los distintos warnings arrojados por los linters y también para solucionar el problema creado por las pruebas unitarias configuradas para utilizar una ruta absoluta para encontrar los .dll necesarios para probar la funcionalidad de importación y exportación. Al momento de mergear los workflows, todas las incidencias fueron corregidas para poder comenzar a trabajar con un ambiente limpio.

### Workflow .NET
El workflow de .NET es ejecutado cuando se hace un push o pull request en las ramas develop y main. De esta manera nos aseguramos de conocer el estado de develop y main en todo momento. Se compone de las siguientes tareas:

- Checkout del código
- Instalación del ambiente .NET 5.0
- Recuperación de dependencias del proyecto
- Compilación del proyecto
- Ejecución de pruebas unitarias
- Ejecución del linter

Las primeras cuatro tareas se encargan de preparar el ambiente para la ejecución de las pruebas y el linter.

El workflow está configurado para fallar siempre que se encuentre un fallo tanto a nivel de pruebas unitarias como linter.

El linter utiliza dotnet-format, un linter estándar introducido en .NET core 6. Es posible utilizarlo con versiones anteriores mediante una instalación manual.

### Workflow Angular
El workflow de Angular es ejecutado bajo las mismas condiciones que el de .NET para obtener los mismos beneficios. Se compone de:

- Checkout del código
- Instalación del ambiente node
- Compilación del proyecto
- Ejecución del linter

En el caso de Angular, utilizamos angular-eslint como linter, con su configuración estándar dado que es sugerido por Angular mismo.

### Pruebas de BDD
Debimos modificar el pipeline para excluir las nuevas clases agregadas por BDD, ya que era necesario tener el Backend levantado, sino los test fallaban y las modificaciones estaban fuera del scope del trabajo. 

## Vínculo con el tablero

El pipeline de github se vincula principalmente con la columna PR del tablero. La columna de PR consiste en que al terminar un desarrollo, un desarrollador pasa su ticket de In Progress a PR y abre dicho PR. Una vez abierto, el PR iniciará los workflows correspondientes y validará que el código se encuentre en un estado correcto para mergear. Otro miembro del equipo deberá hacer un code review, y al aprobar dicho code review, se procede a mergear el código, moviendo el ticket a la columna de Test.

Es importante destacar que las tareas de la columna de PR son aprobar tanto las validaciones del workflow como el code review, sin ellos, no se considera completada la tarea y no se puede avanzar a la siguiente etapa.
