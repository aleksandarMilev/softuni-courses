using System;
using System.Collections.Generic;
using System.Linq;
namespace _04ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Shop> shops = new();

            string command;
            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] input = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Shop(shop));
                }

                if (!shops[shop].Catalog.ContainsKey(product))
                {
                    shops[shop].Catalog.Add(product, price);
                }
            }

            shops = shops
                .OrderBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair <string, Shop> kvp in shops)
            {
                Console.WriteLine($"{kvp.Key}->");
                foreach (KeyValuePair <string, double> kvp2 in kvp.Value.Catalog)
                {
                    Console.WriteLine($"Product: {kvp2.Key}, Price: {kvp2.Value}");
                }
            }
        }
    }

    class Shop
    {
        public Shop(string name)
        {
            Name = name;
            Catalog = new();
        }
        public string Name { get; set; }
        public Dictionary<string, double> Catalog { get; set; }
    }
}