using System;
using System.Collections.Generic;
namespace _02GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            
            List<int> resultList = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                int firstNumber = numbers[i];
                int lastNumber = numbers[numbers.Count - i - 1];
                int result = firstNumber + lastNumber;
                resultList.Add(result);
            }

            if (numbers.Count % 2 != 0)
            {
                int middleIndex = numbers.Count / 2;
                resultList.Add(numbers[middleIndex]);
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}