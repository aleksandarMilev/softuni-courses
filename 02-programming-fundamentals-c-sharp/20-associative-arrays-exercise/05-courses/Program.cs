using System;
using System.Collections.Generic;
using System.Linq;
namespace _05Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
 
            string command;
            while ((command = Console.ReadLine()) != "end")
            
            {
                string[] input = command.Split(" : ");
                string courseName = input[0];
                string studentName = input[1];

                if (!dictionary.ContainsKey(courseName))
                {
                    dictionary[courseName] = new List<string>();
                    dictionary[courseName].Add(studentName);
                }
                else
                {
                    dictionary[courseName].Add(studentName);
                }
            }

            foreach (KeyValuePair<string, List<string>> kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach (var student in kvp.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}