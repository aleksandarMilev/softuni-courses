using System;
namespace _3._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();
            double singlePrice = 0;

            if (day == "Friday")
            {
                switch (groupType)
                {
                    case "Students": singlePrice = 8.45; break;
                    case "Business": singlePrice = 10.9; break;
                    case "Regular": singlePrice = 15; break;
                    default: break;
                }
            }
            else if (day == "Saturday")
            {
                switch (groupType)
                {
                    case "Students": singlePrice = 9.8; break;
                    case "Business": singlePrice = 15.6; break;
                    case "Regular": singlePrice = 20; break;
                    default: break;
                }
            }
            else if (day == "Sunday")
            {
                switch (groupType)
                {
                    case "Students": singlePrice = 10.46; break;
                    case "Business": singlePrice = 16; break;
                    case "Regular": singlePrice = 22.5; break;
                    default: break;
                }
            }
            else
            {
                return;
            }
            double totalPrice = peopleCount * singlePrice;
            if (groupType == "Students" && peopleCount >= 30)
            {
                totalPrice *= 0.85;
            }
            if (groupType == "Business" && peopleCount >= 100)
            {
                totalPrice = (peopleCount - 10) * singlePrice;
            }
            if (groupType == "Regular" && peopleCount >= 10 && peopleCount <= 20)
            {
                totalPrice *= 0.95;
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}