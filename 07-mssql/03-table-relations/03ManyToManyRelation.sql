create table Students(
	StudentID int primary key identity,
	Name nvarchar(100)
);
go

insert into Students
values
('Mila'),
('Toni'),
('Ron');
go
 
create table Exams(
	ExamID int primary key identity(101, 1),
	Name nvarchar(100)
);
go

insert into Exams
values
('SpringMVC'),
('Neo4j'),
('Oracle 11g');
go

create table StudentsExams(
	StudentID int,
	ExamID int,
    primary key (StudentID, ExamID),
	constraint FK_StudentsExams_Students foreign key (StudentID) references Students(StudentID),
	constraint FK_StudentsExams_Exams foreign key (ExamID) references Exams(ExamID)
);
go

insert into StudentsExams
values
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103);
go