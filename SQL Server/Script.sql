
--Creacion de base de datos
CREATE DATABASE POSPizzeria

--Usar base de datos
USE POSPizzeria

-- Creacion de modelos/tablas
CREATE TABLE Cliente (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255) NOT NULL,
    Apellido NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL
);

CREATE TABLE Direccion (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClienteId INT NOT NULL,
    Calle NVARCHAR(255) NOT NULL,
    Numero INT NOT NULL,
    Ciudad NVARCHAR(255) NOT NULL,
    Pais NVARCHAR(255) NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
);

CREATE TABLE Producto (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255) NOT NULL,
    Descripcion NVARCHAR(500) NULL,
    Precio DECIMAL(10,2) NOT NULL
);

CREATE TABLE Pedido (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClienteId INT NOT NULL,
    FechaPedido DATE NOT NULL,
    TotalPedido DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Cliente(id)
);

CREATE TABLE PedidoDetalle (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PedidoId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Impuesto DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ProductoId) REFERENCES Producto(Id),
    FOREIGN KEY (PedidoId) REFERENCES Pedido(Id)
);


CREATE TABLE Usuario (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(50) NOT NULL,
    Password BINARY(64) NOT NULL
);


