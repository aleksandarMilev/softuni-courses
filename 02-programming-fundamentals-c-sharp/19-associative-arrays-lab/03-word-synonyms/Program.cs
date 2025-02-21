using System;
using System.Collections.Generic;
namespace _03WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (!dict.ContainsKey(word))
                {
                    dict[word] = synonym;
                }
                else
                {
                    dict[word] += ", " + synonym;
                }
            }

            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}