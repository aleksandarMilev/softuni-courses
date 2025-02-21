using System;
namespace _01TheHuntingGames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double waterPerMan = double.Parse(Console.ReadLine());
            double foodPerMan = double.Parse(Console.ReadLine());

            double water = days * waterPerMan * players;
            double food = days * foodPerMan * players;
            int daysCount = 0;
            bool isOver = false;
            while (!isOver && days > 0)
            {
                daysCount++;
                days--;
                double energyLoss = double.Parse(Console.ReadLine());
                energy -= energyLoss;

                if (energy <= 0)
                {
                    isOver = true;
                    Console.WriteLine($"You will run out of energy. You will be left with {food:f2} food and {water:f2} water.");
                    break;
                }

                if (daysCount % 2 == 0)
                {
                    energy *= 1.05;
                    water *= 0.7;
                }

                if (daysCount % 3 == 0)
                {
                    energy *= 1.1;
                    food -= food / players;
                }
            }

            if (!isOver)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
            }
        }
    }
}
