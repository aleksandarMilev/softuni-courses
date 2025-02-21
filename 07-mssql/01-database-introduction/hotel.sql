CREATE TABLE [Hotel];
GO

USE [Hotel];
GO

CREATE TABLE [Employees](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Title] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX)
);
GO

INSERT INTO [Employees]([Id], [FirstName], [LastName], [Title], [Notes])
VALUES
    ('Pesho', 'Peshov', 'Manager', NULL),
    ('Gosho', 'Goshov', 'Assistant', 'SomeNotes'),
    ('Ivan', 'Ivanov', 'CEO', NULL);
GO

CREATE TABLE [Customers](
    [AccountNumber] INT PRIMARY KEY IDENTITY(1, 1),
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [PhoneNumber] CHAR(10) NOT NULL UNIQUE, 
    [EmergencyName] NVARCHAR(50) NOT NULL, 
    [EmergencyPhone] CHAR(10) NOT NULL UNIQUE, 
    [Notes] NVARCHAR(MAX)
);
GO

INSERT INTO [Customers]([FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyPhone], [Notes])
VALUES
    ('Pesho', 'Peshov', '1111111111', 'Ivan Ivanov', '0111111111', NULL),
    ('Gosho', 'Goshov', '2222222222', 'Dragan D', '0222222222', NULL),
    ('Dragan', 'Draganov', '3333333333', 'Pesho Peshov', '0333333333', NULL);
GO

