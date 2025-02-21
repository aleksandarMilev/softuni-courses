using System;
using System.Collections.Generic;
namespace _01CompanyRoster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();
                string name = arr[0];
                double salary = double.Parse(arr[1]);
                string department = arr[2];

                Employee employee = new Employee(name, salary, department);
                list.Add(employee);
            }

            var highestAvgSalDep = 
                list.GroupBy(e => e.Department)
                .Select(g => new { Department = g.Key, AvgSalary = g.Average(e => e.Salary) })
                .OrderByDescending(d => d.AvgSalary)
                .First()
                .Department;

            var employeesInHighestAvgSalDep = list.Where(e => e.Department == highestAvgSalDep)
                .OrderByDescending(e => e.Salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {highestAvgSalDep}");

            foreach (var employee in employeesInHighestAvgSalDep)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }

    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
}