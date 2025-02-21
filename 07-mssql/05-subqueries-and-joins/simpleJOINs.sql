--1
select top(5)
    EmployeeID
    ,JobTitle 
    ,a.AddressID 
    ,AddressText 
from Employees e 
join Addresses a on e.AddressID = a.AddressID 
order by a.AddressID;

--2
select top(50) 
    FirstName
    ,LastName
    ,t.Name as Town
    ,AddressText 
from Employees e 
join Addresses a on e.AddressID = a.AddressID 
join Towns t on a.TownID = t.TownID 
order by FirstName, LastName;

--3
select 
    EmployeeID
    ,FirstName
    ,LastName
    ,d.Name as DepartmentName 
from Employees e 
join Departments d on d.DepartmentID = e.DepartmentID 
where d.Name = 'Sales' 
order by EmployeeID;

--4
select top(5)
	EmployeeID
	,FirstName
	,Salary
	,d.Name as DepartmentName
from Employees e
join Departments d on e.DepartmentID = d.DepartmentID
where Salary > 15000
order by d.DepartmentID;

--5
select top(3)
	e.EmployeeID
    ,e.FirstName 
from Employees e 
left join EmployeesProjects ep on e.EmployeeID = ep.EmployeeID
where ep.EmployeeID is null
order by ep.EmployeeID

--6
select 
	FirstName
	,LastName
	,HireDate
	,d.Name as DeptName
from Employees e
join Departments d on e.DepartmentID = d.DepartmentID
where HireDate > '1999-01-01' and d.Name in ('Sales', 'Finance')
order by HireDate;

--7
select top(5)
	e.EmployeeID
	,e.FirstName
	,p.Name as ProjectName
from Employees e
join EmployeesProjects ep on e.EmployeeID = ep.EmployeeID
join Projects p on ep.ProjectID = p.ProjectID
where p.StartDate > '2002-08-13' and p.EndDate is null
order by e.EmployeeID;

--8
select 
	e.EmployeeID
	,e.FirstName
	,case 
        when year(p.StartDate) >= 2005 then null
        else p.name
    end as ProjectName
from Employees e
join EmployeesProjects ep on e.EmployeeID = ep.EmployeeID
join Projects p on ep.ProjectID = p.ProjectID
where e.EmployeeID = 24;

--9
select 
	e.EmployeeID
	,e.FirstName
	,m.EmployeeID
	,m.FirstName as ManagerName
from Employees e
join Employees m on e.ManagerID = m.EmployeeID
where m.EmployeeID in (3, 7)
order by e.EmployeeID;

--10
select top(50)
	e.EmployeeID
	,CONCAT_WS(' ', e.FirstName, e.LastName) as EmployeeName
	,CONCAT_WS(' ', m.FirstName, m.LastName) as ManagerName
	,d.Name as DepartmentName
from Employees e
join Employees m on e.ManagerID = m.EmployeeID
join Departments d on e.DepartmentID = d.DepartmentID
order by e.EmployeeID;

--11
SELECT top (1) 
	AVG(Salary) as AvgSalary
FROM Employees
GROUP BY DepartmentID 
order by AvgSalary asc

--12
select
	c.CountryCode
	,m.MountainRange
	,p.PeakName
	,p.Elevation
from Countries c
join MountainsCountries mc on mc.CountryCode = c.CountryCode
join Mountains m on m.Id = mc.MountainId
join Peaks p on p.MountainId = m.id
where c.CountryName = 'Bulgaria'
and p.Elevation > 2835
order by p.Elevation desc

--13
select 
	c.CountryCode
	,count(m.id) as MountainRanges
from Countries c
join MountainsCountries mc on mc.CountryCode = c.CountryCode
join Mountains m on m.Id = mc.MountainId
where c.CountryCode in ('US', 'BG', 'RU')
group by c.CountryCode

--14
select top(5)
	CountryName
	,r.RiverName
from Countries c
full join CountriesRivers cr on cr.CountryCode = c.CountryCode
full join Rivers r on r.Id = cr.RiverId
where c.ContinentCode = 'AF'
order by c.CountryName;

--15
WITH CurrencyUsage AS (
    SELECT 
        c.ContinentCode,
        cu.CurrencyCode,
        COUNT(*) AS CurrencyUsage,
        DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(*) DESC) AS Rank
    FROM Countries c
    JOIN Currencies cu ON c.CurrencyCode = cu.CurrencyCode
    GROUP BY c.ContinentCode, cu.CurrencyCode
    HAVING COUNT(*) > 1
)
SELECT 
    ContinentCode,
    CurrencyCode,
    CurrencyUsage
FROM CurrencyUsage
WHERE Rank = 1
ORDER BY ContinentCode;