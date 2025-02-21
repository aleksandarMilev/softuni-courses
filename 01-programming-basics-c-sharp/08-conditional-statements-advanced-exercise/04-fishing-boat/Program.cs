using System;

namespace _04FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherCount = int.Parse(Console.ReadLine());

            double shipCost = season switch
            {
                "Spring" => 3000,
                "Summer" => 4200,
                "Autumn" => 4200,
                "Winter" => 2600,
                _ => 0
            };
            if (fisherCount > 0 && fisherCount <= 6)
            {
                shipCost *= 0.9;
            }
            else if (fisherCount >= 7 && fisherCount <= 11)
            {
                shipCost *= 0.85;
            }
            else if (fisherCount > 12)
            {
                shipCost *= 0.75;
            }

            if (fisherCount % 2 == 0 && season != "Autumn")
            {
                shipCost *= 0.95;
            }

            if (budget >= shipCost)
            {
                Console.WriteLine($"Yes! You have {budget - shipCost:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {shipCost - budget:f2} leva.");
            }

        }
    }
}
