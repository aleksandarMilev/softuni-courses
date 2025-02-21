using System;
namespace _09FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentFully = double.Parse(Console.ReadLine());

            int volume = lenght * width * height;
            double volumeInLiters = volume * 0.001;
            double fullPart = percentFully / 100;
            double totalLiters = volumeInLiters * (1 - fullPart);
            Console.WriteLine(totalLiters);
        }
    }
}