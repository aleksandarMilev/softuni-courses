using System;
using System.Collections.Generic;
using System.Linq;
namespace _01CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (char c in input)
            {
                if (c == ' ')
                {
                    continue;
                }

                if (!dictionary.ContainsKey(c))
                {
                    dictionary.Add(c, 1);
                }
                else
                {
                    dictionary[c]++;
                }
            }

            foreach (KeyValuePair<char, int> kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}