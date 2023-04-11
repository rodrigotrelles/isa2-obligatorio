# Reporte de mejoras al código
Este informe tiene una lista de errores que encontramos con respecto a código con su respectiva descripción/sugerencia de mejora, así como también su clasificación tanto en severidad como prioridad. No se tratan simplemente de cambios cosméticos sino que también ayudarían a un código más mantenible, legible y extensible en caso de seguir las sugerencias planteadas.
## Frontend: 
- Carpetas y archivos vacíos que no fueron eliminados: 
    - "app.component.scss" no se usa y "assets/.gitkeep" vacío.
    - Clasificación según severidad: Leve
    - Clasificación según prioridad:  Baja
- Importación de styles en orden incorrecto:
    - En el archivo "angular.json" el archivo "src/styles.scss" debería ser el primero de la lista para garantizar que los estilos globales tengan prioridad sobre otros archivos de estilos.
    - Clasificación según severidad: Leve
    - Clasificación según prioridad:  Baja
- Código en inglés y español: 
    - El código debe estar en un solo idioma para hacer el mismo más legible y mantenible.
    - Clasificación según severidad: Leve
    - Clasificación según prioridad:  Baja
- Los servicios no están desacoplados del módulo HttpClient: 
    - Todos los servicios utilizan httpClient y repiten las mismas llamadas una y otra vez. Sería aconsejable crear un solo servicio que utilice HttpClient y definir métodos de get, getById, Insert, Update y Delete con los parámetros necesarios. Estos métodos son los que deben utilizar los demás servicios. De esta manera, evitamos repetir código, y si se debe hacer un cambio vinculado a HttpClient se hace en un solo lugar.
    - Clasificación según severidad: Menor
    - Clasificación según prioridad: Baja
- Mejoras en estándares de escritura:
    - Constantes deben ser uppercase. Ejemplo: el menú.ts incluye varios objetos constantes y todos están definidos con capitalize.
    Métodos deben comenzar con minúscula. En todo el sitio, los métodos de servicios o componentes comienzan con una mayúscula, en Angular el estándar es comenzar con minúscula.
    - Clasificación según severidad: Leve
    - Clasificación según prioridad:  Baja
- Errores en etiquetas HTML principales:
    - "title" dentro de la etiqueta head quedó con el valor por defecto de la app. La app esta en español y el atributo lang dice "en" (error de accesibilidad). La tag de meta description poco desarrollada.
    - Clasificación según severidad: Leve
    - Clasificación según prioridad:  Baja
- Memory leaks al usar subscribes en los componentes:
    - Cuando se utiliza un "subscribe()" dentro de un componente, al destruir el mismo se debe hacer un "unsubscribe()" para no generar memory leaks. Esto no está ocurriendo en la app.
    - Clasificación según severidad: Menor
    - Clasificación según prioridad: Baja
- Los modelos no respetan el estándar de Angular:
    - Los modelos están creados con clases, cuando, por las características y el contexto en que se utilizan deberían ser interfaces. Si solo se necesita definir la estructura de un objeto, la interfaz es la elección correcta.
    - Clasificación según severidad: Leve
    - Clasificación según prioridad:  Baja
- Readme file por defecto:
    - Tiene el contenido por defecto que trae en un proyecto Angular. No ayuda en nada al programador ni en su instalación, ni entender la app, ni saber cuales son las principales librerías utilizadas.
    - Clasificación según severidad: Leve
    - Clasificación según prioridad:  Baja
- Frontend no tiene linter:
    - Necesario para el análisis del código para detectar "Code Smells", falta de estándares, etc.
    - Clasificación según severidad: Leve
    - Clasificación según prioridad:  Baja
- Mala estructura y jerarquía de carpetas:
    - Carpeta de routes incluye todos los componentes de la app, sin discriminar lo que es un componente y lo que es un container.
    - Clasificación según severidad: Menor
    - Clasificación según prioridad:  Baja
- Url’s de la API sin parametrizar: 
    - Las url’s utilizadas para las llamadas a la API están hardcodeadas dentro de cada archivo service, cuando deberían estar dentro de un archivo api-routes.ts que defina todas para luego utilizarlas en cualquier parte del código.
    - Clasificación según severidad: Leve
    - Clasificación según prioridad:  Baja
- No existen unit tests:
    - Necesarios para comprobar el correcto funcionamiento de la app.
    - Clasificación según severidad: Mayor
    - Clasificación según prioridad:  Media
- App Angular no se encuentra modularizada:
    - Toda la app se encuentra declarado dentro de "app.module.ts". Todas las rutas están definidas dentro de "app-routing.module.ts". Sería conveniente modularizar por rutas para desacoplar aplicación y evitar cargar secciones de la app que no se utilizan.
    - Clasificación según severidad: Menor
    - Clasificación según prioridad:  Baja

## Backend:
- No respetar estándar recomendado para nombres de los endpoints: 
    - Se utiliza el verbo HTTP en el nombre del endpoint, lo cual no respeta las buenas practicas de las REST APIs.
    - Clasificación según severidad: Leve
    - Clasificación según prioridad:  Baja
- Código en inglés y español:
    - El código debe estar en un solo idioma escrito para hacer el mismo más legible y mantenible.
    - Clasificación según severidad: Leve
    - Clasificación según prioridad:  Baja
- No se definen excepciones propias:
    - No existen excepciones propias. Siempre es buena idea crear tu propia jerarquía de excepciones con el fin de mejorar la mantenibilidad, legibilidad y extensibilidad del código.
    - Clasificación según severidad: Menor
    - Clasificación según prioridad: Baja


 


  


