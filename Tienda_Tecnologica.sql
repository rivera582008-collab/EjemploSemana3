CREATE DATABASE TiendaTecnologica;
GO

USE TiendaTecnologica;
GO


CREATE TABLE Categoria(
IdCategoria INT IDENTITY(1,1) NOT NULL,
Nombre_Categoria VARCHAR(80) NOT NULL,
CONSTRAINT FK_Categoria PRIMARY KEY(IdCategoria)
);
GO

CREATE TABLE Producto(
IdProducto INT IDENTITY(1,1) NOT NULL,
Nombre VARCHAR(80) NOT NULL,
IdCategoria INT,
Precio DECIMAL(12,2) NOT NULL,
CONSTRAINT PF_Producto PRIMARY KEY(IdProducto),
CONSTRAINT FK_Producto_Categoria FOREIGN KEY(IdCategoria) REFERENCES Categoria(IdCategoria)
);
GO

CREATE TABLE Venta(
IdVenta INT IDENTITY(1,1) NOT NULL,
IdProducto INT,
Cantidad INT NOT NULL,
Fecha_Venta DATE NOT NULL,
CONSTRAINT PK_Venta PRIMARY KEY(IdVenta),
CONSTRAINT FK_Producto_Venta FOREIGN KEY(IdProducto) REFERENCES Producto(IdProducto)
);
GO

INSERT INTO Categoria(Nombre_Categoria) VALUES
('Tecnología'),
('Cosméticos'),
('Papelería'),
('Accesorios');

INSERT INTO Producto(Nombre,IdCategoria,Precio) VALUES
('HP VICTUS DDR5 Ryzen 9',1,800.00),
('LENOVO LEGGION GAMING',1,790.00),
('Cuaderno 200 Hojas Rayado',3,2.00),
('Mouse Inteligente',4,20.00),
('Lápiz Facela 12 Unidades',3,1.00),
('Maquillaje Para Dama',2,4.00),
('Delineador Negro',2,2.00),
('Cargador Samsung',4,4.00),
('Samsung Galaxy A32',1,400.00),
('Borador Facela 4 Unidades',3,1.00)

INSERT INTO Venta(IdProducto,Cantidad,Fecha_Venta) VALUES 
(1,4,'2026-08-10'),
(10,8,'2026-08-12'),
(9,1,'2026-08-14'),
(3,8,'2026-08-15'),
(4,2,'2026-09-10'),
(2,1,'2026-09-14');

INSERT INTO Venta(IdProducto,Cantidad,Fecha_Venta) VALUES 
(10,6,'2026-08-20');

INSERT INTO Venta(IdProducto,Cantidad,Fecha_Venta) VALUES 
(10,6,'2026-06-20'),
(10,6,'2026-09-20'),
(2,1,'2026-09-20'),
(6,6,'2026-09-26');

SELECT Producto.Nombre AS 'Nombre Del Producto',Categoria.Nombre_Categoria AS 'Nombre Categoria',Producto.Precio,Venta.Fecha_Venta
FROM Categoria
INNER JOIN Producto ON Categoria.IdCategoria = Producto.IdCategoria
INNER JOIN Venta ON Producto.IdProducto = Venta.IdProducto
WHERE Precio > 100
ORDER BY Precio DESC; 

SELECT Producto.Nombre,COUNT(*) AS Cantidad_De_Ventas,SUM(Venta.Cantidad * Producto.Precio) AS Total,AVG(Venta.Cantidad * Producto.Precio) AS Promedio
FROM Producto INNER JOIN Venta ON Venta.IdProducto = Producto.IdProducto
GROUP BY Producto.Nombre




SELECT Producto.Nombre,SUM(Venta.Cantidad) AS Total_Unidades
FROM Producto INNER JOIN Venta ON Venta.IdProducto = Producto.IdProducto
GROUP BY Producto.Nombre


SELECT SUM(Venta.Cantidad * Precio) AS Total_Dinero
FROM Producto INNER JOIN Venta ON Venta.IdProducto = Producto.IdProducto

SELECT SUM(Venta.Cantidad) AS Total_Ventas
FROM Producto INNER JOIN Venta ON Venta.IdProducto = Producto.IdProducto

SELECT TOP 1 Producto.Nombre, (Venta.Cantidad * Producto.Precio) AS Venta_Mayor
FROM Producto INNER JOIN Venta ON Venta.IdProducto = Producto.IdProducto
ORDER BY Venta_Mayor DESC;

SELECT TOP 1 Producto.Nombre, (Venta.Cantidad * Producto.Precio) AS Venta_Menor
FROM Producto INNER JOIN Venta ON Venta.IdProducto = Producto.IdProducto
ORDER BY Venta_Menor ASC;

SELECT * FROM (SELECT TOP 1 Producto.Nombre, (Venta.Cantidad * Producto.Precio) AS monto , 'Mas grande' AS tipo
 FROM Producto INNER JOIN Venta ON Venta.IdProducto = Producto.IdProducto
 ORDER BY (Venta.Cantidad * Producto.Precio) DESC
) AS Venta_Maxima

UNION ALL

SELECT * FROM (SELECT TOP 1 Producto.Nombre, (Venta.Cantidad * Producto.Precio) AS monto, 'Mas Pequeño' AS tipo
 FROM Venta JOIN Producto ON Venta.IdProducto = Producto.IdProducto
 ORDER BY (Venta.Cantidad * Producto.Precio) ASC
) AS Venta_Minima
