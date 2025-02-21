using System;
namespace _07._School_Camp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string typeOfGroup = Console.ReadLine();
            int studentsCount = int.Parse(Console.ReadLine());
            int nightsCount = int.Parse(Console.ReadLine());
            double priceForOneMan = 0;
            string sport = string.Empty;

            if (typeOfGroup == "boys" || typeOfGroup == "girls")
            {
                switch (season)
                {
                    case "Winter": priceForOneMan = 9.6; break;
                    case "Spring": priceForOneMan = 7.2; break;
                    case "Summer": priceForOneMan = 15; break;
                    default: break;
                }
            }
            else if (typeOfGroup == "mixed")
            {
                switch (season)
                {
                    case "Winter": priceForOneMan = 10; break;
                    case "Spring": priceForOneMan = 9.5; break;
                    case "Summer": priceForOneMan = 20; break;
                    default: break;
                }
            }
            double totalPriceForOneDay = priceForOneMan * studentsCount;
            if (studentsCount >= 50)
            {
                totalPriceForOneDay *= 0.5;
            }
            else if (studentsCount >= 20 && studentsCount < 50)
            {
                totalPriceForOneDay *= 0.85;
            }
            else if (studentsCount >= 10 && studentsCount < 20)
            {
                totalPriceForOneDay *= 0.95;
            }
            double totalSum = totalPriceForOneDay * nightsCount;
            if (typeOfGroup == "girls")
            {
                switch (season)
                {
                    case "Winter": sport = "Gymnastics"; break;
                    case "Spring": sport = "Athletics"; break;
                    case "Summer": sport = "Volleyball"; break;
                    default: break;
                }
            }
            else if (typeOfGroup == "boys")
            {
                switch (season)
                {
                    case "Winter": sport = "Judo"; break;
                    case "Spring": sport = "Tennis"; break;
                    case "Summer": sport = "Football"; break;
                    default: break;
                }
            }
            else if (typeOfGroup == "mixed")
            {
                switch (season)
                {
                    case "Winter": sport = "Ski"; break;
                    case "Spring": sport = "Cycling"; break;
                    case "Summer": sport = "Swimming"; break;
                    default: break;
                }
            }
            Console.WriteLine($"{sport} {totalSum:f2} lv.");
        }
    }
}