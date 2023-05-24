## Retrospectiva 12/05/23

En esta tercera retrospectiva utilizamos el método DAKI (Drop, Add, Keep, Improve) para analizar cómo se trabajó hasta el momento. En este caso no surgieron demasiados puntos a evaluar del proceso entonces decidimos repasarlos uno por uno sin votacion.

Como resultado surgieron dos acciones.

- Hacer un chequeo diario para recordar que se hayan subido las horas en la planilla de registro de horas de las tareas correspondientes (Ro)
- Analizar lo relacionado con las metricas para el siguiente sprint donde va a ser necesario calcularlas. (Fede)

Como conclusión, seguimos mejorando el trabajo en equipo sprint tras sprint lo que nos permite concluir en tiempo y forma con las tareas necesarias.

Grabacion

La grabación de la retrospectiva la podemos ver dentro de esta misma carpeta

Tablero de la Retro

https://metroretro.io/BOIOKID6E9R9

Informe de avance

Durante esta etapa se trabajó principalmente en la realización de las dos features que se solicitaron (mantenimiento de snacks y compra de snacks). Para el desarrollo de las mismas a nivel de backend, se crearon los escenarios de prueba utilizando BDD.
Fue necesario la actualización de las github actions para que no corran las pruebas de BDD.

Se agrega documentación del proceso y su relación con el tablero en la carpeta de documentación del proceso, en conjunto con evidencia de la ejecución de los casos de prueba.

En cuanto a lo anterior relacionado con la versión del tablero en función del proceso de ingeniería, como resumen se decidió no utilizar más el tablero documentación. A partir de ahora, luego de este cambio, se colocan labels a las tareas de documentación. 
Además, se explicaron todas las etapas del proceso de ingeniería detallando:
- ¿Cuándo se hace?
- ¿Quién lo hace?
- ¿Qué obtengo?
- ¿Cómo se hace?

Esto ultimo, fue resultado del feedback recibido de la primera entrega.

Se actualiza el formato para mostrar el registro de horas.

Se hizo además la segunda review con el PO (Franco) del desarrollo de las nuevas features antes mencionadas, y se completó satisfactoriamente con la misma.

Se completó por último la tercera retrospectiva detallada anteriormente.

Se trabajó también en saltear las pruebas de SpecFlow en Github Actions para evitar que fallen al no tener el proyecto corriendo.

Se notifica de un bug conocido: Al agregar un concierto nuevo para las pruebas de BDD de compra de snacks, no existe un método para eliminar tickets y la lógica de negocio
prohíbe la eliminación de conciertos con tickets vendidos, por lo tanto, es imposible limpiar correctamente la base de datos tras ejecutar las pruebas sin tener que desarrollar la feature de eliminación de tickets.

Informe de horas

Se incluye un documento pdf en la carpeta Entrega 3
