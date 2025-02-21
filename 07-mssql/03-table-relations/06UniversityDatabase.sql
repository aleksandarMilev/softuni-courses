create database test2
go

use test2
go

create table Majors(
	MajorID int primary key identity,
	Name nvarchar(100)
);
go

create table Students(
	StudentID int primary key identity,
	StudentNumber int not null,
	StudentName nvarchar(100) not null,
	MajorID int references Majors(MajorID) not null
);
go

create table Payments(
	PaymentID int primary key identity,
	PaymentDate date not null,
	PaymentAmount decimal(5, 2) not null,
	StudentID int references Students(StudentID) not null
);
go

create table Subjects(
	SubjectID int primary key identity,
	SubjectName nvarchar(100)
);
go

create table Agenda(
	StudentID int, 
	SubjectID int,
	primary key(StudentID, SubjectID),
	constraint FK_Agenda_Students foreign key (StudentID) references Students(StudentID),
	constraint FK_Agenda_Subjects foreign key (SubjectID) references Subjects(SubjectID)
);
go
