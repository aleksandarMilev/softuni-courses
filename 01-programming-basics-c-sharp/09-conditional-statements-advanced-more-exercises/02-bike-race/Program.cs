using System;
namespace _02._Bike_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int juniorCount = int.Parse(Console.ReadLine());
            int seniorCount = int.Parse(Console.ReadLine());
            string routeType = Console.ReadLine();

            int totalCount = juniorCount + seniorCount;
            double juniorTax = 0;
            double seniorTax = 0;
            switch (routeType)
            {
                case "trail": juniorTax = 5.5; seniorTax = 7; break;
                case "cross-country": juniorTax = 8; seniorTax = 9.5; break;
                case "downhill": juniorTax = 12.25; seniorTax = 13.75; break;
                case "road": juniorTax = 20; seniorTax = 21.5; break;
            }
            double juniorSum = juniorTax * juniorCount;
            double seniorSum = seniorTax * seniorCount;
            double total = juniorSum + seniorSum;
            if (routeType == "cross-country")
            {
                if (totalCount >= 50)
                {
                    total *= 0.75;
                }
            }
            double finalSum = total * 0.95;
            Console.WriteLine($"{finalSum:f2}");
        }
    }
}