create table Passports(
	PassportID int primary key identity(101, 1),
	PassportNumber nvarchar(8) not null
);
go

insert into Passports
values
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2');
go

create table People(
	PersonID int primary key identity,
	FirstName nvarchar(50) not null,
	Salary decimal(7, 2) not null,
	PassportID int references Passports(PassportID) not null
);
go

insert into People
values
('Roberto', 43300, 101),
('Tom', 56100, 102),
('Yana', 60200, 103);
go