--1
create database RailwaysDb 
go

use RailwaysDb
go

create table Passengers(
	Id int primary key identity,
	Name nvarchar(80) not null,
)
go

create table Towns(
	Id int primary key identity,
	Name varchar(30) not null,
)
go

create table RailwayStations(
	Id int primary key identity,
	Name varchar(50) not null,
	TownId int not null,
	foreign key (TownId) references Towns(Id)
)
go

create table Trains(
	Id int primary key identity,
	HourOfDeparture varchar(5) not null,
	HourOfArrival varchar(5) not null,
	DepartureTownId int not null,
	ArrivalTownId int not null,
	foreign key (DepartureTownId) references Towns(Id),
	foreign key (ArrivalTownId) references Towns(Id)
)
go

create table TrainsRailwayStations(
	TrainId int not null,
	RailwayStationId int not null,
	foreign key (TrainId) references Trains(Id),
	foreign key (RailwayStationId) references RailwayStations(Id),
	primary key (TrainId, RailwayStationId)
)

create table MaintenanceRecords(
	Id int primary key identity,
	DateOfMaintenance Date not null,
	Details varchar(2000) not null,
	TrainId int not null,
	foreign key (TrainId) references Trains(Id)
)
go

create table Tickets(
	Id int primary key identity,
	Price decimal(18,2) not null,
	DateOfDeparture Date not null,
	DateOfArrival Date not null,
	TrainId int not null,
	PassengerId int not null,
	foreign key (TrainId) references Trains(Id),
	foreign key (PassengerId) references Passengers(Id)
)
go

--2
insert into Trains 
values 
('07:00', '19:00', 1, 3),
('08:30', '20:30', 5, 6),
('09:00', '21:00', 4, 8),
('06:45', '03:55', 27, 7),
('10:15', '12:15', 15, 5)

insert into TrainsRailwayStations 
values 
(36, 1),
(37, 60),
(39, 3),
(36, 4),
(37, 16),
(39, 31),
(36, 31),
(38, 10),
(39, 19),
(36, 57),
(38, 50),
(40, 41),
(36, 7),
(38, 52),
(40, 7),
(37, 13),
(38, 22),
(40, 52),
(37, 54),
(39, 68),
(40, 13)

insert into Tickets 
values 
(90.00, '2023-12-01', '2023-12-01', 36, 1),
(115.00, '2023-08-02', '2023-08-02', 37, 2),
(160.00, '2023-08-03', '2023-08-03', 38, 3),
(255.00, '2023-09-01', '2023-09-02', 39, 21),
(95.00, '2023-09-02', '2023-09-03', 40, 22)

--3
update Tickets 
set DateOfDeparture = dateadd(day, 7, DateOfDeparture),
DateOfArrival = dateadd(day, 7, DateOfArrival)
where month(DateOfDeparture) > 10 

--4
delete from TrainsRailwayStations
where TrainId = 7

delete from MaintenanceRecords
where TrainId = 7

delete from Tickets
where TrainId = 7

delete from Trains
where DepartureTownId in(
	select Id
	from Towns
	where Name = 'Berlin'
)

--5
select 
	DateOfDeparture, 
	Price 
from Tickets 
order by Price, 
DateOfDeparture desc

--6
select 
	p.Name as PassengerName,
	t.Price as TicketPrice,
	t.DateOfDeparture as DateOfDeparture,
	t.TrainId as TrainID
from Tickets t
join Passengers p on p.Id = t.PassengerId
order by 
	t.Price desc, 
	p.Name

--7
select 
    t.Name as Town, 
    rs.Name as RailwayStation
from RailwayStations rs
join Towns t on rs.TownId = t.Id
left join TrainsRailwayStations trs on rs.Id = trs.RailwayStationId
where trs.RailwayStationId is null
order by 
    t.Name asc, 
    rs.Name asc

--8
select top(3) 
	tr.Id as TrainId,
	tr.HourOfDeparture,
	tck.Price as TicketPrice,
	tw.Name as Destination
from Trains tr
join Tickets tck on tck.TrainId = tr.Id
join Towns tw on tw.id = tr.ArrivalTownId
where 
	substring(tr.HourOfDeparture, 1, 2) = '08' and
	Price > 50
order by TicketPrice

--9
select 
	t.Name as TownName,
	count(p.Id) as PassengersCount
from Passengers p
join Tickets ti on ti.PassengerId = p.Id
join Trains tr on ti.TrainId = tr.Id
join Towns t on t.Id = tr.ArrivalTownId
where ti.Price > 76.99
group by t.Name
order by t.Name

--10
select 
	tr.Id as TrainId,
	tw.Name as DepartureTown,
	mr.Details
from Trains tr
join Towns tw on  tw.Id = tr.DepartureTownId
join MaintenanceRecords mr on mr.TrainId = tr.Id
where mr.Details like '%inspection%'
order by tr.Id

--11
create function udf_TownsWithTrains(@name nvarchar(50))�
returns int 
as
begin
	declare @trains int;

	select @trains = count(*)
	from Trains tr
	join Towns twDeparture ON twDeparture.Id = tr.DepartureTownId
	join Towns twArrival ON twArrival.Id = tr.ArrivalTownId
	where twDeparture.Name = @name OR twArrival.Name = @name;
	return @trains;
end

--12
create procedure usp_SearchByTown(@townName varchar(30))
as
begin
	select 
	p.Name as PassengerName,
	ti.DateOfDeparture,
	tr.HourOfDeparture
from Passengers p
join Tickets ti on ti.PassengerId = p.Id
join Trains tr on tr.Id = ti.TrainId
join Towns t on t.Id = tr.ArrivalTownId
where t.Name = @townName
order by
	ti.DateOfDeparture desc,
	p.Name
end