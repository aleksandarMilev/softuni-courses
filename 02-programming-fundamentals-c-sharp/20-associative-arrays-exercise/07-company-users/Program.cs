using System;
using System.Collections.Generic;
using System.Linq;
namespace _07CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" -> ");
                string company = input[0];
                string id = input[1];

                if (!dictionary.ContainsKey(company))
                {
                    dictionary[company] = new List<string>();
                    dictionary[company].Add(id);
                }
                else
                {
                    if (!dictionary[company].Contains(id))
                    {
                        dictionary[company].Add(id);
                    }
                }
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var id in kvp.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}