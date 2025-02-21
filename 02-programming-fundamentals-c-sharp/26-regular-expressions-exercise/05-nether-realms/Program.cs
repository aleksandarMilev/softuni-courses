using System;
using System.Text;
using System.Text.RegularExpressions;
namespace _05NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Demon> demons = new List<Demon>();
            string[] input = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string letterPatern = @"[^0-9\*\/\+\-\.]";
            string digitsPattern = @"(?<digits>(?:\-|\+)?(\d+(\.\d+)?))";

            for (int i = 0; i < input.Length; i++)
            {
                string name = input[i];
                StringBuilder letters = new StringBuilder();
                foreach (Match match in Regex.Matches(name, letterPatern))
                {
                    letters.Append(match.Value);
                }

                int health = 0;
                foreach (char c in letters.ToString())
                {
                    health += c;
                }

                decimal damage = 0m;
                foreach (Match match in Regex.Matches(name, digitsPattern))
                {
                    bool isNegative = false;
                    string digitAsString = match.Value;
                    if (digitAsString.Contains('-'))
                    {
                        isNegative = true;
                        int indexRemove = digitAsString.IndexOf('-');
                        digitAsString = digitAsString.Remove(indexRemove, 1);
                    }

                    if (!isNegative)
                    {
                        damage += decimal.Parse(digitAsString);
                    }
                    else
                    {
                        damage += decimal.Parse(digitAsString) * -1;
                    }
                }

                foreach (char c in input[i])
                {
                    if (c == '/')
                    {
                        damage /= 2;
                    }
                    else if (c == '*')
                    {
                        damage *= 2;
                    }
                }

                Demon demon = new Demon(name, health, damage);
                demons.Add(demon);
            }

            if (demons.Count > 0)
            {
                demons = demons.OrderBy(x => x.Name)
                    .ToList();
                foreach (Demon demon in demons)
                {
                    Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
                }
            }
        }
    }

    class Demon
    {
        public Demon(string name, int health, decimal damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public decimal Damage { get; set; }
    }
}