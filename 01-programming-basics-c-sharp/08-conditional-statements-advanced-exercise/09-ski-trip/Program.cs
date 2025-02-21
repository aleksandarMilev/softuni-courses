using System;
namespace _09SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nightsCount = int.Parse(Console.ReadLine()) - 1;
            string roomType = Console.ReadLine();
            string reviewType = Console.ReadLine();
            double roomPrice = roomType switch
            {
                "room for one person" => 18.00,
                "apartment" => 25,
                "president apartment" => 35.00,
                _ => 0
            };
            double totalPrice = nightsCount * roomPrice;
            if (roomType == "apartment")
            {
                if (nightsCount < 10)
                {
                    totalPrice *= 0.7;
                }
                else if (nightsCount >= 10 && nightsCount <= 15)
                {
                    totalPrice *= 0.65;
                }
                else
                {
                    totalPrice *= 0.50;
                }
            }
            else if (roomType == "president apartment")
            {
                if (nightsCount < 10)
                {
                    totalPrice *= 0.9;
                }
                else if (nightsCount >= 10 && nightsCount <= 15)
                {
                    totalPrice *= 0.85;
                }
                else
                {
                    totalPrice *= 0.80;
                }
            }
            if (reviewType == "positive")
            {
                totalPrice *= 1.25;
            }
            else if (reviewType == "negative")
            {
                totalPrice *= 0.90;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
