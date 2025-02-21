using System;
namespace _10TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 10; i <= n; i++)
            {
                if (FindTopNumbers(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool FindTopNumbers(int number)
        {
            int sumOfDigits = 0;
            int oddDigitsCount = 0;
            while (number > 0)
            {
                int currentDigit = number % 10;
                sumOfDigits += currentDigit;
                if (currentDigit % 2 != 0)
                {
                    oddDigitsCount++;
                }
                number  /= 10;
            }
            if (sumOfDigits % 8 == 0 && oddDigitsCount > 0)
            {
                return true;
            }
            return false;
        }
    }
}