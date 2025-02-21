create table Manufacturers(
	ManufacturerID int primary key identity,
	Name nvarchar(50) not null,
	EstablishedOn Date not null
);
go

insert into Manufacturers
values
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966');
go

create table Models(
	ModelID int primary key identity(101, 1),
	Name nvarchar(50) not null,
	ManufacturerID int references Manufacturers(ManufacturerID)
);
go

insert into Models
values
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3);
go
