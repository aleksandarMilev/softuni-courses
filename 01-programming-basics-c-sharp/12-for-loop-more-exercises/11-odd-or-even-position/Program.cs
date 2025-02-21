using System;
namespace _11._Odd_or_Even_Position
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += input;
                    if (input < evenMin)
                    {
                        evenMin = input;
                    }
                    if (input > evenMax)
                    {
                        evenMax = input;
                    }
                }
                else
                {
                    oddSum += input;
                    if (input < oddMin)
                    {
                        oddMin = input;
                    }
                    if (input > oddMax)
                    {
                        oddMax = input;
                    }
                }
            }
            if (oddMin == double.MaxValue)
            {
                Console.WriteLine($"OddSum={oddSum:F2},");
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddSum={oddSum:F2},");
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
            }

            if (evenMin == double.MaxValue)
            {
                Console.WriteLine($"EvenSum={evenSum:F2},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenSum={evenSum:F2},");
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}