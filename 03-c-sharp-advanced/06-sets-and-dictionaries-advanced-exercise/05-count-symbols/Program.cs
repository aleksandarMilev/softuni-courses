using System;
using System.Collections.Generic;
namespace _05CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> charsCount = new();

            foreach (char symbol in input)
            {
                if (!charsCount.ContainsKey(symbol))
                {
                    charsCount.Add(symbol, 0);
                }

                charsCount[symbol]++;
            }

            foreach (KeyValuePair<char, int> kvp in charsCount)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}