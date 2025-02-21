using System;
using System.Collections.Generic;
using System.Linq;
namespace _05CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Continent> continents = new();
            int inputsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsCount; i++)
            {
                string[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = arguments[0];
                string country = arguments[1];
                string city = arguments[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Continent(continent));
                }

                if (!continents[continent].Map2.ContainsKey(country))
                {
                    continents[continent].Map2.Add(country, new List<string>());
                }

                continents[continent].Map2[country].Add(city);
            }

            foreach (KeyValuePair<string, Continent> kvp in continents)
            {
                Console.WriteLine($"{kvp.Key}:");
                foreach (KeyValuePair<string, List<string>> kvp2 in kvp.Value.Map2)
                {
                    Console.WriteLine($"{kvp2.Key} -> {string.Join(", ", kvp2.Value)}");

                }
            }
        }
    }

    class Continent
    {
        public Continent(string name)
        {
            Name = name;
            Map2 = new();
        }
        public string Name { get; set; }
        public Dictionary<string, List<string>> Map2 { get; set; }
    }
}