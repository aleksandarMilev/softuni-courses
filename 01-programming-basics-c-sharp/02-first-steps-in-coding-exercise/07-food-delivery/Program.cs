using System;
namespace _07FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numChickenMenu = int.Parse(Console.ReadLine());
            int numFishMenu = int.Parse(Console.ReadLine());
            int numVegMenu = int.Parse(Console.ReadLine());

            double priceForChickenMenu = numChickenMenu * 10.35;
            double priceForFishMenu = numFishMenu * 12.4;
            double priceForVegMenu = numVegMenu * 8.15;
            double totalPriceForMenus = priceForChickenMenu + priceForFishMenu + priceForVegMenu;
            double priceForDessert = totalPriceForMenus * 0.2;
            double taxForDelivery = 2.5;
            double totalSum = totalPriceForMenus + taxForDelivery + priceForDessert;
            Console.Write(totalSum);
        }
    }
}