========================================================
StaffCore RD - Sistema de Gestion de Personal
ISW-311 Tecnologias de Internet I
Universidad Central del Este
========================================================

Nombre:     Luis Alejandro Bravo Bello
Matricula:  LB2024-1279

--------------------------------------------------------
Credenciales del usuario Administrador de prueba
--------------------------------------------------------
Correo:      luisbravobello@gmail.com
Contrasena:  Luis1234
Rol:         Administrador (primer usuario registrado en el sistema)

--------------------------------------------------------
Como correr el proyecto
--------------------------------------------------------
1. Abrir StaffCoreRD.sln en Visual Studio 2022.
2. Restaurar paquetes NuGet (se hace automatico al abrir, o
   clic derecho en la solucion > Restaurar paquetes NuGet).
3. Abrir la Consola del Administrador de paquetes
   (Herramientas > Administrador de paquetes NuGet > Consola
   del Administrador de paquetes) y ejecutar:
       Update-Database
   Esto crea la base de datos StaffCoreDB en (localdb)\mssqllocaldb
   con las tablas de Identity, la tabla Personal y el seed de
   2 empleados.
4. Ejecutar el proyecto (F5 o Ctrl+F5).
5. Iniciar sesion con las credenciales de arriba para probar
   el CRUD completo como Administrador, o registrar un nuevo
   usuario (quedara con el rol Viewer por defecto).

--------------------------------------------------------
Roles del sistema
--------------------------------------------------------
- Administrador: acceso total (Ver, Crear, Editar, Eliminar).
  Se asigna automaticamente al primer usuario que se registra.
- RRHH: puede Ver, Crear y Editar. No puede Eliminar.
- Viewer: solo puede Ver el listado de personal. Rol por
  defecto para todo usuario que se registre despues del primero.

--------------------------------------------------------
Repositorio GitHub
--------------------------------------------------------
[PENDIENTE: pegar aqui el link publico de tu repositorio]
========================================================
