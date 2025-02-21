using System;
namespace _05Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double totalPrice = GetToatalPrice(product, quantity);
            Console.WriteLine(totalPrice);
        }

        static double GetToatalPrice(string product, int quantity)
        {

            double productPrice = 0;
            double totalPrice = 0;

            switch (product)
            {
                case "coffee": productPrice = 1.5; break;
                case "water": productPrice = 1.00; break;
                case "coke": productPrice = 1.40; break;
                case "snacks": productPrice = 2.00; break;
                default: Console.WriteLine("Invalid input"); break;
            }

            totalPrice = quantity * productPrice;
            return totalPrice;
        }
    }
}