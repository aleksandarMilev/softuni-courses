using System;
namespace _04ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tripCost = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollCount = int.Parse(Console.ReadLine());
            int bearCount = int.Parse(Console.ReadLine());
            int minionCount = int.Parse(Console.ReadLine());
            int truckCount = int.Parse(Console.ReadLine());
            double toysPriceSum = puzzleCount * 2.6 + dollCount * 3 + bearCount * 4.1 + minionCount * 8.2 + truckCount * 2;
            int toysCount = puzzleCount + dollCount + bearCount + minionCount + truckCount;
            if (toysCount >= 50)
            {
                toysPriceSum *= 0.75;
            }
            toysPriceSum *= 0.9;
            if (tripCost <= toysPriceSum)
            {
                Console.WriteLine($"Yes! {toysPriceSum - tripCost:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {tripCost - toysPriceSum:f2} lv needed.");
            }
        }
    }
}