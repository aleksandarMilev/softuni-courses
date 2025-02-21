using System;
namespace _05GodzillaVsKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double filmBudget = double.Parse(Console.ReadLine());
            int extrasCount = int.Parse(Console.ReadLine());
            double priceForClothesForOneExtra = double.Parse(Console.ReadLine());
            double decorPrice = filmBudget * 0.1;
            double totalPriceForClothes = extrasCount * priceForClothesForOneExtra;
            if (extrasCount > 150)
            {
                totalPriceForClothes *= 0.9;
            }
            double totalSumForFilm = decorPrice + totalPriceForClothes;
            if (totalSumForFilm > filmBudget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totalSumForFilm - filmBudget:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {filmBudget - totalSumForFilm:f2} leva left.");
            }
        }
    }
}