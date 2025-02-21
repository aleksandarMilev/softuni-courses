using System;
namespace _03._Flowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemumsCount = int.Parse(Console.ReadLine());
            int rosesCount = int.Parse(Console.ReadLine());
            int tulipCount = int.Parse(Console.ReadLine());
            int totalCount = chrysanthemumsCount + rosesCount + tulipCount; 
            string season = Console.ReadLine();
            char workingDay = char.Parse(Console.ReadLine());

            double chrysanthemumsPrice = 0;
            double rosesPrice = 0;
            double tulipPrice = 0;
            switch (season)
            {
                case "Spring": chrysanthemumsPrice = 2; rosesPrice = 4.1; tulipPrice = 2.5; break;
                case "Summer": chrysanthemumsPrice = 2; rosesPrice = 4.1; tulipPrice = 2.5; break;
                case "Autumn": chrysanthemumsPrice = 3.75; rosesPrice = 4.5; tulipPrice = 4.15; break;
                case "Winter": chrysanthemumsPrice = 3.75; rosesPrice = 4.5; tulipPrice = 4.15; break;
            }
            double totalSum = chrysanthemumsPrice * chrysanthemumsCount + rosesPrice * rosesCount + tulipPrice * tulipCount;
            if (workingDay == 'Y')
            {
                totalSum *= 1.15;
            }
            if (season == "Spring")
            {
                if (tulipCount > 7)
                {
                    totalSum *= 0.95;
                }
            }
            if (season == "Winter")
            {
                if (rosesCount >= 10)
                {
                    totalSum *= 0.9;
                }
            }
            if (totalCount > 20)
            {
                totalSum *= 0.8;
            }
            double finalSum = totalSum + 2;
            Console.WriteLine($"{finalSum:f2}");
        }
    }
}