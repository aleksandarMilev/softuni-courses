using System;
namespace _08SecretDoorLock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int upperLimitHundreds = int.Parse(Console.ReadLine());
            int upperLimitTens = int.Parse(Console.ReadLine());
            int upperLimitOnes = int.Parse(Console.ReadLine());

            for (int hundrets = 1; hundrets <= upperLimitHundreds; hundrets++)
            {
                if (hundrets % 2 == 0)
                {
                    for (int tens = 2; tens <= upperLimitTens; tens++)
                    {
                        bool isPrime = true;
                        for (int divisor = 2; divisor <= Math.Sqrt(tens); divisor++)
                        {
                            if (tens % divisor == 0)
                            {
                                isPrime = false;
                            }
                        }
                        if (isPrime)
                        {
                            for (int ones = 1; ones <= upperLimitOnes; ones++)
                            {
                                if (ones % 2 == 0)
                                {
                                    Console.WriteLine($"{hundrets} {tens} {ones}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}