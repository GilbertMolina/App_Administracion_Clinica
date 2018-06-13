# Administración Clínica Médica

### Instrucciones para ejecutar satisfactoriamente la aplicación.

----
## Crear base de datos
1. En SQL Server, crear una base de datos llamada **AdministracionClinicaBD**.

----
## Crear Publish de la base de datos
1. Abrir la solución de **AppAdministracionClinica** en Visual Studio.
2. Presionar clic derecho sobre el proyecto de base de datos llamado **BaseDeDatos**, y seleccionar la opción **Publish...**. En la ventana que se despliega presionar sobre el botón de **Edit...** para realizar la conexión y seleccionar la base de datos llamada **AdministracionClinicaBD**.
3. Verificar que en la base de datos **AdministracionClinicaBD** se hayan creado las tablas **CitasPacientes**, **EstadosCitas**, **Pacientes** y **TiposCitas**.

----
## Configuración de archivos Web.config
1. Abrir el archivo **Web.config** del proyecto **App** y modificar las líneas **12** y **13** para cambiar el nombre del servidor de base de datos en la propiedad **data source**, por el que corresponda.
2. Abrir el archivo **Web.config** del proyecto **WebAPI** y modificar la línea **13** para cambiar el nombre del servidor de base de datos en la propiedad **data source**, por el que corresponda.
3. Abrir el archivo **Web.config** del proyecto **WebAPI.Tests** y modificar la línea **13** para cambiar el nombre del servidor de base de datos en la propiedad **data source**, por el que corresponda.

----
## Ejecutar proyecto del WebAPI y proyecto App
1. Presionar clic derecho sobre el proyecto de **WebAPI** y seleccionar la opción de **Set as StartUp Project** e ir a la opción de **DEBUG** en la barra de herramientas y seleccionar la opción de **Start Without Debugging**.
2. Presionar clic derecho sobre el proyecto de **App** y seleccionar la opción de **Set as StartUp Project** e ir a la opción de **DEBUG** en la barra de herramientas y seleccionar la opción de **Start Without Debugging**.
3. Verificar que tanto el proyecto de **WebAPI** y **App** se encuentran ejecutándose.

----
## Configuración de puertos
1. Copiar el puerto en el que se está ejecutando el proyecto de **App**.
2. En el proyecto **WebAPI**, en la carpeta **App_Start**, abrir el archivo **WebApiConfig.cs**, y en la línea **13** modificar el puerto de la URL por el puerto que se obtuvo en el paso anterior, el cual es el puerto donde se está ejecutando el proyecto **App**. Esto por motivo de realizar la configuración de CORS (Cross-Origin Resource Sharing).
3. Copiar el puerto en el que se está ejecutando el proyecto de **WebAPI**.
4. En el proyecto **App**, ir a la carpeta **Views/Appointment**, abrir la vista **Create** y modificar en las líneas **52** a la **55** los puertos de las URLs por el puerto donde se está ejecutando el proyecto de **WebAPI**.
5. En el proyecto **App**, ir a la carpeta **Views/Appointment**, abrir la vista **Edit** y modificar en la línea **62** el puerto de URL por el puerto donde se está ejecutando el proyecto de **WebAPI**.
6. En el proyecto **App**, ir a la carpeta **Views/Appointment**, abrir la vista **Index** y modificar en la línea **30** el puerto de URL por el puerto donde se está ejecutando el proyecto de **WebAPI**.
7. En el proyecto **App**, ir a la carpeta **Views/Patient**, abrir la vista **Create** y modificar en la línea **43** el puerto de URL por el puerto donde se está ejecutando el proyecto de **WebAPI**.
8. En el proyecto **App**, ir a la carpeta **Views/Patient**, abrir la vista **Edit** y modificar en la línea **43** el puerto de URL por el puerto donde se está ejecutando el proyecto de **WebAPI**.
9. En el proyecto **App**, ir a la carpeta **Views/Patient**, abrir la vista **Index** y modificar en la línea **27** el puerto de URL por el puerto donde se está ejecutando el proyecto de **WebAPI**.

----
## Registro de un usuario e inicio de sesión
1. Para poder visualizar las pantallas de **Pacientes** y **Citas**, es necesario haber hecho el registro de usuario y posteriormente iniciar sesión.
2. Para poder realizar el registro de usuario, presionar clic sobre el hipervínculo de **Registrar** que se encuentra en la barra de navegación, y posteriormente ingrese los datos que se le solicitan.
3. Si ya posee un usuario en la aplicación, solo es necesario que inicie sesión en la misma, para esto presione clic sobre el hipervínculo de **Iniciar sesión** que se encuentra en la barra de navegación, y posteriormente ingrese los datos que se le solicitan.

----
## Aplicación ejecutándose
1. Al ingresar a la pantalla de iniciar sesión, se deberá de visualizar la siguiente pantalla:
![Pantalla de Iniciar Sesión](https://github.com/GilbertMolina/App_Administracion_Clinica/blob/master/App/ImagenesAplicacion/01.png)

2. Al ingresar al Index de la aplicación, se deberá de visualizar la siguiente pantalla:
![Pantalla Bienvenida](https://github.com/GilbertMolina/App_Administracion_Clinica/blob/master/App/ImagenesAplicacion/02.png)

2. Al ingresar al menú de Pacientes de la aplicación, se deberá de visualizar la siguiente pantalla:
![Pantalla Pacientes](https://github.com/GilbertMolina/App_Administracion_Clinica/blob/master/App/ImagenesAplicacion/03.png)

2. Al ingresar al menú de Citas de la aplicación, se deberá de visualizar la siguiente pantalla:
![Pantalla Citas](https://github.com/GilbertMolina/App_Administracion_Clinica/blob/master/App/ImagenesAplicacion/04.png)