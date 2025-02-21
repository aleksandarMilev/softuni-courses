using System;
namespace _09YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalSqMeters = double.Parse(Console.ReadLine());
            double priceWithoutDiscount = totalSqMeters * 7.61;
            double discount = priceWithoutDiscount * 0.18;
            double finalPrice = priceWithoutDiscount - discount;
            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}