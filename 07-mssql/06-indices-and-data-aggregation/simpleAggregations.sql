--1
select count(*) 
from WizzardDeposits;

--2
select max (MagicWandSize) LongestMagicWand
from WizzardDeposits;

--3
select 
	DepositGroup
	,max (MagicWandSize) LongestMagicWand
from WizzardDeposits
group by DepositGroup

--4
select top(2)
	avg(MagicWandSize) AverageWandSize
	,DepositGroup
from WizzardDeposits 
group by DepositGroup
order by AverageWandSize

--5
select 
	DepositGroup
	,sum(DepositAmount)
from WizzardDeposits
group by DepositGroup

--6
select 
	DepositGroup
	,sum(DepositAmount) [Total Sum]
from WizzardDeposits
group by DepositGroup, MagicWandCreator
having MagicWandCreator = 'Ollivander family';

--7
select 
	DepositGroup
	,sum(DepositAmount) TotalSum
from WizzardDeposits
where MagicWandCreator = 'Ollivander family' 
group by DepositGroup
having sum(DepositAmount) < 150000
order by TotalSum desc

--8
select
	DepositGroup 
	,MagicWandCreator
    ,min(DepositCharge) MinDepositCharge
from WizzardDeposits
group by DepositGroup, MagicWandCreator
order by MagicWandCreator, DepositGroup;

--9
select 
	case
		when Age between 0 and 10 then '[0-10]'
		when Age between 11 and 20 then '[11-20]'
		when Age between 21 and 30 then '[21-30]'
		when Age between 31 and 40 then '[31-40]'
		when Age between 41 and 50 then '[41-50]'
		when Age between 51 and 60 then '[51-59]'
		when Age > 60 then '[60+]'
	end as AgeGroup
	,count(*) WizardCount
from WizzardDeposits
group by
	case
		when Age between 0 and 10 then '[0-10]'
		when Age between 11 and 20 then '[11-20]'
		when Age between 21 and 30 then '[21-30]'
		when Age between 31 and 40 then '[31-40]'
		when Age between 41 and 50 then '[41-50]'
		when Age between 51 and 60 then '[51-59]'
		when Age > 60 then '[60+]'
	end
;

--10
select substring(FirstName, 1, 1) FirstLetter
from WizzardDeposits
where DepositGroup = 'Troll Chest'
group by substring(FirstName, 1, 1)
order by FirstLetter;

--11
select 
	DepositGroup
	,IsDepositExpired
	,avg(DepositInterest)
from WizzardDeposits
where DepositStartDate > '01/01/1985'
group by DepositGroup, IsDepositExpired
order by DepositGroup desc, IsDepositExpired

--12
select sum(dif) totaldifference
from (
    select depositamount - lead(depositamount) over (order by Id) dif
    from wizzarddeposits
) derivedtable
where dif is not null;

--13
select 
    DepartmentID
    ,sum(Salary)
from Employees
group by DepartmentID 
order by DepartmentID

--14
select 
    DepartmentID
    ,min(Salary) MinimumSalary 
from Employees 
where HireDate > '01/01/2000' 
group by DepartmentID 
having DepartmentID in (2, 5, 7);

--15
SELECT *
INTO NewEmployees
FROM Employees
WHERE Salary > 30000;
go

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (
	SELECT EmployeeID 
	FROM NewEmployees 
	WHERE ManagerID = 42
);
go

DELETE FROM NewEmployees
WHERE ManagerID = 42;
go

update NewEmployees
set Salary = Salary + 5000
where DepartmentID = 1;
go

select 
	DepartmentID
	,avg(Salary) 
from NewEmployees 
group by DepartmentID;
go

--16
select 
	DepartmentID
	,max(salary) MaxSalary 
from Employees 
group by DepartmentID 
having max(salary) not between 30000 and 70000

--17
select count(Salary) Count
from Employees
where ManagerID is null

--18
select distinct DepartmentID, Salary as ThirdHighestSalary
from (select 
        DepartmentID, 
        Salary,
        dense_rank() over (partition by DepartmentID order by Salary desc) as SalaryRank
       from Employees) RankedSalaries
where SalaryRank = 3;

--19
select top(10)
	FirstName
	,LastName
	,e.DepartmentID
from Employees e
join (
    select 
		DepartmentID
		,AVG(Salary) AverageSalary
    from Employees
    group by DepartmentID
) as DepartmentAverage on e.DepartmentID = DepartmentAverage.DepartmentID
where e.Salary > DepartmentAverage.AverageSalary
order by e.DepartmentID;
