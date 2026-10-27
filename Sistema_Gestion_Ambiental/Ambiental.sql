CREATE DATABASE EcoRastreo;
GO 

USE EcoRastreo;
GO

CREATE TABLE Material(
IdMaterial INT IDENTITY(1,1) NOT NULL,
Nombre VARCHAR(80) NOT NULL,
Puntos_Recompensa INT NOT NULL,
CONSTRAINT PK_Material PRIMARY KEY(IdMaterial),
CONSTRAINT UQ_Material_Nombre UNIQUE(Nombre),
CONSTRAINT CK_Material_Puntos CHECK(Puntos_Recompensa >= 0)
);
GO

CREATE TABLE CentroReciclaje(
IdCentroReciclaje INT IDENTITY(1,1) NOT NULL,
Nombre_Centro VARCHAR(150) NOT NULL,
Direccion VARCHAR(250) NOT NULL,
Latitud DECIMAL(10,7) NOT NULL,
Longitud DECIMAL(10,7) NOT NULL,
CONSTRAINT PK_CentroReciclaje PRIMARY KEY(IdCentroReciclaje),
CONSTRAINT UQ_Centro_Nombre UNIQUE(Nombre_Centro),
);
GO

CREATE TABLE CentroMaterial(
IdCentroReciclaje INT NOT NULL,
IdMaterial INT,
CONSTRAINT PK_CentroMaterial PRIMARY KEY(IdCentroReciclaje,IdMaterial),
CONSTRAINT FK_Reciclaje_CentroMaterial FOREIGN KEY(IdCentroReciclaje) REFERENCES CentroReciclaje(IdCentroReciclaje),
CONSTRAINT FK_Material_CentroMaterial FOREIGN KEY(IdMaterial) REFERENCES Material(IdMaterial)
);
GO

INSERT INTO Material(Nombre,Puntos_Recompensa) VALUES 
('Electrónicos',60),
('Vidrío',40),
('Papel',10),
('Plástico',20);

INSERT INTO CentroReciclaje(Nombre_Centro,Direccion,Latitud,Longitud) VALUES 
('Recicla Para Salvar Al Planeta','Calle a Chalatenango KM 68',210.40,200.9),
('Ayuda Y El Planeta Te Lo Agradecerá','Calle a Nueva Concepción KM 68',300.40,400.9);


INSERT INTO CentroMaterial(IdMaterial,IdCentroReciclaje) VALUES
(1,1),
(1,2),
(2,2),
(3,2),
(4,1),
(4,2);

SELECT CentroReciclaje.Nombre_Centro,CentroReciclaje.Direccion,Material.Nombre AS Recibe,Material.Puntos_Recompensa AS 'Recompensa Por Reciclar Un Material De Estos'
FROM Material INNER JOIN CentroMaterial ON CentroMaterial.IdMaterial = Material.IdMaterial
INNER JOIN CentroReciclaje ON CentroReciclaje.IdCentroReciclaje = CentroMaterial.IdCentroReciclaje


SELECT CentroReciclaje.Nombre_Centro,CentroReciclaje.Direccion,Material.Nombre AS Recibe
FROM Material INNER JOIN CentroMaterial ON CentroMaterial.IdMaterial = Material.IdMaterial
INNER JOIN CentroReciclaje ON CentroReciclaje.IdCentroReciclaje = CentroMaterial.IdCentroReciclaje
WHERE Nombre = 'Vidrío'

SELECT CentroReciclaje.Nombre_Centro,CentroReciclaje.Latitud AS Ubicacion_X ,CentroReciclaje.Longitud AS Ubicacion_Y
FROM CentroReciclaje;


SELECT CentroReciclaje.Nombre_Centro,CentroReciclaje.Direccion, STRING_AGG(Material.Nombre,', ') AS Todos_Los_Materiales
FROM Material INNER JOIN CentroMaterial ON CentroMaterial.IdMaterial = Material.IdMaterial
INNER JOIN CentroReciclaje ON CentroReciclaje.IdCentroReciclaje = CentroMaterial.IdCentroReciclaje
GROUP BY CentroReciclaje.Nombre_Centro,CentroReciclaje.Direccion

SELECT CentroReciclaje.Nombre_Centro,COUNT(*) AS Cantidad_Materiales
FROM CentroReciclaje INNER JOIN CentroMaterial ON CentroMaterial.IdCentroReciclaje = CentroReciclaje.IdCentroReciclaje
GROUP BY CentroReciclaje.Nombre_Centro

SELECT * FROM Material;