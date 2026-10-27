CREATE DATABASE BibliotecaUniversitaria;
GO

USE BibliotecaUniversitaria;
GO

CREATE TABLE Libro(
IdLibro INT IDENTITY(1,1) NOT NULL,
TituloLibro VARCHAR(100) NOT NULL,
AutorLibro VARCHAR(100) NOT NULL,
FechaPublicacion DATE,
Estado VARCHAR(20),
CONSTRAINT PK_Libro PRIMARY KEY(IdLibro)
);
GO

CREATE TABLE Estudiante(
IdEstudiante INT IDENTITY(1,1) NOT NULL,
NombreEstudiante VARCHAR(80) NOT NULL,
Carrera VARCHAR(80) NOT NULL,
CONSTRAINT PK_Estudiante PRIMARY KEY(IdEstudiante)
);
GO

CREATE TABLE Prestamo(
IdPrestamo INT IDENTITY(1,1) NOT NULL,
IdEstudiante INT NOT NULL,
IdLibro INT NOT NULL,
FechaPrestamo DATE NOT NULL,
FechaDevolucion DATE NULL,
CONSTRAINT PK_Prestamo PRIMARY KEY(IdPrestamo),
CONSTRAINT FK_Estudiante_Prestamos FOREIGN KEY(IdEstudiante) REFERENCES Estudiante(IdEstudiante),
CONSTRAINT FK_Libro_Prestamos FOREIGN KEY(IdLibro) REFERENCES Libro(IdLibro)
);
GO

INSERT INTO Libro(TituloLibro,AutorLibro,FechaPublicacion,Estado) VALUES
('Cien Años De Soledad','Gabriel Marquez','1994-08-9','Disponible'),
('Un Lucero','Mijares','1992-08-9','Disponible'),
('Cazador De Almas','Alexander Rivera','2026-09-20','Disponible'),
('La Bruja','Camila Josefina','1994-09-2','Disponible');

INSERT INTO Estudiante(NombreEstudiante,Carrera) VALUES
('Jose Peñate','Licenciatura En Marketing'),
('Matías Delgado','Administración'),
('Karla López','Ingeniería En Sistemas Y Computación'),
('Juan José','Ingeniería En Sistemas Y Computación'),
('Camila López','Ingeniería En Sistemas Y Computación'),
('Lucía Stewar','Licenciatura En Psicología');

INSERT INTO Prestamo(IdEstudiante,IdLibro,FechaPrestamo) VALUES
(1,2,'2026-09-10'),
(2,4,'2026-09-12'),
(3,3,'2026-09-14'),
(4,1,'2026-09-16');

INSERT INTO Prestamo(IdEstudiante,IdLibro,FechaPrestamo,FechaDevolucion) VALUES
(5,2,'2026-09-10','2026-09-12'),
(6,4,'2026-09-12','2026-10-10');


SELECT Estudiante.NombreEstudiante
FROM Estudiante INNER JOIN Prestamo ON Estudiante.IdEstudiante = Prestamo.IdEstudiante
INNER JOIN Libro ON Prestamo.IdLibro = Libro.IdLibro
WHERE FechaDevolucion IS NULL

SELECT Estudiante.Carrera,COUNT(*) AS Libros_Prestados_Por_Carrera
FROM Estudiante INNER JOIN Prestamo ON Estudiante.IdEstudiante = Prestamo.IdEstudiante
INNER JOIN Libro ON Prestamo.IdLibro = Libro.IdLibro
GROUP BY Estudiante.Carrera
ORDER BY Libros_Prestados_Por_Carrera DESC;


SELECT Estudiante.NombreEs tudiante,Estudiante.Carrera,Libro.TituloLibro,Libro.AutorLibro,Libro.FechaPublicacion,Libro.Estado
FROM Estudiante INNER JOIN Prestamo ON Estudiante.IdEstudiante = Prestamo.IdEstudiante
INNER JOIN Libro ON Prestamo.IdLibro = Libro.IdLibro

SELECT * FROM Libro

