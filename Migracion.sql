CREATE DATABASE Migracion


CREATE TABLE Viajeros (
    ViajeroId INT  IDENTITY(1,1),
    Nombre NVARCHAR(50)NOT NULL,
    Apellido NVARCHAR(50),
    FechaNacimiento DATE,
    Nacionalidad NVARCHAR(50)
	CONSTRAINT PK_ViajeroID Primary key (ViajeroID)
);


CREATE TABLE Pasaportes (
    PasaporteId INT  IDENTITY(1,1),
    NumeroPasaporte NVARCHAR(20) UNIQUE,
    FechaEmision DATE ,
    FechaExpiracion DATE,
    ViajeroId INT NOT NULL,
	CONSTRAINT PK_PasaporteId Primary key (PasaporteId),
	CONSTRAINT FK_ViajeroId FOREIGN KEY (ViajeroId) REFERENCES Viajeros(ViajeroId)
  
	
);


CREATE TABLE Entradas (
    EntradaId INT  IDENTITY (1,1) ,
    ViajeroId INT,
    FechaEntrada DATE,
    LugarEntrada NVARCHAR(100),
	CONSTRAINT PK_EntradaId Primary key (EntradaId),
	CONSTRAINT FK_ViajeroId2 FOREIGN KEY (ViajeroId) REFERENCES Viajeros(ViajeroId)
);


CREATE TABLE Salidas (
    SalidaId INT  IDENTITY(1,1),
    ViajeroId INT NOT NULL,
    FechaSalida DATE,
    LugarSalida NVARCHAR(100),
    CONSTRAINT PK_SalidaId Primary key (SalidaId),
	CONSTRAINT FK_ViajeroId3 FOREIGN KEY (ViajeroId) REFERENCES Viajeros(ViajeroId)
);


CREATE TABLE Usuarios (
    UsuarioId INT  IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE,
    PasswordHash NVARCHAR(255),
    Role NVARCHAR(50)
	CONSTRAINT PK_usuarios PRIMARY KEY (UsuarioId) /*Despues de crear los usuarios desde la pagina MVC, se puede crear sus roles desde este studio*/
);


drop table Entradas
drop table Pasaportes
drop table Salidas
drop table Usuarios
drop table Viajeros