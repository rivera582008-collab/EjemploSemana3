CREATE DATABASE ControlDeVuelos;
GO

USE ControlDeVuelos;
GO 

CREATE TABLE Vuelo(
IdVuelo int IDENTITY(1,1) not null,
Origen VARCHAR(100) NOT NULL,
Destino VARCHAR(100) NOT NULL,
CapacidadMaxima INT NOT NULL,
PrecioAsiento DECIMAL(12,2) NOT NULL,
CONSTRAINT PK_Vuelo PRIMARY KEY(IdVuelo)
);
GO

CREATE TABLE Pasajero(
IdPasajero INT IDENTITY(1,1) NOT NULL,
NombrePasajero VARCHAR(60),
ApellidoPasajero VARCHAR(60),
NacionalidadPasajero VARCHAR(80),
CONSTRAINT PK_Pasajero PRIMARY KEY(IdPasajero)  
);
GO

CREATE TABLE Reserva(
IdReserva INT IDENTITY(1,1) NOT NULL,
IdVuelo INT NOT NULL,
IdPasajero INT NOT NULL,
FechaReserva DATE NOT NULL,
CONSTRAINT PK_Reserva PRIMARY KEY(IdReserva),
CONSTRAINT FK_Vuelo_Reserva FOREIGN KEY(IdVuelo) REFERENCES Vuelo(IdVuelo),
CONSTRAINT FK_Pasajero_Reserva FOREIGN KEY(IdPasajero) REFERENCES Pasajero(IdPasajero)
);
GO

INSERT INTO Vuelo(Origen,Destino,PrecioAsiento,CapacidadMaxima) VALUES
('España','París',200.40,400),
('El Salvador','Madrid',200.80,200),
('México','París',400.40,200),
('Ecuador','Francia',200.40,400),
('Francia','Estados Unidos',200.40,400),
('Portugal','Roma',200.40,2);

INSERT INTO Pasajero(NombrePasajero,ApellidoPasajero,NacionalidadPasajero) VALUES
('Juan','Landaverde','Mexico'),
('Pedro','Peraza','El Salvador'),
('Camila','Portillo','España'),
('Sofía','Stewar','Francia'),
('Laura','Vega','Portugal'),
('Lucas','Arnoldo','China');

INSERT INTO Reserva(IdVuelo,IdPasajero,FechaReserva) VALUES
(1,2,'2024-08-16'),
(2,3,'2025-08-16'),
(3,4,'2026-08-17'),
(4,6,'2026-08-18'),
(5,1,'2026-09-19'),
(6,2,'2026-09-20'),
(6,5,'2026-09-21'),
(6,4,'2026-09-22');

SELECT CONCAT(P.NombrePasajero, ' ', P.ApellidoPasajero) AS Pasajero, P.NacionalidadPasajero,V.Origen,V.Destino,V.PrecioAsiento,R.FechaReserva
FROM Pasajero AS P INNER JOIN Reserva AS R ON R.IdPasajero = P.IdPasajero
INNER JOIN Vuelo AS V ON V.IdVuelo = R.IdVuelo

SELECT V.Destino,SUM(V.PrecioAsiento) AS Total_Dinero_Reservas
FROM Pasajero AS P INNER JOIN Reserva AS R ON R.IdPasajero = P.IdPasajero
INNER JOIN Vuelo AS V ON V.IdVuelo = R.IdVuelo
WHERE V.Destino = 'Madrid' OR V.Destino = 'París'
GROUP BY V.Destino
HAVING SUM(V.PrecioAsiento) > 400


SELECT V.IdVuelo,V.Origen,V.Destino,V.CapacidadMaxima,COUNT(R.IdReserva) AS Total_Reservas
FROM Pasajero AS P INNER JOIN Reserva AS R ON R.IdPasajero = P.IdPasajero
INNER JOIN Vuelo AS V ON V.IdVuelo = R.IdVuelo
GROUP BY V.IdVuelo,V.Origen,V.Destino,V.CapacidadMaxima
HAVING COUNT(R.IdReserva) > CapacidadMaxima;
