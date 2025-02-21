using System;
namespace _03._Harvest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double grapeAmount = x * y;
            double areaForWine = grapeAmount * 0.4;
            double litersWine = areaForWine / 2.5;
            if (z > litersWine)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(z - litersWine)} liters wine needed.");
            }
            else
            {
                double diff = litersWine - z;
                double diffPerWorker = diff / workers;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(litersWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(diff)} liters left -> {Math.Ceiling(diffPerWorker)} liters per person.");
            }
        }
    }
}