--1
create or alter proc usp_GetEmployeesSalaryAbove35000
as
begin
	select
		FirstName
		,LastName
	from Employees
	where Salary > 35000
end

--2
create or alter proc usp_GetEmployeesSalaryAboveNumber 
@salaryInput decimal(18,4) 
as
begin
	select
		FirstName
		,LastName
	from Employees
	where Salary >= @salaryInput
end

--3
create or alter proc usp_GetTownsStartingWith 
@startsWith varchar(255)
as
begin
	select Name
	from Towns
	where LOWER(Name) LIKE LOWER(@startsWith) + '%'
end

--4
create or alter proc usp_GetEmployeesFromTown 
@townName nvarchar(100)
as
begin
	select 
		FirstName [First Name]
		,LastName [Last Name]
		from Employees e
		join Addresses a on e.AddressID = a.AddressID
		join Towns t on a.TownID = t.TownID
		where t.Name = @townName;
end

--5
create or alter function ufn_GetSalaryLevel(@salaryInput decimal(18,4))
returns nvarchar(10)
as
begin
	declare @result nvarchar(10)
	 select @result = case
		when @salaryInput < 30000 then 'Low'
		when @salaryInput between 30000 and 50000 then 'Average'
		when @salaryInput > 50000 then 'High'
	 end
	return @result 
end

--6
create or alter proc usp_EmployeesBySalaryLevel
@salaryLevel nvarchar(10)
as
begin
	select 
		FirstName
		,LastName 
		from Employees 
		where dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel;
end

--7
create or alter function ufn_IsWordComprised(@setOfLetters nvarchar(100), @word nvarchar(100))
returns bit 
as
begin
	declare @i int = 1;
    declare @result bit = 1;

    while @i <= LEN(@word)
    begin
        if CHARINDEX(SUBSTRING(@word, @i, 1), @setOfLetters ) = 0
        begin
            set @result = 0;
            break;
        end
        set @i = @i + 1;
    end
    return @result;
end

--8
--???

--9
create or alter proc usp_GetHoldersFullName 
as
begin
	select concat_ws(' ', FirstName, LastName) [Full Name]
	from AccountHolders
end;

--10
create or alter proc usp_GetHoldersWithBalanceHigherThan
@balance decimal(10,2)
as
begin
	select 
		FirstName
		,LastName
	from AccountHolders ah
	join Accounts ac on ah.Id = ac.AccountHolderId
	group by AccountHolderId ,FirstName,LastName
	having sum(ac.Balance) > @balance
	order by FirstName, LastName
end

--11
create or alter function ufn_CalculateFutureValue(@sum decimal, @yearlyInterestRate float, @yearsCount int)
returns decimal (18, 4)
as
begin
	declare @futureValue decimal(18,4);
    set @futureValue = @sum * power((1 + @yearlyInterestRate), @yearsCount);
    return round(@futureValue, 4);
end

--12
create or alter proc usp_CalculateFutureValueForAccount
@accountId int,
@interestRate decimal(10, 2)
as
begin
	select top(1)
	ah.Id as [Account Id]
	,FirstName as [First Name]	
	,LastName as [Last Name]
	,a.[Balance] as [Current Balance]
	,dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) as [Balance in 5 years]
	from AccountHolders ah
	join Accounts a on a.AccountHolderId = ah.Id
	where ah.Id = @accountId
end

--13
--??
