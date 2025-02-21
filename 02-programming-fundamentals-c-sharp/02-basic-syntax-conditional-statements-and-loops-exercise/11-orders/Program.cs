using System;
namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            for (int i = 0; i < ordersCount; i++)
            {         
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int daysCount = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());
                double price = ((daysCount * capsulesCount) * pricePerCapsule);
                totalPrice += price;
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }
            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}