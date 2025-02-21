using System;
namespace _04._Car_To_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string classType = string.Empty;
            string carType = string.Empty;
            double price = 0;

            if (budget <= 100)
            {
                classType = "Economy class";
                if (season == "Summer")
                {
                    carType = "Cabrio";
                    price = budget * 0.35;
                }
                else if (season == "Winter")
                {
                    carType = "Jeep";
                    price = budget * 0.65;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                classType = "Compact class";
                if (season == "Summer")
                {
                    carType = "Cabrio";
                    price = budget * 0.45;
                }
                else if (season == "Winter")
                {
                    carType = "Jeep";
                    price = budget * 0.8;
                }
            }
            else if (budget > 500)
            {
                classType = "Luxury class";
                carType = "Jeep";
                price = budget * 0.9;
            }
            Console.WriteLine($"{classType}");
            Console.WriteLine($"{carType} - {price:f2}");
        }
    }
}