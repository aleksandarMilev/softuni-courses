using System;
namespace _01SoftUniReception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEfficiency = int.Parse(Console.ReadLine());
            int secondEfficiency = int.Parse(Console.ReadLine());
            int thirdEfficiency = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int studentsPerHour = firstEfficiency + secondEfficiency + thirdEfficiency;
            int hours = 0;
            while (studentsCount > 0)
            {
                hours++;

                if (hours % 4 == 0)
                {
                    continue;
                }

                studentsCount -= studentsPerHour;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}