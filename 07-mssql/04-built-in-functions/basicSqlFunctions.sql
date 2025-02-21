--1
select FirstName, LastName
  from Employees
 where substring(FirstName, 1, 2) = 'Sa';

 --2
select FirstName, LastName 
  from Employees
 where LastName like '%ei%';

--3
select FirstName 
  from Employees
 where DepartmentID in (3, 10) and year(HireDate) between 1995 and 2005

--4
select FirstName, LastName 
  from Employees 
 where JobTitle not like '%engineer%';

--5
  select Name
    from Towns 
   where len(Name) in (5, 6)
order by Name asc

--6
   select TownID, Name
     from Towns 
    where Name like 'M%' 
       or Name like 'K%' 
       or Name like 'B%' 
       or Name like 'E%' 
 order by Name asc

--7
   select TownID, Name
     from Towns 
    where Name not like 'R%' 
      and Name not like 'B%' 
      and Name not like 'D%' 
 order by Name asc

--8
create view V_EmployeesHiredAfter2000  as
select FirstName, LastName
  from Employees
 where year(HireDate) > 2000;

 --9
 select FirstName, LastName
  from Employees
 where len(LastName) = 5;

--10
   select EmployeeID, FirstName, LastName, Salary,
        dense_rank() over (partition by Salary order by EmployeeID) as Rank
    from Employees
   where Salary between 10000 and 50000 
order by Salary desc

--11
;WITH RankedEmployees AS (
  SELECT 
    EmployeeID,
    FirstName,
    LastName,
    Salary,
    DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) as Rank
  FROM Employees
  WHERE Salary BETWEEN 10000 AND 50000
)
SELECT 
  EmployeeID,
  FirstName,
  LastName,
  Salary,
  Rank
FROM RankedEmployees
WHERE Rank = 2
ORDER BY Salary DESC;

--12
  select 
    CountryName, 
    IsoCode 
    from Countries 
   where (len(CountryName) - len(REPLACE(CountryName, 'a', '')) >= 3) 
order by IsoCode;

--13
  select 
    PeakName,
    RiverName,
    (lower(concat(replace(PeakName, ' ', ''), substring(replace(RiverName, ' ', ''), 2, len(RiverName) - 1)))) as Mix 
    from Peaks
    join Rivers on SUBSTRING(PeakName, (len(PeakName)), 1) = SUBSTRING(RiverName, 1, 1)
order by Mix;

--14
  select top(50) 
    Name
    ,cast(Start as date) as Start
    from Games 
   where year(Start) between 2011 and 2012 
order by Start, Name;

--15
  select Username
	      ,SUBSTRING(Email, CHARINDEX('@', Email) + 1, len(email) - CHARINDEX('@', Email) + 1) as [Email Provider] 
    from users 
   where Email like '%@%' 
order by [Email Provider], Username;

--16
  select Username
         ,IpAddress
    from users 
   where IpAddress like '___.1%.%.___' 
order by Username;

--17
  select Name
        ,case 
          when DATEPART(hour, Start) BETWEEN 0 AND 11 then 'Morning'
          when DATEPART(hour, Start) BETWEEN 12 AND 17 then 'Afternoon'
          when DATEPART(hour, Start) BETWEEN 18 AND 23 then 'Evening'
        end as [Part of the day]
        ,case 
          when Duration between 0 and 3 then 'Extra Short'
          when Duration between 4 and 6 then 'Short'
          when Duration > 6 then 'Long'
          when Duration is null then 'Extra Long'
		    end as Duration
    from Games
order by Name, Duration, [Part of the day]; 

--18
select ProductName
      ,OrderDate
      ,dateadd(day, 3, OrderDate) as [Pay Due]
      ,dateadd(month, 1, OrderDate) as [Deliver Due]
  from Orders;

--19
select Name 
		,datediff(year, Birthdate, getdate()) as [Age in Years] 
		,datediff(month, Birthdate, getdate()) as [Age in Months] 
		,datediff(day, Birthdate, getdate()) as [Age in Days]
		,datediff(minute, Birthdate, getdate()) as [Age in Minutes] 
  from People;
