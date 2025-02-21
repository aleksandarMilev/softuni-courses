using System;
using System.Collections.Generic;
using System.Linq;
namespace _06Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Color> wardrobe = new();
            int inputsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsCount; i++)
            {
                string[] arguments = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = arguments[0];
                string clothesAsString = arguments[1];
                string[] clothesInput = clothesAsString.Split(",").ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Color(color));
                }

                foreach (string wear in clothesInput)
                {
                    if (!wardrobe[color].Clothes.ContainsKey(wear))
                    {
                        wardrobe[color].Clothes.Add(wear, 0);
                    }

                    wardrobe[color].Clothes[wear]++;
                }
            }

            string[] search = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorSearch = search[0]; 
            string wearSearch = search[1];

            foreach (KeyValuePair <string, Color> kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (KeyValuePair <string, int> kvp2 in kvp.Value.Clothes)
                {
                    if (kvp2.Key == wearSearch &&
                        kvp.Key == colorSearch)
                    {
                        Console.WriteLine($"* {kvp2.Key} - {kvp2.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {kvp2.Key} - {kvp2.Value}");
                    }
                }
            }
        }
    }

    class Color
    {
        public Color(string name)
        {
            Name = name;
            Clothes = new();
        }
        public string Name { get; set; }
        public Dictionary<string, int> Clothes { get; set; }
    }
}