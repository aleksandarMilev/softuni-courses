CREATE DATABASE [Softuni];
GO

USE [Softuni];
GO

CREATE TABLE [Towns](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL
);
GO

INSERT INTO [Towns]([Name])
VALUES
    ('Pernik'),
    ('Sofia'),
    ('Varna'),
    ('Burgas'),
    ('Pleven');
GO

CREATE TABLE [Addresses](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [AddressText] NVARCHAR(200) NOT NULL,
    [TownId] INT NOT NULL,
    CONSTRAINT FK_Addresses_Towns FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id])
);
GO

INSERT INTO [Addresses]([AddressText], [TownId])
VALUES
    ('sometext1', 1),
    ('sometext2', 2),
    ('sometext3', 3),
    ('sometext4', 4),
    ('sometext5', 5);
GO

CREATE TABLE [Departments](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL
);
GO

INSERT INTO [Departments]([Name])
VALUES
    ('Marketing'),
    ('Programming'),
    ('Sales'),
    ('CEO'),
    ('Research');
GO

CREATE TABLE [Employees](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [FirstName] NVARCHAR(50) NOT NULL,
    [MiddleName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [JobTitle] NVARCHAR(50) NOT NULL,
    [DepartmentId] INT NOT NULL,
    [HireDate] DATE NOT NULL,
    [Salary] DECIMAL(10, 2) NOT NULL,
    [AddressId] INT NOT NULL,
    CONSTRAINT FK_Employees_Address FOREIGN KEY ([AddressId]) REFERENCES [Addresses]([Id]),
    CONSTRAINT FK_Employees_Departments FOREIGN KEY ([DepartmentId]) REFERENCES [Departments]([Id])
);
GO

INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary], [AddressId])
VALUES
    ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 1, '01/02/2013', 3500.00, 1),
    ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 2, '02/03/2004', 4000.00, 2),
    ('Ivan', 'Ivanov', 'Ivanov', 'Intern', 3, '28/08/2016', 525.25, 3),
    ('Ivan', 'Ivanov', 'Ivanov', 'CEO', 4, '09/12/2007', 3000.00, 4),
    ('Ivan', 'Ivanov', 'Ivanov', 'Marketing', 5, '28/08/2016', 599.88, 5);
GO