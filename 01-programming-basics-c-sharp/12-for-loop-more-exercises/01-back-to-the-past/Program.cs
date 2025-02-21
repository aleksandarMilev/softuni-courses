using System;
namespace _01._Back_To_The_Past
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double finalYear = double.Parse(Console.ReadLine());
            double age = 18;
            double totalCost = 0;
            for (int i = 1_800; i <= finalYear; i++)
            {
                if (i % 2 == 0)
                {
                    totalCost += 12_000;
                }
                else
                {
                    totalCost += 12_000 + 50 * age;
                }
                age++;
            }
            if (budget >= totalCost)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {budget - totalCost:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {totalCost - budget:f2} dollars to survive.");
            }
        }
    }
}