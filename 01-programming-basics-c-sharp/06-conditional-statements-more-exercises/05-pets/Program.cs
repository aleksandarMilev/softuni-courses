using System;
namespace _05._Pets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int kgFoodLeft = int.Parse(Console.ReadLine());
            double dogFoodKgPerDay = double.Parse(Console.ReadLine());
            double catFoodKgPerDay = double.Parse(Console.ReadLine());
            double turtleFoodKgPerDay = double.Parse(Console.ReadLine()) / 1_000;

            double dogFoodNeed = days * dogFoodKgPerDay;
            double catFoodNeed = days * catFoodKgPerDay;
            double turtleFoodNeed = days * turtleFoodKgPerDay;
            double totalFoodNeed = dogFoodNeed + catFoodNeed + turtleFoodNeed;

            if (kgFoodLeft >= totalFoodNeed)
            {
                Console.WriteLine($"{Math.Floor(kgFoodLeft - totalFoodNeed)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(totalFoodNeed - kgFoodLeft)} more kilos of food are needed");
            }
        }
    }
}