using System;
using System.Collections.Generic;
namespace _04Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split();

                Student student = new Student(arguments[0],
                    arguments[1],
                    double.Parse(arguments[2]));

                students.Add(student);
            }

            var orderedList = students.OrderByDescending(x => x.Grade)
                .ToList();

            Console.WriteLine(string.Join("\n", orderedList));
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
}