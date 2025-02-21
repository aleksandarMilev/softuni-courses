using System;
namespace _13PrimePairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startFirst = int.Parse(Console.ReadLine());
            int startSecond = int.Parse(Console.ReadLine());
            int diffFirst = int.Parse(Console.ReadLine());
            int diffSecond = int.Parse(Console.ReadLine());

            for (int firstDigit = startFirst; firstDigit <= startFirst + diffFirst; firstDigit ++)
            {
                for (int secondDigit = startSecond; secondDigit <= startSecond + diffSecond; secondDigit ++)
                {
                    if (IsPrime(firstDigit) && IsPrime(secondDigit))
                    {
                        Console.WriteLine($"{firstDigit}{secondDigit}");
                    }
                }
            }
        }
        static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}