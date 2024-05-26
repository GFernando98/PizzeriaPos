
--Creacion de base de datos
CREATE DATABASE POSPizzeria

--Usar base de datos
USE POSPizzeria

-- Creacion de modelos/tablas
CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);

CREATE TABLE TiposDirecciones(
  Id INT PRIMARY KEY IDENTITY(1,1),
  Descripcion NVARCHAR(150)
)

--Datos TiposDirecciones
INSERT INTO TiposDirecciones (Descripcion)
  VALUES (N'Casa');
INSERT INTO TiposDirecciones (Descripcion)
  VALUES (N'Trabajo');

CREATE TABLE Direcciones (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClienteId INT NOT NULL,
    TipoDireccionId INT NOT NULL,
    Calle NVARCHAR(150) NOT NULL,
    Numero INT NOT NULL,
    Ciudad NVARCHAR(150) NOT NULL,
    Pais NVARCHAR(70) NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    FOREIGN KEY (TipoDireccionId) REFERENCES TiposDirecciones(Id)
);

CREATE VIEW DireccionesView
AS
SELECT A.Id
      ,A.ClienteId
      ,CONCAT(C.Nombre, ' ', C.Apellido) AS Cliente
      ,A.TipoDireccionId
      ,B.Descripcion AS TipoDireccion
      ,A.Calle
      ,A.Numero
      ,A.Ciudad
      ,A.Pais  
FROM 
Direcciones AS A
INNER JOIN TiposDirecciones AS B ON A.TipoDireccionId = B.Id
INNER JOIN Clientes AS C ON A.ClienteId = C.Id

CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Codigo NVARCHAR(50) UNIQUE NOT NULL,
    Nombre NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(500) NULL,
    Precio DECIMAL(10,2) NOT NULL
);

CREATE TABLE Pedidos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClienteId INT NOT NULL,
    FechaPedido DATE NOT NULL,
    TotalPedido DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

ALTER VIEW PedidosView
AS
SELECT
  A.Id
 ,A.ClienteId
 ,A.Correlativo
 ,CONCAT(B.Nombre, ' ', B.Apellido) AS Cliente
 ,A.FechaPedido
 ,A.TotalPedido
FROM 
Pedidos AS A
INNER JOIN Clientes AS B ON A.ClienteId = B.Id;

CREATE TABLE PedidosDetalle (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PedidoId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Impuesto DECIMAL(10,2) NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id),
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id)
);

CREATE VIEW PedidosDetalleView
AS
SELECT
  A.Id
 ,A.PedidoId
 ,A.ProductoId
 ,B.Codigo AS Codigo
 ,B.Nombre AS Producto
 ,A.Cantidad
 ,B.Precio AS PrecioUnitario
 ,A.Impuesto
 ,A.Total
FROM PedidosDetalle AS A
INNER JOIN Productos AS B ON A.ProductoId = B.Id;


CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(10) NOT NULL,
    Password NVARCHAR(100) NOT NULL
);


