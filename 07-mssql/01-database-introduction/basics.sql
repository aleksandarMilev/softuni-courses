--1
CREATE DATABASE [Minions]
GO

USE [Minions]
GO

--2
CREATE TABLE [Minions](
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT,
)
GO

CREATE TABLE [Towns](
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
)
GO

--3
ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
GO

--4
INSERT INTO [Towns]([Id], [Name])
	VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')
GO

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
	VALUES 
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)
GO

--5
TRUNCATE TABLE [Minions]
GO

--6
DROP TABLE [Minions]
DROP TABLE [Towns]
GO

USE [Minions]
--7
CREATE TABLE [People](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX) CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) CHECK ([Gender] = 'f' OR [Gender] = 'm') NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX), 
)
GO

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate])
	VALUES
('Pesho', 1.88, 80.6, 'm', '2024-04-04'),
('Gosho', 1.90, 73.7, 'm', '2024-03-04'),
('Penka', 1.65, 55.5, 'f', '2024-02-04'),
('Strahilka', 1.70, 58.7, 'f', '2024-01-04'),
('Dimitrichko', 1.88, 80.6, 'm', '2024-01-05')
GO

--8
CREATE TABLE [Users](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[Username] VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(26) NOT NULL,
	[Picture] VARBINARY(MAX),
	[LastLoginTime] DATE,
	[IsDeleted] BIT NOT NULL, 
)
GO

INSERT INTO [Users]([Username], [Password], [IsDeleted])
	VALUES
('turbomaroder', '123456', 0),
('csmaster', '123456', 1),
('thebest', '123456', 0),
('freeshoot', '123456', 1),
('aka47', '123456', 0)
GO

--9
--Change the primary key???

--10
ALTER TABLE [Users]
ADD CONSTRAINT CHK_Password_Length CHECK (LEN([Password]) >= 5)
GO

--11
ALTER TABLE [Users]
ADD CONSTRAINT DF_Users_LastLoginTime DEFAULT (CAST(GETDATE() AS DATE)) FOR [LastLoginTime]
GO