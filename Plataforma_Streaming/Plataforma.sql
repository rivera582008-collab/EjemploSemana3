CREATE DATABASE Spotify;
GO

USE Spotify;
GO

CREATE TABLE Artista(
IdArtista INT IDENTITY(1,1) NOT NULL,
NombreArtistico VARCHAR(80) NOT NULL,
GeneroPrincipal VARCHAR(80) NOT NULL,
CONSTRAINT PK_Artista PRIMARY KEY(IdArtista)
);
GO

CREATE TABLE Canciones(
IdCanciones INT IDENTITY(1,1) NOT NULL,
Titulo VARCHAR(80) NOT NULL,
DuracionSegundos INT NOT NULL,
IdArtista INT NOT NULL,
CONSTRAINT FK_Artista_Canciones FOREIGN KEY(IdArtista) REFERENCES Artista(IdArtista)
);
GO


INSERT INTO Artista(NombreArtistico,GeneroPrincipal) VALUES
('Wisin y Yandel','Reggeaeton'),
('Dady Yankee','Reggeaeton'),
('Ozuna','Reggeaeton'),
('Julio Voltio','Rap'),
('Tego Calderón','Reggeaeton'),
('Romeo Sántos','Bachata');

INSERT INTO Canciones(Titulo,DuracionSegundos,IdArtista) VALUES
('Atrevete',400,1),
('Punto Y Aparte',450,5),
('Tu Foto',400,3),
('Guasa Guasa',300,5),
('El Teléfono',350,1),
('Imitadora',360,6);




SELECT A.NombreArtistico AS 'Nombre Artístico',A.GeneroPrincipal,C.Titulo,C.DuracionSegundos AS 'Duracion En Segundos'
FROM Artista AS A INNER JOIN Canciones AS C
ON A.IdArtista = C.IdArtista



SELECT A.NombreArtistico,COUNT(*) AS Cantidad_Canciones,SUM(C.DuracionSegundos) AS Duracion_Acumulada
FROM Artista AS A INNER JOIN Canciones AS C
ON A.IdArtista = C.IdArtista
GROUP BY A.NombreArtistico


SELECT A.NombreArtistico,COUNT(*) AS Cantidad_Canciones,SUM(C.DuracionSegundos) AS Duracion_Acumulada
FROM Artista AS A INNER JOIN Canciones AS C
ON A.IdArtista = C.IdArtista
GROUP BY A.NombreArtistico
HAVING SUM(C.DuracionSegundos) > 500



SELECT A.NombreArtistico,C.Titulo
FROM Artista AS A INNER JOIN Canciones AS C
ON A.IdArtista = C.IdArtista
WHERE C.DuracionSegundos > 380
GO

CREATE VIEW Subconsulta AS
SELECT Canciones.Titulo 
FROM Canciones
WHERE Canciones.DuracionSegundos > (SELECT AVG(DuracionSegundos) FROM Canciones)
GO




CREATE VIEW Reporte_Artista AS 

SELECT A.NombreArtistico,COUNT(*) AS Cantidad_Canciones,SUM(C.DuracionSegundos) AS Duracion_Acumulada, AVG(C.DuracionSegundos) AS Promedio_Duracion
FROM Artista AS A INNER JOIN Canciones AS C
ON A.IdArtista = C.IdArtista
GROUP BY A.NombreArtistico
GO

SELECT * FROM Reporte_Artista
WHERE Cantidad_Canciones > 1

SELECT * FROM Reporte_Artista

SELECT * FROM Subconsulta
GO

CREATE VIEW Join_Juntos_Reportes AS

SELECT 
A.IdArtista,
A.NombreArtistico AS Nombre_Artista,
A.GeneroPrincipal,
C.IdCanciones,
C.Titulo,
C.DuracionSegundos
FROM Artista AS A INNER JOIN Canciones AS C
ON A.IdArtista = C.IdArtista
GO

SELECT Nombre_Artista,COUNT(*) AS Cantidad
FROM Join_Juntos_Reportes
GROUP BY Nombre_Artista;
GO

SELECT * FROM Join_Juntos_Reportes


SELECT A.NombreArtistico AS 'Nombre Artístico',A.GeneroPrincipal,C.Titulo,C.DuracionSegundos AS 'Duracion En Segundos'
FROM Artista AS A LEFT JOIN Canciones AS C
ON A.IdArtista = C.IdArtista

SELECT A.IdArtista,A.NombreArtistico AS 'Nombre Artístico',A.GeneroPrincipal,C.Titulo
FROM Artista AS A INNER JOIN Canciones AS C
ON A.IdArtista = C.IdArtista
WHERE NombreArtistico LIKE 'Teg%'

UPDATE Artista 
SET NombreArtistico = 'El Abayarde'
WHERE IdArtista = 5;

SELECT Artista.NombreArtistico,Titulo FROM Canciones
INNER JOIN Artista ON Artista.IdArtista = Canciones.IdCanciones
WHERE Titulo = 'Atrevete'

SELECT Nombre_Artista,Titulo
FROM Join_Juntos_Reportes
WHERE Titulo = 'Atrevete'
GO

CREATE PROCEDURE BuscarCanciones
    @Nombre VARCHAR(80)
AS
BEGIN
SELECT A.NombreArtistico AS 'Nombre Artístico',A.GeneroPrincipal,C.Titulo,C.DuracionSegundos AS 'Duracion En Segundos'
FROM Artista AS A INNER JOIN Canciones AS C
ON A.IdArtista = C.IdArtista
WHERE A.NombreArtistico LIKE '%' + @Nombre + '%';

END;
GO

EXEC BuscarCanciones 'Aba'

EXEC BuscarCanciones 'W'

SELECT Artista.IdArtista,Artista.NombreArtistico, Artista.GeneroPrincipal
FROM Artista WHERE Artista.NombreArtistico LIKE '%a%'
