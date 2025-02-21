using System;
namespace _06._Flower_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int magnolias = int.Parse(Console.ReadLine());
            int zumbuls = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int cactus = int.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());

            double magnoliasSum = magnolias * 3.25;
            double zumbulsSum = zumbuls * 4;
            double rosesSum = roses * 3.5;
            double cactusSum = cactus * 8;
            double totalSumBeforeTax = magnoliasSum + zumbulsSum + rosesSum + cactusSum;
            double totalSum = totalSumBeforeTax * 0.95;
            if (totalSum >= giftPrice)
            {
                Console.WriteLine($"She is left with {Math.Floor(totalSum - giftPrice)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(giftPrice - totalSum)} leva.");
            }
        }
    }
}