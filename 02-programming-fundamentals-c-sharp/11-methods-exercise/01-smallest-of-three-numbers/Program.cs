using System;
using System.Reflection;

namespace _01SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            int index = int.Parse(Console.ReadLine());

            int[] splitArr = new int[numbers.Length];
            int splitArrIndex = 0;

            for (int i = index + 1; i < numbers.Length; i++)
            {
                splitArr[splitArrIndex] = numbers[i];
                splitArrIndex++;
            }

            for (int i = 0; i <= index; i++)
            {
                splitArr[splitArrIndex] = numbers[i];
                splitArrIndex++;
            }
            Console.WriteLine(string.Join(" ", splitArr));


























            //    PrintTheSmallestOfThreeIntegers();
            //}

            //private static void PrintTheSmallestOfThreeIntegers()
            //{
            //    int numbersCount = 3;
            //    int[] numbers = new int[numbersCount];
            //    int smallestNumber = int.MaxValue;

            //    for (int i = 0; i < numbersCount; i++)
            //    {
            //        numbers[i] = int.Parse(Console.ReadLine());
            //    }

            //    for (int i = 0; i < numbers.Length; i++)
            //    {
            //        if (numbers[i] < smallestNumber)
            //        {
            //            smallestNumber = numbers[i];
            //        }
            //    }

            //    Console.WriteLine(smallestNumber);
        }
    }
}