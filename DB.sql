/****************************************************************************************************
*				  	COMIENZA LA CREACION DE LA BASE DE DATOS TDA								*
****************************************************************************************************/
/* CREACION DE LA BASE DE DATOS TDA*/

USE master
RAISERROR ('Iniciando la instalacion de la Base de Datos TDA', 1, 1)	
WITH NOWAIT
GO
/*VERIFICAR SI EXISTE LA BASE DE DATOS, SI EXISTE SE ELIMINA, SI NO EXISTE SE CREA*/
IF EXISTS (SELECT * FROM SYSDATABASES WHERE [NAME] = 'TDA')
BEGIN
	RAISERROR ('Eliminando la base de datos existente', 0, 1)
	DROP DATABASE TDA
END
GO
CHECKPOINT
GO
RAISERROR ('Comienza la creacion de la Base de Datos TDA', 0, 1)
GO
CREATE DATABASE TDA
GO
CHECKPOINT
GO
/*ACTIVAMOS LA BASE DE DATOS Y VERIFICAMOS SU CREACION*/
USE TDA
GO
IF(DB_NAME() <> 'TDA')
	RAISERROR('Error en el archivo CreateTDA.sql, No se encuentra TDA', 22, 127)
			  WITH LOG
ELSE
	RAISERROR('Se ha creado la base de datos TDA', 0 ,1)
GO
/****************************************************************************************************
*								COMIENZA LA CREACION DE TABLAS										*
****************************************************************************************************/
/*Creacion de la Tabla Configuracion*/
CREATE TABLE Configuracion
(
	ID		BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre	NVARCHAR(50) UNIQUE,
	Activo	BIT,
)
GO
RAISERROR('Se ha creado la tabla Configuracion',  0, 1) 
GO
/*Insercion a Configuracion*/
INSERT INTO dbo.Configuracion
	Values('Vehiculo', 0)
GO
/*Creacion de la Tabla Rol*/
CREATE TABLE Rol
(
	ID		BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre	NVARCHAR(50) UNIQUE
)
GO
RAISERROR('Se ha creado la tabla Rol',  0, 1) 
GO
/*Insercion a Rol*/
INSERT INTO dbo.Rol 
	VALUES('Administrador');
GO
INSERT INTO dbo.Rol 
	VALUES('Cajero');
GO
/*Creacion de la Tabla Pagina*/
CREATE TABLE Pagina
(
	ID		BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre	NVARCHAR(50) UNIQUE
)
GO
RAISERROR('Se ha creado la tabla Pagina',  0, 1) 
GO
/*Insercion a Pagina*/
INSERT INTO Pagina
	VALUES('Cliente');
GO
INSERT INTO Pagina
	VALUES('Color');
GO
INSERT INTO Pagina
	VALUES('Empleado');
GO
INSERT INTO Pagina
	VALUES('Estado');
GO
INSERT INTO Pagina
	VALUES('GrupoCliente');
GO
INSERT INTO Pagina
	VALUES('Main');
GO
INSERT INTO Pagina
	VALUES('Marca');
GO
INSERT INTO Pagina
	VALUES('Modelo');
GO
INSERT INTO Pagina
	VALUES('OVentas');
GO
INSERT INTO Pagina
	VALUES('Pais');
GO
INSERT INTO Pagina
	VALUES('Paquete');
GO
INSERT INTO Pagina
	VALUES('Producto');
GO
INSERT INTO Pagina
	VALUES('Promocion');
GO
INSERT INTO Pagina
	VALUES('Proveedor');
GO
INSERT INTO Pagina
	VALUES('Usuario');
GO
INSERT INTO Pagina
	VALUES('Vehiculo');
GO
INSERT INTO Pagina
	VALUES('Venta');
GO
/*Creacion de la Tabla RolPagina*/
CREATE TABLE RolPagina
(
	ID		BIGINT IDENTITY(1,1) PRIMARY KEY,
	Rol		BIGINT FOREIGN KEY REFERENCES Rol(ID),
	Pagina	BIGINT FOREIGN KEY REFERENCES Pagina(ID)
)
GO
RAISERROR('Se ha creado la tabla RolPagina',  0, 1) 
GO
/*Insercion a RolPagina*/
INSERT INTO RolPagina
	VALUES(1, 1);
