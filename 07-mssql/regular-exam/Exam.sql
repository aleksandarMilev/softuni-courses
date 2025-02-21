--1
create database LibraryDb 
go

use LibraryDb 
go

create table Genres(
	Id int primary key identity,
	Name nvarchar(30) not null
)
go

create table Contacts(
	Id int primary key identity,
	Email nvarchar(100),
	PhoneNumber nvarchar(20),
	PostAddress nvarchar(200),
	Website nvarchar(50)
)
go

create table Libraries(
	Id int primary key identity,
	Name nvarchar(50) not null,
	ContactId int not null,
	foreign key (ContactId) references Contacts(Id)
)
go

create table Authors(
	Id int primary key identity,
	Name nvarchar(100) not null,
	ContactId int not null,
	foreign key (ContactId) references Contacts(Id)
)
go

create table Books(
	Id int primary key identity,
	Title nvarchar(100) not null,
	YearPublished int not null,
	ISBN nvarchar(13) not null unique,
	AuthorId int not null,
	GenreId int not null,
	foreign key (AuthorId) references Authors(Id),
	foreign key (GenreId) references Genres(Id)
)
go

create table LibrariesBooks(
	LibraryId int not null,
	BookId int not null,
	foreign key (LibraryId) references Libraries(Id),
	foreign key (BookId) references Books(Id),
	primary key (BookId, LibraryId)
)
go

--2
set identity_insert Contacts on
insert into Contacts (Id, Email, PhoneNumber, PostAddress, Website)
values
(21, null, null, null, null),
(22, null, null, null, null),
(23, 'stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
(24, 'suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com')
set identity_insert Contacts off
go

set identity_insert Authors on
insert into Authors (Id, Name, ContactId)
values
(16, 'George Orwell', 21),
(17, 'Aldous Huxley', 22),
(18, 'Stephen King', 23),
(19, 'Suzanne Collins', 24)
set identity_insert Authors off
go

set identity_insert Books on
insert into Books (Id, Title, YearPublished, ISBN, AuthorId, GenreId)
values
(36, '1984', 1949, '9780451524935', 16, 2),
(37, 'Animal Farm', 1945, '9780451526342', 16, 2),
(38, 'Brave New World', 1932, '9780060850524', 17, 2),
(39, 'The Doors of Perception', 1954, '9780060850531', 17, 2),
(40, 'The Shining', 1977, '9780307743657', 18, 9),
(41, 'It', 1986, '9781501142970', 18, 9),
(42, 'The Hunger Games', 2008, '9780439023481', 19, 7),
(43, 'Catching Fire', 2009, '9780439023498', 19, 7),
(44, 'Mockingjay', 2010, '9780439023511', 19, 7)
set identity_insert Books off
go

insert into LibrariesBooks
values
(1, 36),
(1, 37),
(2, 38),
(2, 39),
(3, 40),
(3, 41),
(4, 42),
(4, 43),
(5, 44)
go

--3
update c 
set c.Website = 'www.' +  replace(lower(a.Name), ' ', '')  + '.com'
from Contacts c
join Authors a on a.ContactId = c.Id
where c.Website is null

--4
delete from LibrariesBooks
where BookId = 1;

delete from Books
where AuthorId = 1;

delete from Authors
where Name = 'Alex Michaelides';

--5
select 
	Title as [Book Title],
	ISBN,
	YearPublished as YearReleased
from Books
order by 
	YearPublished desc,
	Title;

--6
select 
	b.Id,
	b.Title,
	b.ISBN,
	g.Name as Genre
from Books b
join Genres g on g.Id = b.GenreId
where g.Name in ( 'Biography', 'Historical Fiction' )
order by 
	g.Name,
	b.Title;

--7
select distinct
	l.Name as Library
	,c.Email
from Libraries l
join Contacts c on c.Id = l.ContactId
join LibrariesBooks lb on lb.LibraryId = l.Id
join Books b on b.Id = lb.BookId
join Genres g on g.Id = b.GenreId
where g.Name != 'Mystery' and l.Name != 'City Lights'
order by l.Name;

--8
select top(3)
	b.Title,
	b.YearPublished as Year,
	g.Name as Name
from Books b
join Genres g on g.Id = b.GenreId
where 
	(b.YearPublished > 2000 and b.Title like '%a%') or
	(b.YearPublished < 1950 and g.Name like '%Fantasy%')
order by 
	b.Title,
	b.YearPublished desc;

--9
select 
	a.Name as Author
	,c.Email
	,c.PostAddress as Address
from Authors a
join Contacts c on c.Id = a.ContactId
where c.PostAddress like '%UK%'
order by a.Name 

--10
select 
	a.Name as Author
	,b.Title
	,l.Name as Library
	,c.PostAddress as [Library Address]
from Books b
join LibrariesBooks lb on lb.BookId = b.Id
join Libraries l on l.Id = lb.LibraryId
join Contacts c on c.Id = l.ContactId
join Authors a on a.Id = b.AuthorId
join Genres g on g.Id = b.GenreId
where g.Name = 'Fiction' and c.PostAddress like '%Denver%'
order by b.Title

--11
create function udf_AuthorsWithBooks(@name nvarchar(100))
returns int
as
begin
	declare @result int;
	select @result = count(*)
				from Books b 
				join Authors a on a.Id = b.AuthorId 
				where a.Name = @name;
	return @result;
end

--12
create procedure usp_SearchByGenre
	@genreName nvarchar(30)
as
begin
	select 
		b.Title,
		b.YearPublished as Year,
		b.ISBN,
		a.Name as Author,
		g.Name as Genre
	from Books b 
	join Genres g on b.GenreId = g.Id
	join Authors a on b.AuthorId = a.Id
	where g.Name = @genreName
	order by b.Title;
end
