# Retrospectiva 17/04/23

En esta segunda retrospectiva utilizamos el método DAKI (Drop, Add, Keep, Improve) para analizar cómo se trabajó hasta el momento. 
En este caso no surgieron demasiados puntos a evaluar del proceso entonces decidimos repasarlos uno por uno sin votacion.

Como resultado surgieron dos acciones, mas una tercera que fue arrastrada de la Retro anterior:


- Crear ticket en el backlog para modificar el workflow de .Net y agregar en el, el reporte de la clase de hoy (17/4/23)
- Meeting para organizacion de tercera entrega (Repartir tareas y fijar fechas en que vamos a trabajar)
- Comenzar a hacer standups por whatsapp a diario (accion arrastarada de la Retro 1)

Como conclusión, nos parece que el proceso de trabajo ha evolucionado de manera positiva desde al Retrospectiva anterior a esta.  

## Grabacion

La grabación de la retrospectiva la podemos ver dentro de esta misma carpeta

## Tablero de la Retro

https://metroretro.io/BO95873MRLNW

## Informe de avance
Durante esta etapa se creó un primer pipeline de Github Actions que nos permite mantener un nivel adecuado de la calidad del código, además de brindarnos un poco más de seguridad al correr automáticamente las pruebas unitarias antes de cada merge. 

Además, se corrigen dos bugs seleccionados por nivel de prioridad y severidad, incluyendo un informe en la carpeta de documentación del proceso. Cabe aclarar que se detectaron algunos errores en los reportes de la etapa anterior, y por lo tanto, se descartaron algunos de los issues reportados. El pipeline cuenta con una documentación añadida en la carpeta de documentación del proceso.

Como consecuencia de la introducción del pipeline además se corrigieron varios de los warnings para poder pasar la prueba de los linters y también se hicieron cambios en la lógica de carga de archivos .dll para la funcionalidad de importación y exportación. Dichos cambios se aplicaron para que las pruebas unitarias corran en el entorno del pipeline sin la necesidad de aplicar otros scripts.

Se agrega documentación del proceso y su relación con el tablero en la carpeta de documentación del proceso, en conjunto con evidencia de la ejecución de los casos de prueba.

Se hizo además la primera review con el PO (Franco) del desarrollo, y se completó satisfactoriamente con la misma.

Se completó por último la segunda retrospectiva detallada anteriormente, y consideramos que hasta ahora las retrospectivas han aportado gran valor al crecimiento del equipo y su proceso.

## Informe de horas
**_Actualizar_**

- Guía de definición y uso de Kanban: 1h
- Análisis de deuda técnica: 4h 30m
- Documentación de issues: 2h 45m
- Documentación del repositorio: 1h 15m
- Documentación de registro de horas: 30m

Total: 9h 30m

A todo lo anterior, sumamos 15h 20m bajo el concepto de gestión general del proyecto con el siguiente reparto:
- Reuniones: 3h
- Retrospectiva: 2h
- Tareas de entendimiento y gestión: 5h 20m
- Instalación del proyecto y solución de problemas bloqueantes: 5h

Total incluyendo gestión: 24h 50m
