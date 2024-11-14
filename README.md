# Innovatech Api
Prueba técnica InnovaTech

# Diseño
La prueba técnica se desarrollo con arquitectura limpia, utilizando MediaTR como la biblioteca de mensajería entre la capa de aplicación y el api, fluent validate para validar los modelos, 
AutoMapper para mapear las propiedades del dominio y poder representarlas en objetos para transportar datos(DTO) y por ultimo UnitTest para realizar pruebas unitarias 

# Ejecución
En el folder donde se encuentra el proyecto del Api (Innovatech.Api) se encuentra un archivo llamado (docker-compose.yaml), donde contiene la imagen del motor de la base de datos para poder 
ejecutar el proyecto. 
Para correr la imagen de docker asociado a la base de datos, se ejecuta una consola de powershell y se genera un CD(acceso a la carpeta) ejemplo: 
* C:\Users\USER\source\repos\InnovatechTestApi\Innovatech.Api)
Ejecutando aquel comando podemos ejecutar el comando que permite descargar y ejecutar la imagen:
* docker-compose up -d
  
  ![imagen](https://github.com/user-attachments/assets/5d274307-17f8-42ff-a4e0-d3d8d23974df)

Se verifica que la imagen de docker este ejecutando de manera correcta como se muestra en la imagen:

![imagen](https://github.com/user-attachments/assets/d6c7fb33-dabb-44f0-9c34-c5ef09ae3d7d)
  
En la interfaz de visual studio, se selcciona como proyecto de inicio la capa del api, ejemplo de imagen:

![imagen](https://github.com/user-attachments/assets/b933a711-6539-4a43-8439-c14fc6fa5306)

En al interfaz de visual studio, desde la opcion de ejecutar la aplicacion, se podría ejecutar el api

![imagen](https://github.com/user-attachments/assets/dc7b3b30-bb29-481a-80a2-deb2bb982b45)

La aplicacion debería generar la interfaz por Swagger para poder ejecutar los metodos del sistema.

![imagen](https://github.com/user-attachments/assets/da81f46a-f7a1-4080-8de0-c0413d23c483)

# Pruebas Unitarias
Las pruebas unitarias se encuentra en el proyecto (Innovatech.UnitTest) como se muestra en la siguiente imagen:

![image](https://github.com/user-attachments/assets/ddaf8f74-88e4-438f-ae24-ac59598bfca9)


