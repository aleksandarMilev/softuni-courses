using System;
using System.Text.RegularExpressions;
namespace _01Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Furniture> furnitures = new List<Furniture>();
            string pattern = @">>\b(?<name>[A-Za-z]+)<<(?<price>\d+(?:\.\d+)?)\!(?<quantity>\d{1,})\b";

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                MatchCollection matchCollection = Regex.Matches(input, pattern);

                foreach (Match match in matchCollection)
                {
                    string name = match.Groups[1].Value;
                    decimal price = decimal.Parse(match.Groups[2].Value);
                    int quantity = int.Parse(match.Groups[3].Value);

                    Furniture furniture = new Furniture(name, price, quantity);
                    furnitures.Add(furniture);
                }
            }

            decimal sum = 0m;
            Console.WriteLine("Bought furniture:");
            foreach (Furniture f in furnitures)
            {
                Console.WriteLine($"{f.Name}");
                sum += f.Quantity * f.Price;
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
    class Furniture
    {
        public Furniture(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}