GO
INSERT INTO RolPagina
	VALUES(1, 2);
GO
INSERT INTO RolPagina
	VALUES(1, 3);
GO
INSERT INTO RolPagina
	VALUES(1, 4);
GO
INSERT INTO RolPagina
	VALUES(1, 5);
GO
INSERT INTO RolPagina
	VALUES(1, 6);
GO
INSERT INTO RolPagina
	VALUES(1, 7);
GO
INSERT INTO RolPagina
	VALUES(1, 8);
GO
INSERT INTO RolPagina
	VALUES(1, 9);
GO
INSERT INTO RolPagina
	VALUES(1, 10);
GO
INSERT INTO RolPagina
	VALUES(1, 11);
GO
INSERT INTO RolPagina
	VALUES(1, 12);
GO
INSERT INTO RolPagina
	VALUES(1, 13);
GO
INSERT INTO RolPagina
	VALUES(1, 14);
GO
INSERT INTO RolPagina
	VALUES(1, 15);
GO
INSERT INTO RolPagina
	VALUES(1, 16);
GO
INSERT INTO RolPagina
	VALUES(1, 17);
GO
INSERT INTO RolPagina
	VALUES(2, 6);
GO
INSERT INTO RolPagina
	VALUES(2, 9);
GO
/*Creacion de la Tabla BaseSalario*/
CREATE TABLE BaseSalario
(
	ID		BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre	NVARCHAR(50) UNIQUE
)
GO
RAISERROR('Se ha creado la tabla BaseSalario', 0, 1)
GO
/*Insercion a BaseSalario*/
INSERT INTO dbo.BaseSalario
	VALUES('Hora')
GO
INSERT INTO dbo.BaseSalario
	VALUES('Dia')
GO
INSERT INTO dbo.BaseSalario
	VALUES('Semana')
GO
INSERT INTO dbo.BaseSalario
	VALUES('Quincena')
GO
INSERT INTO dbo.BaseSalario
	VALUES('Mes')
GO
INSERT INTO dbo.BaseSalario
	VALUES('Año')
GO
/*Creacion de la Tabla Dia*/
CREATE TABLE Dia
(
	ID		BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre	NVARCHAR(50) UNIQUE
)
GO
RAISERROR('Se ha creado la tabla Dia', 0, 1)
GO
/*Insercion a Dia*/
INSERT INTO dbo.Dia
	Values('Lunes')
GO
INSERT INTO dbo.Dia
	Values('Martes')
GO
INSERT INTO dbo.Dia
	Values('Miercoles')
GO
INSERT INTO dbo.Dia
	Values('Jueves')
GO
INSERT INTO dbo.Dia
	Values('Viernes')
GO
INSERT INTO dbo.Dia
	Values('Sabado')
GO
INSERT INTO dbo.Dia
	Values('Domingo')
GO
/*Creacion de la Tabla TipoIdentificacion*/
CREATE TABLE TipoIdentificacion
(
	ID		BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre	NVARCHAR(50) UNIQUE
)
GO
RAISERROR('Se ha creado la tabla TipoIdentificacion', 0, 1)
GO
/*Insercion a TipoIdentificacion*/
INSERT INTO dbo.TipoIdentificacion
	VALUES('IFE')
GO
INSERT INTO dbo.TipoIdentificacion
	VALUES('Licencia')
GO
INSERT INTO dbo.TipoIdentificacion
	VALUES('Pasaporte')
GO
/*Creacion de la Tabla Usuario*/
CREATE TABLE Usuario
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Alias		NVARCHAR(50) UNIQUE,
	Contrasena	NVARCHAR(50),
	Email		NVARCHAR(100),
	Rol			BIGINT FOREIGN KEY REFERENCES Rol(ID),
	--Empleado	BIGINT FOREIGN KEY REFERENCES Empleado(ID),
	UsuarioAlta	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta	DATETIME,
	UsuarioMod	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod	DATETIME
)
GO
RAISERROR('Se ha creado la tabla Usuario', 0, 1)
GO
/*Insercion a Usuario*/
INSERT INTO dbo.Usuario(Alias, Contrasena, Rol, FechaAlta) 
	VALUES('ADMIN', 'ADMIN',1, GETDATE());
