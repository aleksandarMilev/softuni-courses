using System;
namespace _04._Vegetable_Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double vegetablesPriceForKg = double.Parse(Console.ReadLine());
            double fruitsPriceForKg = double.Parse(Console.ReadLine());
            int kgVegetables = int.Parse(Console.ReadLine());
            int kgFruits = int.Parse(Console.ReadLine());

            double vegetables = vegetablesPriceForKg * kgVegetables;
            double fruits = fruitsPriceForKg * kgFruits;
            double totalSumInleva = fruits + vegetables;
            double totalSumInEuro = totalSumInleva / 1.94;
            Console.WriteLine($"{totalSumInEuro:f2}");
        }
    }
}