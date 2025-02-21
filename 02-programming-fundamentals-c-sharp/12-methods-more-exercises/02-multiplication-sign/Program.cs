using System;
namespace _05MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int negativeCount = 0;

            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
                return;
            }

            if (num1 < 0)
                negativeCount++;
            if (num2 < 0)
                negativeCount++;
            if (num3 < 0)
                negativeCount++;

            if (negativeCount % 2 == 0)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }

        }
    }
}