using System;
using System.Collections.Generic;
namespace _02OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split()
                .Select(x => x.ToLower())
                .ToArray();

            Dictionary<string, int> numbOcc = new Dictionary<string, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                string currWord = arr[i];
                if (!numbOcc.ContainsKey(currWord))
                {
                    numbOcc.Add(currWord, 0);
                }
                numbOcc[currWord]++;
            }

            foreach (KeyValuePair<string, int> kvp in numbOcc)
            {
                if (kvp.Value % 2 != 0)
                {
                    Console.Write($"{kvp.Key} ");
                }
            }
        }
    }
}