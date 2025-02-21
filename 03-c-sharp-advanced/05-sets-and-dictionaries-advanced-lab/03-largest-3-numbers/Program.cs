using System;
using System.Collections.Generic;
using System.Linq;
namespace _03Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            if (numbers.Count < 3)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }

            List<int> largestThreeNumbers = numbers.OrderByDescending(n => n)
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(" ", largestThreeNumbers));
        }
    }
}