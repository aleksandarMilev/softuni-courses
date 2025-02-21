create table Cities(
	CityID int primary key identity,
	Name nvarchar(50) not null
);
go

create table Customers(
	CustomerID int primary key identity,
	Name nvarchar(50) not null,
	Birthday date not null,
	CityID int references Cities(CityID)
);
go

create table Orders(
	OrderID int primary key identity,
	CustomerID int references Customers(CustomerID)
);
go

create table ItemTypes(
	ItemTypeID int primary key identity,
	Name nvarchar(50) not null
);
go

create table Items(
	ItemID int primary key identity,
	Name nvarchar(50) not null,
	ItemTypeID int references ItemTypes(ItemTypeID)
);
go

create table OrderItems(
	OrderID int,
	ItemID int,
	primary key (OrderID, ItemID),
	constraint FK_OrderItems_Orders foreign key (OrderID) references Orders(OrderID),
	constraint FK_OrderItems_Items foreign key (ItemID) references Items(ItemID)
);
go