GO
/*Creacion de la Tabla Pais*/
CREATE TABLE Pais
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre		NVARCHAR(50) UNIQUE,
	UsuarioAlta	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta	DATETIME,
	UsuarioMod	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod	DATETIME
)
GO
RAISERROR('Se ha creado la tabla Pais', 0, 1)
GO
/*Insercion a Pais*/
INSERT INTO dbo.Pais(Nombre, UsuarioAlta, FechaAlta)
	VALUES('Mexico', 1, GETDATE());
GO
/*Creacion de la Tabla Estado*/
CREATE TABLE Estado
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre		NVARCHAR(50) UNIQUE,
	Pais		BIGINT FOREIGN KEY REFERENCES Pais(ID),
	UsuarioAlta	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta	DATETIME,
	UsuarioMod	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod	DATETIME
)
GO
RAISERROR('Se ha creado la tabla Estado', 0, 1)
GO
/*Insercion a Pais*/
INSERT INTO dbo.Estado(Nombre, Pais,UsuarioAlta, FechaAlta)
	VALUES('Coahuila', 1, 1, GETDATE());
GO
/*Creacion de la Tabla Marca*/
CREATE TABLE Marca
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre		NVARCHAR(50) UNIQUE,
	UsuarioAlta	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta	DATETIME,
	UsuarioMod	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod	DATETIME
)
GO
RAISERROR('Se ha creado la tabla Marca', 0, 1)
GO
/*Creacion de la Tabla Modelo*/
CREATE TABLE Modelo
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre		NVARCHAR(50),
	Marca		BIGINT FOREIGN KEY REFERENCES Marca(ID),
	UsuarioAlta	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta	DATETIME,
	UsuarioMod	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod	DATETIME
)
GO
RAISERROR('Se ha creado la tabla Modelo', 0, 1)
GO
/*Creacion de la Tabla Color*/
CREATE TABLE Color
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre		NVARCHAR(50) UNIQUE,
	UsuarioAlta	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta	DATETIME,
	UsuarioMod	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod	DATETIME
)
GO
RAISERROR('Se ha creado la tabla Color', 0, 1)
GO
/*Creacion de la Tabla TipoProducto*/
CREATE TABLE TipoProducto
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre		NVARCHAR(100) UNIQUE,	
	UsuarioAlta	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta	DATETIME,
	UsuarioMod	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod	DATETIME
)
GO
RAISERROR('Se ha creado la tabla TipoProducto', 0, 1)
GO
/*Creacion de la Tabla Empleado*/
CREATE TABLE Empleado
(
	ID				BIGINT IDENTITY(1,1) PRIMARY KEY,
	RFC				NVARCHAR(13),
	Nombre			NVARCHAR(100),
	Apellido		NVARCHAR(100),
	Apellido2		NVARCHAR(100),
	Calle			NVARCHAR(100),
	NumeroInterior	NVARCHAR(50),
	NumeroExterior	NVARCHAR(50),
	Colonia			NVARCHAR(100),
	CP				NVARCHAR(5),
	Localidad		NVARCHAR(100),
	Ciudad			NVARCHAR(100),
	Telefono		NVARCHAR(15),
	Email			NVARCHAR(100),
	CURP			NVARCHAR(18) UNIQUE,
	NSS				NVARCHAR(11),
	Salario			DECIMAL,
	Estado			BIGINT FOREIGN KEY REFERENCES Estado(ID),
	BaseSalario		BIGINT FOREIGN KEY REFERENCES BaseSalario(ID),
	UsuarioAlta		BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta		DATETIME,
	UsuarioMod		BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod		DATETIME
)
GO
RAISERROR('Se ha creado la tabla Empleado', 0, 1)
GO
/*Modificacion de tabla Usuario*/
ALTER TABLE Usuario 
	ADD Empleado BIGINT FOREIGN KEY REFERENCES Empleado(ID)
