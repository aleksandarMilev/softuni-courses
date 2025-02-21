using System;
using System.Collections.Generic;
namespace _02SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] counts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new();
            HashSet<int> secondSet = new();

            for (int i = 0; i < counts[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < counts[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}