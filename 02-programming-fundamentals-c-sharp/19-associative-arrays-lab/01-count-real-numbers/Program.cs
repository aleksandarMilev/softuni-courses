using System;
using System.Collections.Generic;
namespace _01CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<int, int> numbersOcc = new SortedDictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int currNum = arr[i];
                if (!numbersOcc.ContainsKey(currNum))
                {
                    numbersOcc[currNum] = 1;
                }
                else
                {
                    numbersOcc[currNum]++;
                }
            }

            foreach (KeyValuePair<int, int> kvp in numbersOcc)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}