GO
RAISERROR('Se ha modificado la tabla Empleado', 0, 1)
GO	
/*Creacion de la Tabla Vehiculo*/
CREATE TABLE Vehiculo
(
	ID						BIGINT IDENTITY(1,1) PRIMARY KEY,
	NoSerie					NVARCHAR(17) UNIQUE,
	Modelo					BIGINT FOREIGN KEY REFERENCES Modelo(ID),
	Color					NVARCHAR(100),
	Ano						INT,
	Resposable				NVARCHAR(200),
	NumeroIdentificacion	NVARCHAR(15),
	TipoIdentificacion		BIGINT FOREIGN KEY REFERENCES TipoIdentificacion(ID),
	UsuarioAlta				BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta				DATETIME,
	UsuarioMod				BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod				DATETIME	
)
GO
RAISERROR('Se ha creado la tabla Vehiculo', 0, 1)
GO
/*Creacion de la Tabla Proveedor*/
CREATE TABLE Proveedor
(
	ID				BIGINT IDENTITY(1,1) PRIMARY KEY,
	Tipo			BIT,
	Nombre			NVARCHAR(200),
	Apellido		NVARCHAR(100),
	Apellido2		NVARCHAR(100),
	RFC				NVARCHAR(13),
	Calle			NVARCHAR(100),
	NumeroInterior	NVARCHAR(50),
	NumeroExterior	NVARCHAR(50),
	Colonia			NVARCHAR(100),
	CP				NVARCHAR(5),
	Localidad		NVARCHAR(100),
	Ciudad			NVARCHAR(100),
	Telefono		NVARCHAR(15),
	Email			NVARCHAR(100),
	Estado			BIGINT FOREIGN KEY REFERENCES Estado(ID),
	UsuarioAlta		BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta		DATETIME,
	UsuarioMod		BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod		DATETIME		
)
GO
RAISERROR('Se ha creado la tabla Proveedor', 0, 1)
GO
/*Creacion de la Tabla Producto*/
CREATE TABLE Producto
(
	ID				BIGINT IDENTITY(1,1) PRIMARY KEY,
	Codigo			NVARCHAR(50) UNIQUE,	
	Descripcion		NVARCHAR(200),
	PrecioVenta		MONEY,
	PrecioCompra	MONEY,
	IVA				DECIMAL,
	Observaciones	NVARCHAR(200),
	Servicio		BIT,	
	IVAExcencto		BIT,
	TipoProducto	BIGINT FOREIGN KEY REFERENCES TipoProducto(ID),
	Proveedor		BIGINT FOREIGN KEY REFERENCES Proveedor(ID),
	UsuarioAlta		BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta		DATETIME,
	UsuarioMod		BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod		DATETIME
)
GO
RAISERROR('Se ha creado la tabla Producto', 0, 1)
GO
/*Creacion de la Tabla TipoMovimiento*/
CREATE TABLE TipoMovimiento
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre		NVARCHAR(50) UNIQUE,	
	Tipo		BIT,
	UsuarioAlta	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta	DATETIME,
	UsuarioMod	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod	DATETIME	
)
GO
RAISERROR('Se ha creado la tabla TipoMovimiento', 0, 1)
GO
/*Creacion de la Tabla Movimiento*/
CREATE TABLE Movimiento
(
	ID				BIGINT IDENTITY(1,1) PRIMARY KEY,
	Cantidad		DECIMAL,
	Fecha			DATETIME,
	Importe			MONEY,	
	TipoMoviemiento	BIGINT FOREIGN KEY REFERENCES TipoMovimiento(ID),
	Producto		BIGINT FOREIGN KEY REFERENCES Producto(ID),
	UsuarioAlta		BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta		DATETIME,
	UsuarioMod		BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod		DATETIME
)
GO
RAISERROR('Se ha creado la tabla Movimiento', 0, 1)
GO
/*Creacion de la Tabla GrupoCliente*/
CREATE TABLE GrupoCliente
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre		NVARCHAR(100) UNIQUE,
	UsuarioAlta	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta	DATETIME,
	UsuarioMod	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod	DATETIME
)
GO
RAISERROR('Se ha creado la tabla GrupoCliente', 0, 1)
GO
/*Creacion de la Tabla Cliente*/
CREATE TABLE Cliente
(
	ID				BIGINT IDENTITY(1,1) PRIMARY KEY,
	Tipo			BIT,
	Nombre			NVARCHAR(200),
	Apellido		NVARCHAR(100),
	Apellido2		NVARCHAR(100),
	RFC				NVARCHAR(13),
	Calle			NVARCHAR(100),
	NumeroInterior	NVARCHAR(50),
	NumeroExterior	NVARCHAR(50),
	Colonia			NVARCHAR(100),
	CP				NVARCHAR(5),
	Localidad		NVARCHAR(100),
	Ciudad			NVARCHAR(100),
	Telefono		NVARCHAR(15),
	Email			NVARCHAR(100),
	Estado			BIGINT FOREIGN KEY REFERENCES Estado(ID),
	GrupoCliente	BIGINT FOREIGN KEY REFERENCES GrupoCliente(ID),
	UsuarioAlta		BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta		DATETIME,
	UsuarioMod		BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod		DATETIME
)
GO
RAISERROR('Se ha creado la tabla Cliente', 0, 1)
GO
/*Insercion a Cliente*/
INSERT INTO Cliente(Tipo, Nombre, RFC, Calle, CP, Ciudad, Telefono, Email, Estado, UsuarioAlta, FechaAlta)
	VALUES(0, 'Publico en general', 'XAXX010101000', 'BLVD. Raul Lopez Sanchez KM 4.4', '27000', 'Torreon', '1497407', 'contacto@tianguisdelauto.mx', 1, 1, GETDATE())
