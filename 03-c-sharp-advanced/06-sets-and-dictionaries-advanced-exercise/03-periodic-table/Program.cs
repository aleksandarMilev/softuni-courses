using System;
using System.Collections.Generic;
namespace _03PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int elementsCount = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new();

            for (int i = 0; i < elementsCount; i++)
            {
                string[] elementsInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                elements.UnionWith(elementsInput);
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}