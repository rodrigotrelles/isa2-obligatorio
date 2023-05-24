# Definición/uso del proceso de ingeniería en el contexto de KANBAN (Versión 2)
 
## Estructura del equipo. 

**Product Owner**: Franco
Es quien prioriza las tareas y clasifica los issues. También es el encargado de realizar las Review de cada tarea que fue tomada.

**Scrum Master/Facilitador**: Rodrigo
Encargado de acompañar al equipo durante el proceso y supervisar las diferentes ceremonias. 

**Developers**: Franco, Rodrigo, Federico
Son quienes tan a tomar tareas del Backlog y desarrollarlas y hacer revisiones del código de las mismas.

**Testers**: Franco, Rodrigo, Federico
Son quienes van a Testear que las tareas fueron desarrolladas según los criterios de aceptación definidos.

Tanto Developers como Testers son responsables de documentar todo lo necesario dentro del repositorio del proyecto.
 

## Etapas del proceso de Ingeniería

Hasta ahora las etapas que definimos y creímos convenientes son:

1. Backlog
2. In Progress
3. Code Review
4. Testing
5. Review
6. Done

A partir de ahora, dado que adoptamos la metodología de BDD, modificamos este proceso que va a tener algunas
variaciones con respecto al estado anterior.

### Breve descripcion de cada paso

**1. Backlog**
1. _¿Cuándo se hace?_ Es el primer paso del proceso, cuando ingresa una nuevo requerimiento.
2. _¿Quién lo hace?_ Cualquier miembro del equipo
3. _¿Qué obtengo?_ Para el Frontend, un issue con los criterios de aceptacion definidos. Para el Backend, otro issue diferente, incluyendo los distintos escenarios de BDD. 
4. _¿Cómo se hace?_ En las Standups diarias, se da la conversación y como resultado se obtienen los artefactos anteriormente.

**2. In Progress**
1. _¿Cuándo se hace?_ Cuando un desarrollador toma una tarea del backlog.
2. _¿Quién lo hace?_ Cualquier desarrollador del equipo
3. _¿Qué obtengo?_ Un código implmentando el requerimiento para todos los issues y pruebas de BDD para los issues de backend.
4. _¿Cómo se hace?_ Se programa en Angular los issues de Frontend con Visual Studio Code y C# los de Backend con Visual Studio Enterprise.

**3. Code Review**
1. _¿Cuándo se hace?_ Cuando se termina de implementar todos los requerimientos de un Issue.
2. _¿Quién lo hace?_ Cualquier desarrollador del equipo.
3. _¿Qué obtengo?_ Un merge del código del issue en la rama de develop.
4. _¿Cómo se hace?_ Se crea un Pull Request, que se revisa por otra persona y que también debe pasar los checks de Github Actions. 

**4. Testing**
1. _¿Cuándo se hace?_ Cuando un PR es aprobado y mergeado a la rama de develop.
2. _¿Quién lo hace?_ Cualquier Tester del equipo.
3. _¿Qué obtengo?_ Una aprobación de que los criterios de aceptacion se cumplen desde el punto de vista de los Tester o un rechazo por incumplimiento de los mismos. Si existe un rechazo, se mueve nuevamente a la columna de In Progress.
4. _¿Cómo se hace?_ Se realiza un test manual exploratorio por parte del Tester.

**5. Review**
1. _¿Cuándo se hace?_ Cuando el issue es aprobado por el Tester.
2. _¿Quién lo hace?_ El Product Owner
3. _¿Qué obtengo?_ Una aprobación desde el punto de vista del producto de que este issue cumple con todos los requerimientos del cliente. El PO puede rechazar también aprobación. En este caso, se actualizan los requerimientos y se mueven nuevamente a la columna de In Progress.
4. _¿Cómo se hace?_ Se realiza una reunión entre el Producto Owner y los miembros del equipo.

**6. Done**
1. _¿Cuándo se hace?_ Cuando una issue es aprobado por el Product Owner
2. _¿Quién lo hace?_ El Product Owner
3. _¿Qué obtengo?_ Valor para el cliente
4. _¿Cómo se hace?_ Finalizando el proceso de ingeniería y cerrando este issue.


## Registro de horas

El registro de horas se llevó a cabo en una planilla excel, y al finalizar la entrega se agruparon las mismas y se agregaron al informe de avance.
