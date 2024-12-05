CREATE DATABASE AutoFlexRental;
GO

USE AutoFlexRental;
GO

-- Tabla de Usuarios
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(15),
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) DEFAULT 'Customer', -- Puede ser 'Customer' o 'Admin'
    CreatedAt DATETIME DEFAULT GETDATE()
);
select * from users
GO

-- Tabla de Veh�culos
CREATE TABLE Vehicles (
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    Brand NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    DailyPrice DECIMAL(10, 2) NOT NULL,
    Availability BIT DEFAULT 1, -- 1: Disponible, 0: No disponible
    ImageUrl NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE()
);
select * from Vehicles
GO

-- Tabla de Reservas
CREATE TABLE Reservations (
    ReservationID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
    VehicleID INT NOT NULL FOREIGN KEY REFERENCES Vehicles(VehicleID),
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    Status NVARCHAR(50) DEFAULT 'Pending', -- 'Pending', 'Confirmed', 'Cancelled'
    CreatedAt DATETIME DEFAULT GETDATE()
);
select * from Reservations

GO

-- Tabla de Mensajes de Contacto
CREATE TABLE ContactMessages (
    MessageID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(15),
    Message NVARCHAR(MAX) NOT NULL,
    Status NVARCHAR(50) DEFAULT 'Unread', -- 'Unread', 'Read'
    CreatedAt DATETIME DEFAULT GETDATE()
);
select * from ContactMessages
GO
--Los que dicen requisitos extras no se han desarrollado.

-- Tabla de Notificaciones (Requisito Extra)
CREATE TABLE Notifications (
    NotificationID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
    Content NVARCHAR(255) NOT NULL,
    IsRead BIT DEFAULT 0, -- 0: No le�do, 1: Le�do
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de Logs de Actividad (Requisito Extra)
CREATE TABLE ActivityLogs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Action NVARCHAR(255) NOT NULL,
    Timestamp DATETIME DEFAULT GETDATE()
);
GO

-- Indices para optimizaci�n
CREATE INDEX IDX_Vehicles_Availability ON Vehicles(Availability);
CREATE INDEX IDX_Reservations_Status ON Reservations(Status);
CREATE INDEX IDX_ContactMessages_Status ON ContactMessages(Status);
GO



ALTER TABLE Reservations 
ALTER COLUMN StartDate DATETIME NOT NULL;

ALTER TABLE Reservations 
ALTER COLUMN EndDate DATETIME NOT NULL;

ALTER TABLE Reservations 
ADD Extras NVARCHAR(255) NULL; -- Ajusta la longitud según sea necesario



ALTER TABLE Notifications 
ADD Type NVARCHAR(50) NOT NULL DEFAULT 'General';


ALTER TABLE Reservations 
ADD CONSTRAINT CHK_Reservations_ValidDates 
CHECK (StartDate <= EndDate);

ALTER TABLE Vehicles ADD Category NVARCHAR(50);


