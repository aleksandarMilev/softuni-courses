using System;
namespace _10MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());
            int positiveNumber = Math.Abs(numberInput);
            int evenSum = GetSumOfEvenDigits(positiveNumber);
            int oddSum = GetSumOfOddDigits(positiveNumber);
            int product = GetMultipleOfEvenAndOdds(evenSum, oddSum);
            Console.WriteLine(product);
        
        }

        static int GetSumOfEvenDigits(int number)
        {
            int positiveNumber = Math.Abs(number);
            int evenSum = 0;
            string numberAsString = number.ToString();
            for (int i = 0; i < numberAsString.Length; i++)
            {
                int currentDigit = numberAsString[i] - '0';
                if (currentDigit % 2 == 0)
                {
                    evenSum += currentDigit;
                }
            }
            return evenSum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int positiveNumber = Math.Abs(number);
            int oddSum = 0;
            string numberAsString = number.ToString();
            for (int i = 0; i < numberAsString.Length; i++)
            {
                int currentDigit = numberAsString[i] - '0';
                if (currentDigit % 2 != 0)
                {
                    oddSum += currentDigit;
                }
            }
            return oddSum;
        }

        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            int result = evenSum * oddSum;
            return result;
        }
    }
}