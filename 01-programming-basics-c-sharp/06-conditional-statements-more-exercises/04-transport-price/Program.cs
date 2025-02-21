using System;
namespace _04._Transport_Price
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();

            double totalSum = 0;

            if (n < 20)
            {
                switch (dayOrNight)
                {
                    case "day": totalSum = 0.7 + n * 0.79; break;
                    case "night": totalSum = 0.7 + n * 0.9; break;
                    default: break;
                }
            }
            else if (n >= 20 && n < 100)
            {
                switch (dayOrNight)
                {
                    case "day": totalSum = n * 0.09; break;
                    case "night": totalSum = n * 0.09; break;
                    default : break; 
                }
            }
            else if (n >= 100)
            {
                switch (dayOrNight)
                {
                    case "day": totalSum = n * 0.06; break;
                    case "night": totalSum = n * 0.06; break;
                    default: break;
                }
            }
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}