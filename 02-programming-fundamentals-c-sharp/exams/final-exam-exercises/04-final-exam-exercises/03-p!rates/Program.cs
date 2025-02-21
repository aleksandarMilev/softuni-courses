using System;
using System.Collections.Generic;
namespace _03P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> map = new Dictionary<string, City>();

            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] arguments = input.Split("||");
                string name = arguments[0];
                int popualtion = int.Parse(arguments[1]);
                int gold = int.Parse(arguments[2]);

                if (!map.ContainsKey(name))
                {
                    map.Add(name, new City(name, popualtion, gold));
                }
                else
                {
                    map[name].Population += popualtion;
                    map[name].Gold += gold;
                }
            }

            string events;
            while ((events = Console.ReadLine()) != "End")
            {
                string[] arguments = events.Split("=>");

                string action = arguments[0]; 
                string cityName = arguments[1];
                switch (action)
                {
                    case "Plunder":
                        int peopleKilled = int.Parse(arguments[2]);
                        int goldStolen = int.Parse(arguments[3]);

                        map[cityName].Population -= peopleKilled;
                        map[cityName].Gold -= goldStolen;
                        Console.WriteLine($"{cityName} plundered! {goldStolen} gold stolen, {peopleKilled} citizens killed.");

                        if (map[cityName].Population <= 0 ||
                        map[cityName].Gold <= 0)
                        {
                            Console.WriteLine($"{cityName} has been wiped off the map!");
                            map.Remove(cityName);
                        }
                        break;
                    case "Prosper":
                        int goldRise = int.Parse(arguments[2]);
                        if (goldRise > 0)
                        {
                            map[cityName].Gold += goldRise;
                            Console.WriteLine($"{goldRise} gold added to the city treasury. {cityName} now has {map[cityName].Gold} gold.");
                        }
                        else
                        {
                            Console.WriteLine($"Gold added cannot be a negative number!");
                        }
                        break;
                    default:
                        break;
                }
            }

            if (map.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {map.Count} wealthy settlements to go to:");
                foreach (KeyValuePair <string, City> kvp in map)
                {
                    Console.WriteLine($"{kvp.Value.Name} -> Population: {kvp.Value.Population} citizens, Gold: {kvp.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    class City
    {
        public City(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}