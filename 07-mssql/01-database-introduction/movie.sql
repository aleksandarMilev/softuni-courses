--13
CREATE DATABASE [Movies];

USE [Movies];

CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[DirectorName] NVARCHAR(100) NOT NULL,
	[Notes] NVARCHAR(MAX)
);

INSERT INTO [Directors]([DirectorName], [Notes])
VALUES
	('Quentin Tarantino', NULL),
	('Steven Spielberg', 'SomeNotes'),
	('Stanley Kubrick', NULL),
	('Alferd Hitchcock', 'SomeNotes'),
	('SomeName', NULL);

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
);

INSERT INTO [Genres]([GenreName], [Notes])
VALUES
	('Horror', NULL),
	('Sci-fi', 'SomeNotes'),
	('Comedy', NULL),
	('Drama', 'SomeNotes'),
	('Fantasy', NULL);

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX);
)

INSERT INTO [Categories]([CategoryName], [Notes])
	VALUES
('Category1', NULL),
('Category2', 'SomeNotes'),
('Category3', NULL),
('Category4', 'SomeNotes'),
('Category5', NULL);

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Title] NVARCHAR(100) NOT NULL,
	[DirectorId] INT NOT NULL,
	[CopyrightYear] SMALLINT NOT NULL,
	[Length] SMALLINT NOT NULL,
	[GenreId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Rating] FLOAT NOT NULL,
	[Notes] NVARCHAR(MAX), 
	CONSTRAINT FK_Movies_Director FOREIGN KEY ([DirectorId]) REFERENCES [Directors]([Id]),
	CONSTRAINT FK_Movies_Genre FOREIGN KEY ([GenreId]) REFERENCES [Genres]([Id]),
	CONSTRAINT FK_Movies_Category FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id])
);

INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES
	('The Green Mile', 1, 1997, 180, 1, 1, 10, NULL),
	('The Lord Of The Rings', 2, 2000, 200, 2, 2, 10, 'SomeNotes'),
	('The Dark Knight', 3, 2007, 182, 3, 3, 10, NULL),
	('The Shining', 4, 1980, 176, 4, 4, 10, 'SomeNotes'),
	('The Exorcist', 5, 1973, 169, 5, 5, 10, NULL);