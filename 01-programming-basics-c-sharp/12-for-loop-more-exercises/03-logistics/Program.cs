using System;
namespace _03._Logistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loads = int.Parse(Console.ReadLine());
            int levaAmount = 0;
            int totalAmount = 0;
            int byBus = 0;
            int byTruck = 0;
            int byTrain = 0;
            int totalTons = 0;

            for (int i = 1; i <= loads; i++)
            {
                int tons = int.Parse(Console.ReadLine());
                if (tons > 0 && tons <= 3)
                {
                    levaAmount = tons * 200;
                    totalAmount += levaAmount;
                    byBus += tons;
                    totalTons += tons;
                }
                else if (tons >= 4 && tons <= 11)
                {
                    levaAmount = tons * 175;
                    totalAmount += levaAmount;
                    byTruck += tons;
                    totalTons += tons;
                }
                else if (tons >= 12)
                {
                    levaAmount = tons * 120;
                    totalAmount += levaAmount;
                    byTrain += tons;
                    totalTons += tons;
                }
            }
            double averagePriceForTon = (double)totalAmount / totalTons;
            Console.WriteLine($"{averagePriceForTon:f2}");
            double percentByBus = (double)byBus / totalTons * 100;
            Console.WriteLine($"{percentByBus:f2}%");
            double percentByTruck = (double)byTruck / totalTons * 100;
            Console.WriteLine($"{percentByTruck:f2}%");
            double percentByTrain = (double)byTrain / totalTons * 100;
            Console.WriteLine($"{percentByTrain:f2}%");
        }
    }
}