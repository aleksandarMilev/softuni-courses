create table Teachers(
	TeacherID int primary key identity(101, 1),
	Name nvarchar(100) not null,
	ManagerID int references Teachers(TeacherID)
);
go

insert into Teachers
values
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101);
go
