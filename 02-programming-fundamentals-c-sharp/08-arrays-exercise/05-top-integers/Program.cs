using System;
namespace _05TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                bool topInteger = true;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] <= numbers[j])
                    {
                        topInteger = false;
                        break;
                    }
                }
                if (topInteger)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}