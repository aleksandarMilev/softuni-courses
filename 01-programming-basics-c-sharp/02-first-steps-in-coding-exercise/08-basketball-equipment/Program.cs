using System;
namespace _08BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yearlyTax = int.Parse(Console.ReadLine());

            double shoesPrice = yearlyTax - (yearlyTax * 0.4);
            double clothesPrice = shoesPrice - (shoesPrice * 0.2);
            double ballPrice = clothesPrice / 4.0;
            double accessory = ballPrice / 5.0;
            double totalPrice = yearlyTax + shoesPrice + clothesPrice + ballPrice + accessory;
            Console.WriteLine(totalPrice);
        }
    }
}