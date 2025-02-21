CREATE DATABASE [CarRental];
GO

USE [CarRental];
GO

CREATE TABLE [Categories](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [CategoryName] NVARCHAR(50) NOT NULL,
    [DailyRate] SMALLINT NOT NULL,
    [WeeklyRate] SMALLINT NOT NULL,
    [MonthlyRate] SMALLINT NOT NULL,
    [WeekendRate] SMALLINT NOT NULL
);
GO

INSERT INTO [Categories]([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES
    ('CatName1', 1, 7, 30, 5),
    ('CatName2', 2, 14, 60, 10),
    ('CatName3', 3, 21, 90, 15);
GO

CREATE TABLE [Cars](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [PlateNumber] NVARCHAR(50) UNIQUE NOT NULL,
    [Manufacturer] NVARCHAR(50) NOT NULL,
    [Model] NVARCHAR(50) NOT NULL,
    [CarYear] SMALLINT NOT NULL,
    [CategoryId] INT NOT NULL,
    [Doors] SMALLINT NOT NULL,
    [Picture] VARBINARY(MAX) CHECK (DATALENGTH([Picture]) <= 2000000),
    [Condition] NVARCHAR(50) NOT NULL,
    [Available] BIT NOT NULL,
    CONSTRAINT FK_Car_Category FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id])
);
GO

INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Condition], [Available])
VALUES
    ('CA1111MT', 'BMW', 'E60', 2000, 1, 4, 'Good', 1),
    ('CA2222MT', 'Audi', 'A6', 2005, 2, 4, 'Good', 1),
    ('CA3333MT', 'Mercedes', 'CClass', 2006, 3, 4, 'Good', 1);
GO

CREATE TABLE [Employees](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Title] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX)
);
GO

INSERT INTO [Employees]([FirstName], [LastName], [Title])
VALUES
    ('Pesho', 'Peshov', 'Manager'),
    ('Gosho', 'Goshov', 'Assistant'),
    ('Ivan', 'Ivanov', 'CEO');
GO

CREATE TABLE [Customers](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [DriverLicenceNumber] CHAR(10) UNIQUE NOT NULL,
    [FullName] NVARCHAR(100) NOT NULL,
    [Address] NVARCHAR(100) NOT NULL,
    [City] NVARCHAR(50) NOT NULL,
    [ZipCode] CHAR(4) NOT NULL,
    [Notes] NVARCHAR(MAX)
);
GO

INSERT INTO [Customers]([DriverLicenceNumber], [FullName], [Address], [City], [ZipCode], [Notes])
VALUES
    ('1111111111', 'Ivan Ivanov', 'bul Slivnica 101', 'Sofia', '2300', NULL),
    ('2222222222', 'Ivan Ivanov1', 'bul Slivnica 102', 'Sofia', '2300', 'SomeNotes'),
    ('3333333333', 'Ivan Ivanov2', 'bul Slivnica 103', 'Sofia', '2300', NULL);
GO

CREATE TABLE [RentalOrders](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [EmployeeId] INT NOT NULL,
    [CustomerId] INT NOT NULL,
    [CarId] INT NOT NULL,
    [TankLevel] SMALLINT NOT NULL,
    [KilometrageStart] SMALLINT NOT NULL,
    [KilometrageEnd] SMALLINT NOT NULL,
    [TotalKilometrage] SMALLINT NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [TotalDays] SMALLINT NOT NULL,
    [RateApplied] SMALLINT NOT NULL,
    [TaxRate] SMALLINT NOT NULL,
    [OrderStatus] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX),
    CONSTRAINT FK_RentalOrders_Employee FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]),
    CONSTRAINT FK_RentalOrders_Customer FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id]),
    CONSTRAINT FK_RentalOrders_Car FOREIGN KEY ([CarId]) REFERENCES [Cars]([Id])
);
GO

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus], [Notes])
VALUES
    (1, 1, 1, 10, 0, 200, 200, '2000-01-01', '2001-01-01', 365, 10, 10, 'Ready', NULL),
    (2, 2, 2, 20, 10, 300, 290, '2001-01-01', '2002-01-01', 365, 20, 20, 'Broken', 'SomeNotes'),
    (3, 3, 3, 30, 20, 400, 380, '2002-01-01', '2003-01-01', 365, 30, 30, 'Taken', NULL);
GO