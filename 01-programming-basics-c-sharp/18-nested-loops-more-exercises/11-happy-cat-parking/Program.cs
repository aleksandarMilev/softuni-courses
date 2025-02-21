using System;
namespace _11HappyCatParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hoursPerDay = int.Parse(Console.ReadLine());
            double sumPerHour = 0;
            double sumForDay = 0;
            double totalSum = 0;

            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                sumForDay = 0;
                for (int currentHour = 1; currentHour <= hoursPerDay; currentHour++)
                {
                    if (currentDay % 2 == 0 && currentHour % 2 != 0)
                    {
                        sumForDay += 2.5;
                    }
                    else if (currentDay % 2 != 0 && currentHour % 2 == 0)
                    {
                        sumForDay += 1.25;
                    }
                    else
                    {
                        sumForDay += 1;
                    }
                }
                Console.WriteLine($"Day: {currentDay} - {sumForDay:f2} leva");
                totalSum += sumForDay;
            }
            Console.WriteLine($"Total: {totalSum:f2} leva");
        }
    }
}