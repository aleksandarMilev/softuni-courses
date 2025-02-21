using System;
namespace _06._Truck_Driver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kilometersPerMonth = double.Parse(Console.ReadLine());
            double priceForOneKilometer = 0;

            if (kilometersPerMonth <= 5_000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        priceForOneKilometer = 0.75;
                    break;
                    case "Summer":
                        priceForOneKilometer = 0.9;
                    break;
                    case "Winter":
                        priceForOneKilometer = 1.05;
                    break;
                    default : break;
                }
            }
            else if (kilometersPerMonth > 5_000 && kilometersPerMonth <= 10_000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        priceForOneKilometer = 0.95;
                        break;
                    case "Summer":
                        priceForOneKilometer = 1.1;
                        break;
                    case "Winter":
                        priceForOneKilometer = 1.25;
                        break;
                    default: break;
                }
            }
            else if (kilometersPerMonth > 10_000 && kilometersPerMonth <= 20_000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                    case "Summer":
                    case "Winter":
                        priceForOneKilometer = 1.45;
                        break;
                    default: break;
                }
            }
            double sum = priceForOneKilometer * kilometersPerMonth;
            double totalSum = sum * 4;
            double finalSum = totalSum * 0.9;
            Console.WriteLine($"{finalSum:f2}");
        }
    }
}