using System;
using System.Text;
using System.Text.RegularExpressions;
namespace _04StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string starPattern = @"[SsTtAaRr]";
            string messagePattern = @"\@(?<planet>[A-Za-z]+)[^\@\-\!\:\>]*\:(?<population>\d+)[^\@\-\!\:\>]*\!(?<type>A|D)\![^\@\-\!\:\>]*\-\>[^\@\-\!\:\>]*?(?<soldiers>\d+)[^\@\-\!\:\>]*";
            List<Planet> planets = new List<Planet>();
            int inputCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                string input = Console.ReadLine();
                int key = Regex.Matches(input, starPattern).Count();

                StringBuilder message = new StringBuilder();
                foreach (char c in input)
                {
                    char newChar = (char)(c - key);
                    message.Append(newChar);
                }

                foreach (Match match in Regex.Matches(message.ToString(), messagePattern))
                {
                    string name = match.Groups[1].Value;
                    int population = int.Parse(match.Groups[2].Value);
                    char attackType = char.Parse(match.Groups[3].Value);
                    int soldiers = int.Parse(match.Groups[4].Value);

                    Planet planet = new Planet(name, population, attackType, soldiers);
                    planets.Add(planet);
                }
            }

            var attackList = planets.Where(x => x.AttackType == 'A')
                .OrderBy(x => x.Name)
                .ToList();

            Console.WriteLine($"Attacked planets: {attackList.Count}");
            foreach (Planet planet in attackList)
            {
                Console.WriteLine($"-> {planet.Name}");
            }

            var defendList = planets.Where(x => x.AttackType == 'D')
                .OrderBy(x => x.Name)
                .ToList();

            Console.WriteLine($"Destroyed planets: {defendList.Count}");
            foreach (Planet planet in defendList)
            {
                Console.WriteLine($"-> {planet.Name}");
            }
        }
    }
    
    class Planet
    {
        public Planet(string name, int population, char attackType, int soldiers)
        {
            Name = name;
            Population = population;
            AttackType = attackType;
            Soldiers = soldiers;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public char AttackType { get; set; }
        public int Soldiers { get; set; }

    }
}