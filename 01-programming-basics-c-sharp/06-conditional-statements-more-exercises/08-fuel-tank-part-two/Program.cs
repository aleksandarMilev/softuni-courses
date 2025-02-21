using System;
namespace _08._Fuel_Tank___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double fuelAmount = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();
            double priceForLiter = 0;
            if (fuelType == "Gas")
            {
                priceForLiter = 0.93;
                if (clubCard == "Yes")
                {
                    priceForLiter -= 0.08;
                }
            }
            else if (fuelType == "Gasoline")
            {
                priceForLiter = 2.22;
                if (clubCard == "Yes")
                {
                    priceForLiter -= 0.18;
                }
            }
            else if (fuelType == "Diesel")
            {
                priceForLiter = 2.33;
                if (clubCard == "Yes")
                {
                    priceForLiter -= 0.12;
                }
            }
            double totalPrice = priceForLiter * fuelAmount;
            if (fuelAmount >= 20 && fuelAmount <= 25)
            {
                totalPrice *= 0.92;
            }
            else if (fuelAmount > 25)
            {
                totalPrice *= 0.9;
            }
            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    } 
}