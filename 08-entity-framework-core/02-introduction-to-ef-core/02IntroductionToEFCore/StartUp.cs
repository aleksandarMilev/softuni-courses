namespace _02IntroductionToEFCore
{
    using _02IntroductionToEFCore.Data.Models;
    using _02IntroductionToEFCore.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using SoftUniContext context = new();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new 
                {
                    e.FirstName,
                    e.MiddleName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary,
                })
                .ToList();

            StringBuilder builder = new();

            foreach (var e in employees)
            {
                builder.AppendLine($"{e.FirstName} {e.MiddleName} {e.LastName} {e.JobTitle} {e.Salary:f2}");
            }

            return builder.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context) 
        {
            var employees = context.Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50_000)
                .ToList();

            StringBuilder builder = new();

            employees.ForEach(e => builder.AppendLine($"{e.FirstName} - {e.Salary}"));

            return builder.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmenName = e.Department.Name,
                    e.Salary,
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder builder = new();

            foreach (var e in employees)
            {
                builder.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmenName} - ${e.Salary:f2}");
            }

            return builder.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new()
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            var employee = context.Employees.
                FirstOrDefault(e => e.LastName == "Nakov")
                ?? throw new NullReferenceException();

            employee.Address = address;
            context.SaveChanges();

            var addressTexts = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new string(e.Address!.AddressText))
                .Take(10);

            StringBuilder builder = new();

            foreach (var at in addressTexts)
            {
                builder.AppendLine(at);
            }

            return builder.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager!.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                            EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished"
                        })
                        .ToList()
                })
                .Take(10)
                .ToList();

            StringBuilder builder = new();

            foreach (var e in employees)
            {
                builder.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Projects)
                {
                    builder.AppendLine($"--<{p.Name}> - <{p.StartDate}> - <{p.EndDate}>");
                }
            }

            return builder.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town!.Name, 
                    EmployeesCount = a.Employees.Count,
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10);

            StringBuilder builder = new();

            foreach (var a in addresses)
            {
                builder.AppendLine($"{a.AddressText}, {a.TownName ?? throw new NullReferenceException()} - {a.EmployeesCount} employees");
            }

            return builder.ToString().Trim();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .OrderBy(ep => ep.Project.Name)
                        .Select(ep => ep.Project.Name)
                })
                .FirstOrDefault()
                ?? throw new NotImplementedException();

            StringBuilder builder = new();

            builder.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var p in employee.Projects)
            {
                builder.AppendLine(p);
            }

            return builder.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    d.Name,
                    EmployessCount = d.Employees.Count,
                    ManagerName = d.Manager.FirstName + ' ' + d.Manager.LastName,
                    Employees = d.Employees
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
                })
                .OrderBy(d => d.EmployessCount)
                .ThenBy(d => d.Name);

            StringBuilder builder = new();

            foreach (var d in departments)
            {
                builder.AppendLine($"{d.Name} {d.ManagerName}");

                foreach (var e in d.Employees)
                {
                    builder.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return builder.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
                });

            StringBuilder builder = new();

            foreach (var p in projects)
            {
                builder.AppendLine($"{p.Name}");
                builder.AppendLine($"{p.Description}");
                builder.AppendLine($"{p.StartDate}");
            }

            return builder.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            HashSet<string> departmentNames = ["Engineering", "Tool Design", "Marketing", "Information Services"];

            var employees = context.Employees
                .Where(e => departmentNames.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            StringBuilder builder = new();

            foreach (var e in employees)
            {
                e.Salary *= 1.12m;
                builder.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            context.SaveChanges();
            return builder.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => EF.Functions.Like(e.FirstName, "Sa%"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            StringBuilder builder = new();

            foreach (var e in employees)
            {
                builder.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - ${e.Salary:f2}");
            }

            return builder.ToString().Trim();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            Project project = context.Projects
                .Include(p => p.EmployeesProjects)  
                .FirstOrDefault(p => p.ProjectId == 2)
                ?? throw new NullReferenceException("Project with ID 2 not found.");

            foreach (var employeeProject in project.EmployeesProjects.ToList())
            {
                context.EmployeesProjects.Remove(employeeProject);
            }

            context.Projects.Remove(project);
            context.SaveChanges();  

            StringBuilder builder = new();

            var projectNames = context.Projects
                .OrderBy(p => p.ProjectId)
                .Take(10)
                .Select(p => p.Name);

            foreach (string name in projectNames)
            {
                builder.AppendLine(name);
            }

            return builder.ToString().Trim();
        }

        public static string DeleteTown(SoftUniContext context)
        {
            Town town = context.Towns
                .FirstOrDefault(t => t.Name == "Seattle")
                ?? throw new NullReferenceException("0 addresses in Seattle were deleted");

            List<Address> addresses = context.Addresses
                .Where(a => a.TownId == town.TownId)
                .ToList();

            int count = addresses.Count;

            var employees = context.Employees
                .Where(e => addresses
                    .Select(a => a.AddressId)
                    .Contains(e.AddressId!.Value)
                );

            foreach (var e in employees)
            {
                e.AddressId = null;  
            }

            context.SaveChanges();  

            context.Addresses.RemoveRange(addresses);
            context.SaveChanges(); 

            context.Towns.Remove(town);
            context.SaveChanges();  

            return $"{count} addresses in Seattle were deleted";
        }
    }
}
