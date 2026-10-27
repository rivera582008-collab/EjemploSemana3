CREATE DATABASE Membresias;
GO

USE Membresias;
GO

CREATE TABLE Miembros(
IdMiembros INT IDENTITY(1,1) NOT NULL,
Nombre VARCHAR(80) NOT NULL,
Apellido VARCHAR(80) NOT NULL,
FechaInscripcion DATE NOT NULL,
Estado VARCHAR(20) NOT NULL,
CONSTRAINT PK_Miembros PRIMARY KEY(IdMiembros)
);
GO

CREATE TABLE Clase(
IdClase INT IDENTITY(1,1) NOT NULL,
NombreClase VARCHAR(80) NOT NULL,
CostoAdicional DECIMAL(12,2) NOT NULL,
CONSTRAINT PK_Clase PRIMARY KEY(IdClase),
CONSTRAINT CK_Clase CHECK(CostoAdicional > 0)
);
GO

CREATE TABLE Asistencia(
IdAsistencia INT IDENTITY(1,1) NOT NULL,
IdMiembros INT NOT NULL,
IdClase INT NOT NULL,
Fecha DATE,
CONSTRAINT PK_Asistencia PRIMARY KEY(IdAsistencia),
CONSTRAINT FK_Miembros_Asistencia FOREIGN KEY(IdMiembros) REFERENCES Miembros(IdMiembros),
CONSTRAINT FK_Clase_Asistencia FOREIGN KEY(IdClase) REFERENCES Clase(IdClase),
);
GO

INSERT INTO Miembros(Nombre,Apellido,Estado,FechaInscripcion) VALUES
('Carlos','Hernández','Activo','2026-06-2'),
('Sofía','Palma','Activo','2026-06-4'),
('Amilcar','Portillo','Inactivo','2026-06-6'),
('María','López','Inactivo','2026-06-8'),
('Juan','Perez','Activo','2026-08-2'),
('Camila','Landaverde','Activo','2026-08-8');

INSERT INTO Clase(NombreClase,CostoAdicional) VALUES
('Yoga',1.00),
('Spinning',2.00),
('Crossfit',1.00),
('Boxeo',4.00),
('Baile',2.00),
('Relajación',4.00);

INSERT INTO Asistencia(IdMiembros,IdClase,Fecha) VALUES
(1,1,'2026-06-20'),
(2,4,'2026-06-21'),
(5,1,'2026-06-22'),
(6,1,'2026-06-20'),
(1,2,'2026-06-20'),
(6,5,'2026-06-28');

INSERT INTO Asistencia(IdMiembros,IdClase,Fecha) VALUES
(6,1,'2026-06-20'),
(4,2,'2026-06-21');

INSERT INTO Asistencia(IdMiembros,IdClase,Fecha) VALUES
(1,6,'2026-06-20'),
(4,5,'2026-06-21');

INSERT INTO Asistencia(IdMiembros,IdClase,Fecha) VALUES
(1,1,'2026-06-20'),
(2,4,'2026-06-21'),
(5,1,'2026-06-22'),
(6,1,'2026-06-20'),
(1,2,'2026-06-20'),
(6,5,'2026-06-28');


INSERT INTO Asistencia(IdMiembros,IdClase,Fecha) VALUES
(1,1,'2026-06-20'),
(2,4,'2026-06-21'),
(5,1,'2026-06-22'),
(6,1,'2026-06-20'),
(1,2,'2026-06-20'),
(6,5,'2026-06-28');


INSERT INTO Asistencia(IdMiembros,IdClase,Fecha) VALUES
(1,3,'2026-06-20'),
(2,3,'2026-06-21'),
(5,3,'2026-06-22'),
(6,3,'2026-06-20'),
(1,2,'2026-06-20'),
(6,5,'2026-06-28');

INSERT INTO Asistencia(IdMiembros,IdClase,Fecha) VALUES
(1,1,'2026-06-20'),
(2,4,'2026-06-21'),
(5,1,'2026-06-22'),
(6,1,'2026-06-20'),
(1,2,'2026-06-20'),
(6,5,'2026-06-28');

INSERT INTO Asistencia(IdMiembros,IdClase,Fecha) VALUES
(1,1,'2026-06-20'),
(2,4,'2026-06-21'),
(5,1,'2026-06-22'),
(6,1,'2026-06-20'),
(1,2,'2026-06-20'),
(6,5,'2026-06-28');

INSERT INTO Asistencia(IdMiembros,IdClase,Fecha) VALUES
(1,1,'2026-06-20'),
(2,4,'2026-06-21'),
(5,1,'2026-06-22'),
(6,1,'2026-06-20'),
(1,2,'2026-06-20'),
(6,5,'2026-06-28');

INSERT INTO Asistencia(IdMiembros,IdClase,Fecha) VALUES
(1,1,'2026-06-20'),
(2,4,'2026-06-21'),
(5,1,'2026-06-22'),
(6,1,'2026-06-20'),
(1,2,'2026-06-20'),
(6,5,'2026-06-28');

INSERT INTO Asistencia(IdMiembros,IdClase,Fecha) VALUES
(1,1,'2026-06-20'),
(2,4,'2026-06-21'),
(5,1,'2026-06-22'),
(6,1,'2026-06-20'),
(1,2,'2026-06-20'),
(6,5,'2026-06-28');


SELECT * FROM Miembros WHERE YEAR(FechaInscripcion) = '2026' AND Estado = 'Activo'

SELECT CONCAT(M.Nombre, ' ',M.Apellido) AS Cliente,C.NombreClase,A.Fecha
FROM Miembros AS M
INNER JOIN Asistencia AS A ON M.IdMiembros = A.IdMiembros
INNER JOIN Clase AS C ON C.IdClase = A.IdClase;

SELECT Miembros.Nombre,Miembros.Apellido, COUNT(*) AS Asistencias
FROM Miembros INNER JOIN Asistencia AS A ON Miembros.IdMiembros = A.IdMiembros
GROUP BY Miembros.Nombre,Miembros.Apellido


SELECT Miembros.Nombre,Miembros.Apellido, COUNT(*) AS Clases_Tomadas
FROM Miembros INNER JOIN Asistencia AS A ON Miembros.IdMiembros = A.IdMiembros
GROUP BY Miembros.Nombre,Miembros.Apellido


SELECT TOP 2 NombreClase,COUNT(IdAsistencia) AS Mas_Popular
FROM Asistencia AS A
INNER JOIN Clase AS C ON C.IdClase = A.IdClase
GROUP BY NombreClase
ORDER BY Mas_Popular DESC;


SELECT NombreClase,SUM(CostoAdicional) AS Dinero_Total
FROM Miembros AS M
INNER JOIN Asistencia AS A ON M.IdMiembros = A.IdMiembros
INNER JOIN Clase AS C ON C.IdClase = A.IdClase
GROUP BY NombreClase

SELECT SUM(CostoAdicional) AS Dinero_Total
FROM Miembros AS M
INNER JOIN Asistencia AS A ON M.IdMiembros = A.IdMiembros
INNER JOIN Clase AS C ON C.IdClase = A.IdClase


SELECT C.IdClase,C.NombreClase,C.CostoAdicional, COUNT(A.IdAsistencia)AS Total_Asistencia,COUNT(A.IdAsistencia) * C.CostoAdicional AS Dinero_Total
FROM Miembros AS M
INNER JOIN Asistencia AS A ON M.IdMiembros = A.IdMiembros
INNER JOIN Clase AS C ON C.IdClase = A.IdClase
GROUP BY C.IdClase,C.NombreClase,C.CostoAdicional

