using System;
namespace _05SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                int currentNumber = i;
                for (int j = 0; j < i.ToString().Length; j++)
                {
                    sum += currentNumber % 10;
                    currentNumber /= 10;
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}