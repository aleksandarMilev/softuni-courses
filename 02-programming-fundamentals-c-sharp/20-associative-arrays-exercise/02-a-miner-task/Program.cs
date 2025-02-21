using System;
using System.Collections.Generic;
using System.Linq;
namespace _02AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            while (true)
            {
                string resourse = Console.ReadLine();
                string quantityAsString = Console.ReadLine();

                if (resourse == "stop" || quantityAsString == "stop")
                {
                    break;
                }

                int quantity = int.Parse(quantityAsString);

                if (!dictionary.ContainsKey(resourse))
                {
                    dictionary.Add(resourse, quantity);
                }
                else
                {
                    dictionary[resourse] += quantity;
                }
            }

            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}