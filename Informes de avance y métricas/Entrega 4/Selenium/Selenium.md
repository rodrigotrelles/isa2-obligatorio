## Selenium

Selenium es una herramienta que nos permite grabar pruebas exploratorias para su posterior ejecución. Dichas pruebas fueron basadas en los escenarios de BDD y son muy convenientes cuando se plantea el testeo de regresión de un proyecto. Brindan seguridad tanto al equipo de desarrollo como al cliente, dado que aseguran el funcionamiento en conjunto (integración) del proyecto. Esto además se logra con una velocidad mucho más elevada que correr todas las pruebas manualmente, permitiendo a los equipos de QA centrarse en pruebas cruciales o más importantes. 

### Ejecución

Para ejecutar los casos de prueba en Selenium es necesario instalar el plugin Selenium IDE en el explorador. A continuación se detalla la instalación en Google Chrome:

- Ingresar al siguiente link https://chrome.google.com/webstore/detail/selenium-ide/mooikfkahbdckldjjndioackbalphokd?hl=es-419
- Instalar el plugin Selenium IDE

Luego de instalar el plugin y ejecutar el mismo, abrir el archivo ArenaGestor.side ubicado en la misma carpeta que contiene este documento.

Las pruebas deben ejecutarse en el orden establecido con números al inicio del nombre de cada prueba. Selenium ordena las pruebas automáticamente.

Una vez ejecutadas, para volver a ejecutar las mismas es necesario eliminar el usuario creado por la prueba de registro de usuarios. Para esto:

- Ingresar a la base de datos en Microsoft SQL Server Management
- Click derecho en la tabla dbo.User de la base de datos correspondiente al proyecto
- Seleccionar la opción "Select top 1000 Rows"
- Borrar el template generado
- Ingresar el siguiente comando: DELETE from [ArenaGestorDB].[dbo].[User] where [Email] = 'tester@arenagestor.com'

Luego de eliminar el usuario, la prueba debería ejecutarse correctamente.