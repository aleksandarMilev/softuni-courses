using System;
using System.Collections.Generic;
using System.Linq;
namespace _01CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> map = new();

            foreach (double number in numbers)
            {
                if (!map.ContainsKey(number))
                {
                    map.Add(number, 0);
                }

                map[number]++;
            }

            foreach (KeyValuePair<double, int> kvp in map)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}