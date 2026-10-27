CREATE DATABASE Gimnasio;
GO

USE Gimnasio;
GO

CREATE TABLE Planes(
IdPlan INT IDENTITY(1,1) NOT NULL,
Tipo_Plan VARCHAR(80) NOT NULL,
CONSTRAINT PK_Planes PRIMARY KEY(IdPlan)
);
GO

CREATE TABLE Cliente(
IdCliente INT IDENTITY(1,1) NOT NULL,
Nombre VARCHAR(80) NOT NULL,
Apellido VARCHAR(80) NOT NULL,
Telefono VARCHAR(40) NOT NULL,
CONSTRAINT PK_Cliente PRIMARY KEY(IdCliente),
);
GO


CREATE TABLE Inscripcion(
IdInscripcion INT IDENTITY(1,1) NOT NULL,
IdCliente INT,
IdPlan INT,
Fecha DATE,
CONSTRAINT PK_Incricion PRIMARY KEY(IdInscripcion),
CONSTRAINT FK_Cliente_Inscricion FOREIGN KEY(IdCliente) REFERENCES Cliente(IdCliente),
CONSTRAINT FK_Planes_Incripcion FOREIGN KEY(IdPlan) REFERENCES Planes(IdPlan)
);
GO


INSERT INTO Planes(Tipo_Plan) VALUES
('Plan Mensual $25'),
('Plan Anual $200'),
('Plan VIP Mensual $50'),
('Plan VIP Anual $400');


INSERT INTO Cliente(Nombre,Apellido,Telefono) VALUES
('Carlos','Hernández','7909865'),
('Juan','Ramirez','79096878'),
('Luisa','Row','79094565'),
('Sofía','Landaverde','68789564'),
('Camila','Sandoval','78909899'),
('Marcos','Darío','7989005');


INSERT INTO Inscripcion(IdCliente,IdPlan,Fecha) VALUES
(1,1,'2026-08-10'),
(2,3,'2026-08-11'),
(1,3,'2026-08-12'),
(4,4,'2026-09-10'),
(4,3,'2026-09-11'),
(6,1,'2026-08-14'),
(5,2,'2026-09-10'),
(3,4,'2026-09-20');


ALTER TABLE Planes ADD Precio DECIMAL(12,2);

UPDATE Planes SET Precio = 50.00 WHERE IdPlan = 1;

UPDATE Planes SET Precio = 200.00 WHERE IdPlan = 2;

UPDATE Planes SET Precio = 100.00 WHERE IdPlan = 3;

UPDATE Planes SET Precio = 400.00 WHERE IdPlan = 4;


UPDATE Planes SET Tipo_Plan = 'Plan Mensual' WHERE IdPlan = 1;

UPDATE Planes SET Tipo_Plan = 'Plan Anual' WHERE IdPlan = 2;

UPDATE Planes SET Tipo_Plan = 'Plan VIP Mensual' WHERE IdPlan = 3;

UPDATE Planes SET Tipo_Plan = 'Plan VIP Anual' WHERE IdPlan = 4;

SELECT Planes.Tipo_Plan,COUNT(*) AS Total_Veces_Comprado
FROM Inscripcion INNER JOIN Planes ON Inscripcion.IdPlan = Planes.IdPlan
INNER JOIN Cliente ON Cliente.IdCliente = Inscripcion.IdCliente
GROUP BY Planes.Tipo_Plan
ORDER BY Total_Veces_Comprado DESC

-- Finanzas por plan

SELECT Planes.Tipo_Plan,Planes.Precio,SUM (Precio) AS Dinero_Recaudado
FROM Inscripcion INNER JOIN Planes ON Inscripcion.IdPlan = Planes.IdPlan
INNER JOIN Cliente ON Cliente.IdCliente = Inscripcion.IdCliente
GROUP BY Planes.Tipo_Plan,Planes.Precio
ORDER BY Dinero_Recaudado DESC

-- Cliente Estrella

SELECT TOP 1 Cliente.Nombre,SUM(Precio) AS Cliente_Estrella
FROM Inscripcion INNER JOIN Planes ON Inscripcion.IdPlan = Planes.IdPlan
INNER JOIN Cliente ON Cliente.IdCliente = Inscripcion.IdCliente
GROUP BY Cliente.Nombre
ORDER BY SUM(Precio) DESC


-- Dinero recaudado

SELECT SUM(Precio) AS Dinero_Reaudado
FROM Inscripcion INNER JOIN Planes ON Inscripcion.IdPlan = Planes.IdPlan
INNER JOIN Cliente ON Cliente.IdCliente = Inscripcion.IdCliente