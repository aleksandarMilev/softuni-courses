using System;
using System.Collections.Generic;
namespace _03Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int totalSum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                totalSum += numbers[i];
            }

            double average = (double)totalSum / numbers.Count;

            List<int> greaterList = new List<int>();
            bool isGreater = false;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > average)
                {
                    isGreater = true;
                    greaterList.Add(numbers[i]);
                }
            }

            if (!isGreater)
            {
                Console.WriteLine("No");
                return;
            }

            var orderedNumbers = greaterList.OrderByDescending(num => num).ToList();

            for (int i = 0; i < orderedNumbers.Count; i++)
            {
                Console.Write(orderedNumbers[i] + " ");
                if (i == 4)
                {
                    break;
                }
            }
        }
    }
}