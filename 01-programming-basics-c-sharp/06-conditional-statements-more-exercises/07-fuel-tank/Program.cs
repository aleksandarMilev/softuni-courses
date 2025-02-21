using System;
namespace _07._Fuel_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double liters = double.Parse(Console.ReadLine());

            if (liters < 25)
            {
                switch (fuelType)
                {
                    case "Diesel":
                    case "Gasoline":
                    case "Gas":
                    Console.WriteLine($"Fill your tank with {fuelType.ToLower()}!"); break;
                    default : Console.WriteLine("Invalid fuel!"); break;
                }
            }
            else if (liters >= 25)
            {
                switch (fuelType)
                {
                    case "Diesel":
                    case "Gasoline":
                    case "Gas":
                    Console.WriteLine($"You have enough {fuelType.ToLower()}."); break;
                    default: Console.WriteLine("Invalid fuel!"); break;
                }
            }
        }
    }
}