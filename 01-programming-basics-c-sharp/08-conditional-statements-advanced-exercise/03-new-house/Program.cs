using System;
namespace _03NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double flowerPrice = flowerType switch
            {
                "Roses" => 5,
                "Dahlias" => 3.80,
                "Tulips" => 2.80,
                "Narcissus" => 3,
                "Gladiolus" => 2.50,
                _ => 0
            };
            double totalPrice = flowerPrice * flowersCount;
            if (flowerType == "Roses" && flowersCount > 80)
            {
                totalPrice *= 0.9;
            }
            else if (flowerType == "Dahlias" && flowersCount > 90)
            {
                totalPrice *= 0.85;
            }
            else if (flowerType == "Tulips" && flowersCount > 80)
            {
                totalPrice *= 0.85;
            }
            else if (flowerType == "Narcissus" && flowersCount < 120)
            {
                totalPrice *= 1.15;
            }
            else if (flowerType == "Gladiolus" && flowersCount < 80)
            {
                totalPrice *= 1.20;
            }
            if (budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersCount} {flowerType} and {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalPrice - budget:f2} leva more.");
            }
        }
    }
}
