using System;
namespace _01BlackFlag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double dailyPlunder = double.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double thirdDayPlunder = dailyPlunder * 1.5;

            double totalPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 3 == 0)
                {
                    totalPlunder += thirdDayPlunder;
                }
                else
                {
                    totalPlunder += dailyPlunder;
                }

                if (i % 5 == 0)
                {
                    totalPlunder *= 0.7;
                }

            }


            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double percentCollected = (totalPlunder / expectedPlunder) * 100;

                Console.WriteLine($"Collected only {percentCollected:f2}% of the plunder.");
            }
        }
    }
}