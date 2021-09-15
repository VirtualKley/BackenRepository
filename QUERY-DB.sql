USE master
GO

CREATE DATABASE DBProducts
GO

USE DBProducts
GO

CREATE TABLE TBCategoria(
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nombre VARCHAR(50)
)
GO

CREATE TABLE TBProveedor(
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nombre VARCHAR(50)
)
GO

CREATE TABLE TBMarca(
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nombre VARCHAR(50)
)
GO

CREATE TABLE TBProducto(
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(50) NOT NULL,
	categoria_id INT NOT NULL FOREIGN KEY REFERENCES TBCategoria(id),
	proveedor_id INT NOT NULL FOREIGN KEY REFERENCES TBProveedor(id),
	marca_id INT NOT NULL FOREIGN KEY REFERENCES TBMarca(id),
	medidas VARCHAR(50) NOT NULL,
	precio_unitario decimal(18,2) NOT NULL
)
GO

CREATE TABLE Productos_Historico(
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	product_id INT NOT NULL,
	descripcion VARCHAR(50) NOT NULL,
	categoria_id INT NOT NULL,
	proveedor_id INT NOT NULL,
	marca_id INT NOT NULL,
	medidas VARCHAR(50) NOT NULL,
	precio_unitario decimal NOT NULL,
	fecha DATE
)
GO

CREATE TRIGGER TR_producto_actualizar ON TBProducto
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Productos_Historico(
		product_id,
		descripcion,
		categoria_id,
		proveedor_id,
		marca_id,
		medidas,
		precio_unitario,
		fecha
	)
	SELECT
		d.id,
		d.descripcion,
		d.categoria_id,
		d.proveedor_id,
		d.marca_id,
		d.medidas,
		d.precio_unitario,
		GETDATE()
	FROM 
		inserted AS i,
		deleted AS d
END
GO

CREATE PROCEDURE SP_listar_productos
@desc VARCHAR(50)
AS
	SELECT * FROM TBProducto WHERE descripcion LIKE '%'+@desc+'%'
GO

CREATE PROCEDURE SP_listar_categorias
@nombre VARCHAR(50)
AS
	SELECT * FROM TBCategoria WHERE nombre LIKE '%'+@nombre+'%'
GO

CREATE PROCEDURE SP_listar_proveedores
@nombre VARCHAR(50)
AS
	SELECT * FROM TBProveedor WHERE nombre LIKE '%'+@nombre+'%'
GO

CREATE PROCEDURE SP_listar_marcas
@nombre VARCHAR(50)
AS
	SELECT * FROM TBMarca WHERE nombre LIKE '%'+@nombre+'%'
GO

