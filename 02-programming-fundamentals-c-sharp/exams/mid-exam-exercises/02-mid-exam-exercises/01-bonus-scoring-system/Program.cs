using System;
namespace _01BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            double maxBonus = 0;
            int maxAttendances = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                int attendances = int.Parse(Console.ReadLine());
                double totalBonus = Math.Round((double)attendances / lecturesCount * (5 + additionalBonus));
                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    maxAttendances = attendances;
                }
            }

            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");
        }
    }
}