GO
/*Creacion de la Tabla Paquete*/
CREATE TABLE Paquete
(
	ID					BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre				NVARCHAR(100) UNIQUE,
	Descripcion			NVARCHAR(200),
	Precio				MONEY,
	ParaGrupoCliente	BIT,
	Activo				BIT,
	FechaInicio			DATETIME,
	FechaFin			DATETIME,
	UsuarioAlta			BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta			DATETIME,
	UsuarioMod			BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod			DATETIME
)
GO
RAISERROR('Se ha creado la tabla Paquete', 0, 1)
GO
/*Creacion de la Tabla PaqueteDia*/
CREATE TABLE PaqueteDia
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Paquete		BIGINT FOREIGN KEY REFERENCES Paquete(ID),
	Dia			BIGINT FOREIGN KEY REFERENCES Dia(ID),
	UsuarioAlta	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta	DATETIME,
	UsuarioMod	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod	DATETIME
)
GO
RAISERROR('Se ha creado la tabla PaqueteDia', 0, 1)
GO
/*Creacion de la Tabla PaqueteGrupoCliente*/
CREATE TABLE PaqueteGrupoCliente
(
	ID				BIGINT IDENTITY(1,1) PRIMARY KEY,
	Paquete			BIGINT FOREIGN KEY REFERENCES Paquete(ID),
	GrupoCliente	BIGINT FOREIGN KEY REFERENCES GrupoCliente(ID)
)
GO
RAISERROR('Se ha creado la tabla PaqueteGrupoCliente', 0, 1)
GO
/*Creacion de la Tabla PaqueteProducto*/
CREATE TABLE PaqueteProducto
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Paquete		BIGINT FOREIGN KEY REFERENCES Paquete(ID),
	Producto	BIGINT FOREIGN KEY REFERENCES Producto(ID)
)
GO
RAISERROR('Se ha creado la tabla PaqueteProducto', 0, 1)
GO
/*Creacion de la Tabla Promocion*/
CREATE TABLE Promocion
(
	ID					BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nombre				NVARCHAR(100) UNIQUE,
	Descripcion			NVARCHAR(200),
	Tipo				INT,
	Valor				DECIMAL,
	Comprar				INT,
	Pagar				INT,
	Activo				BIT,
	FechaInicio			DATETIME,
	FechaFin			DATETIME,
	ParaPaquete			BIT,
	ParaTipoProducto	BIT,
	ParaProducto		BIT,
	ParaGrupoCliente	BIT,
	UsuarioAlta			BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta			DATETIME,
	UsuarioMod			BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod			DATETIME
)
GO
RAISERROR('Se ha creado la tabla Promocion', 0, 1)
GO
/*Creacion de la Tabla PromocionDia*/
CREATE TABLE PromocionDia
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Promocion	BIGINT FOREIGN KEY REFERENCES Promocion(ID),
	Dia			BIGINT FOREIGN KEY REFERENCES Dia(ID),
	UsuarioAlta	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaAlta	DATETIME,
	UsuarioMod	BIGINT FOREIGN KEY REFERENCES Usuario(ID),
	FechaMod	DATETIME
)
GO
RAISERROR('Se ha creado la tabla PromocionDia', 0, 1)
GO
/*Creacion de la Tabla PromocionPaquete*/
CREATE TABLE PromocionPaquete
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Promocion	BIGINT FOREIGN KEY REFERENCES Promocion(ID),
	Paquete		BIGINT FOREIGN KEY REFERENCES Paquete(ID)
)
GO
RAISERROR('Se ha creado la tabla PromocionPaquete', 0, 1)
GO
/*Creacion de la Tabla PromocionTipoProducto*/
CREATE TABLE PromocionTipoProducto
(
	ID				BIGINT IDENTITY(1,1) PRIMARY KEY,
	Promocion		BIGINT FOREIGN KEY REFERENCES Promocion(ID),
	TipoProducto	BIGINT FOREIGN KEY REFERENCES TipoProducto(ID)
)
GO
RAISERROR('Se ha creado la tabla PromocionTipoProducto', 0, 1)
GO
/*Creacion de la Tabla PromocionProducto*/
CREATE TABLE PromocionProducto
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Promocion	BIGINT FOREIGN KEY REFERENCES Promocion(ID),
	Producto	BIGINT FOREIGN KEY REFERENCES Producto(ID)
)
GO
RAISERROR('Se ha creado la tabla PromocionProducto', 0, 1)
GO
/*Creacion de la Tabla PromocionGrupoCliente*/
CREATE TABLE PromocionTipoCliente
(
	ID				BIGINT IDENTITY(1,1) PRIMARY KEY,
	Promocion		BIGINT FOREIGN KEY REFERENCES Promocion(ID),
	GrupoCliente	BIGINT FOREIGN KEY REFERENCES GrupoCliente(ID)
)
GO
RAISERROR('Se ha creado la tabla PromocionGrupoCliente', 0, 1)
GO
/*Creacion de la Tabla Venta*/
CREATE TABLE Venta
(
	ID				BIGINT IDENTITY(1,1) PRIMARY KEY,
	Total			MONEY,	
	Fecha			DATETIME,
	Cliente			BIGINT FOREIGN KEY REFERENCES Cliente(ID),	
	UsuarioVenta	BIGINT FOREIGN KEY REFERENCES Usuario(ID)
)
GO
RAISERROR('Se ha creado la tabla Venta', 0, 1)
GO
/*Creacion de la Tabla VentaDetalle*/
CREATE TABLE VentaDetalle
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Subtotal	MONEY,
	Descripcion	NVARCHAR(200),
	Color		NVARCHAR(50),
	Venta		BIGINT FOREIGN KEY REFERENCES Venta(ID),
	Producto	BIGINT FOREIGN KEY REFERENCES Producto(ID),
	Vehiculo	BIGINT FOREIGN KEY REFERENCES Vehiculo(ID),
	Paquete		BIGINT FOREIGN KEY REFERENCES Paquete(ID),
	Promocion	BIGINT FOREIGN KEY REFERENCES Promocion(ID)
)
GO
RAISERROR('Se ha creado la tabla VentaDetalle', 0, 1)
GO
/*Creacion de la Tabla VentaDia*/
CREATE TABLE VentaDia
(
	ID		BIGINT IDENTITY(1,1) PRIMARY KEY,
	Fecha	DATETIME,
	Total	MONEY
)
GO
RAISERROR('Se ha creado la tabla VentaDia', 0, 1)
GO
/*Creacion de la Tabla Logs*/
CREATE TABLE Logs
(
	ID			BIGINT IDENTITY(1,1) PRIMARY KEY,
	Fecha		DATETIME,
	Descripcion	NVARCHAR(200),
	Usuario		BIGINT FOREIGN KEY REFERENCES Usuario(ID)
)
GO
RAISERROR('Se ha creado la tabla Logs', 0, 1)
GO
/****************************************************************************************************
*								COMIENZA LA INSERCION DE DATOS										*
****************************************************************************************************/

