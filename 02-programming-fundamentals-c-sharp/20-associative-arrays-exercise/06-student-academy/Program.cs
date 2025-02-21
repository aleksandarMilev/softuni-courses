using System;
using System.Collections.Generic;
using System.Linq;
namespace _06StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> dictionary = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(name))
                {
                    dictionary[name] = new List<double>();
                    dictionary[name].Add(grade);
                }
                else
                {
                    dictionary[name].Add(grade);
                }
            }

            foreach (var kvp in dictionary)
            {
                string name = kvp.Key;
                List<double> grades = kvp.Value;

                double avGrade = grades.Average();
                if (avGrade >= 4.5)
                {
                    Console.WriteLine($"{name} -> {avGrade:f2}");
                }
            }
        }
    }
}