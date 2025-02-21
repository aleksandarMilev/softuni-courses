using System;
namespace _09SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intervalStart = int.Parse(Console.ReadLine());
            int intervalEnd = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int counter = 0;
            bool numberFound = false;

            for (int num1 = intervalStart; num1 <= intervalEnd; num1++)
            {
                for (int num2 = intervalStart; num2 <= intervalEnd; num2++)
                {
                    counter++;
                    if (num1 + num2 == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({num1} + {num2} = {magicNumber})");
                        numberFound = true;
                        break;
                    }
                }
                if (numberFound)
                {
                    break;
                }
            }
            if (!numberFound)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }
        }
    }
}