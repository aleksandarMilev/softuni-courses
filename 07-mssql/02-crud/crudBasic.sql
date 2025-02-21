--1
SELECT * 
  FROM Departments;

--2
SELECT [Name]
  FROM Departments

--3
SELECT FirstName
	    ,LastName
	    ,Salary
  FROM Employees;

--4
SELECT FirstName
	    ,MiddleName
	    ,LastName
  FROM Employees;

--5
SELECT 
CONCAT(FirstName, '.', LastName, '@softuni.bg')
    AS [Full Email Address]
  FROM Employees;

--6
  SELECT 
DISTINCT Salary
    FROM Employees

--7
SELECT * 
  FROM Employees
 WHERE JobTitle = 'Sales Representative';

--8
SELECT FirstName
	    ,LastName
	    ,JobTitle
  FROM Employees
 WHERE Salary >= 20000 
   AND Salary <= 30000;
--WHERE SALARY BETWEEN 20000 AND 30000

--9
SELECT
CONCAT_WS(' ', FirstName, MiddleName, LastName)
	  AS [Full Name]
  FROM Employees
 WHERE Salary IN (25000, 14000, 12500, 23600);

--10
SELECT FirstName
	    ,LastName
	FROM Employees
 WHERE ManagerID IS NULL;

--11
  SELECT FirstName	
		    ,LastName
		    ,Salary
    FROM Employees
   WHERE Salary > 50000
ORDER BY Salary DESC;

--12
  SELECT 
  TOP(5) 
  FirstName
 ,LastName
    FROM Employees
ORDER BY Salary DESC

--13
SELECT 
  FirstName
  ,LastName
  FROM Employees
 WHERE DepartmentID <> 4;

 --14
  SELECT * 
    FROM Employees
ORDER BY Salary DESC,
         FirstName ASC,
         LastName DESC,
         MiddleName ASC;

--15
CREATE VIEW V_EmployeesSalaries AS 
SELECT FirstName, LastName, Salary
FROM Employees;

--16????
CREATE VIEW V_EmployeeNameJobTitle AS 
SELECT 
  FirstName +  ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name]  
  ,JobTitle AS [Job Title]
  FROM Employees;

--18
  SELECT
DISTINCT JobTitle
    FROM Employees;

--19
SELECT TOP(10) * 
      FROM Projects
  ORDER BY StartDate, [Name];

--20
SELECT TOP(7) FirstName, LastName, HireDate
      FROM Employees
  ORDER BY HireDate DESC;

--21
UPDATE Employees
   SET Salary = Salary * 1.12
 WHERE DepartmentID IN (
	    SELECT DepartmentID FROM Departments
	     WHERE [NAME] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
 );

SELECT Salary
  FROM Employees;

--22
  SELECT PeakName
    FROM Peaks
ORDER BY PeakName ASC;

--23
SELECT TOP(30) CountryName, [Population]
      FROM Countries
     WHERE ContinentCode = 'EU'
  ORDER BY [Population] DESC, CountryName ASC;

--24
SELECT
  CountryName,
  CountryCode,
  CASE
    WHEN CurrencyCode = 'EUR' THEN 'Euro'
    ELSE 'Not Euro'
  END AS Currency
FROM Countries
ORDER BY CountryName ASC;


--25
  SELECT [Name] 
    FROM Characters
ORDER BY [Name] ASC;