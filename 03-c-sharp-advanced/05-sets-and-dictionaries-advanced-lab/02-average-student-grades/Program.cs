using System;
using System.Collections.Generic;
using System.Linq;
namespace _02AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> students = new();
            int studentsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!students.ContainsKey(name))
                {
                    students[name] = new Student(name);
                }

                students[name].Grades.Add(grade);
            }

            foreach (KeyValuePair<string, Student> kvp in students)
            {
                Console.Write($"{kvp.Key} -> ");
                foreach (decimal grade in kvp.Value.Grades)
                {
                    Console.Write($"{grade:f2}" + " ");
                }

                decimal avgGrade = kvp.Value.Grades.Average();
                Console.WriteLine($"(avg: {avgGrade:f2})");
            }
        }
    }

    class Student
    {
        public Student(string name)
        {
            Name = name;
            Grades = new();
        }
        public string Name { get; set; }
        public List<decimal> Grades { get; set; }
    }
}