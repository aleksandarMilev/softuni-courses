using System;
namespace _06EvenAndOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int evenSum = 0;
            int oddSum = 0;
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (currentNumber % 2 == 0)
                {
                    evenSum += currentNumber;
                }
                else
                {
                    oddSum += currentNumber;
                }
            }
            int sum = evenSum - oddSum;
            Console.WriteLine(sum);
        }
    }
}