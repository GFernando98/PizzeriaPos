
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

CREATE TABLE Direccion (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClienteId INT NOT NULL,
    Calle NVARCHAR(150) NOT NULL,
    Numero INT NOT NULL,
    Ciudad NVARCHAR(150) NOT NULL,
    Pais NVARCHAR(70) NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
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

CREATE TABLE PedidosDetalle (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PedidoId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Impuesto DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id),
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id)
);


CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(10) NOT NULL,
    Password NVARCHAR(100) NOT NULL
);


