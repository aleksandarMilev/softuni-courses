using System;
namespace _9._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());
            int freeBelts = studentsCount / 6;

            double lightsaberTotal = lightsaberPrice * Math.Ceiling(studentsCount * 1.1);
            double robeTotal = robePrice * studentsCount;
            double beltTotal = (studentsCount - freeBelts) * beltPrice;
            double totalSum = lightsaberTotal + robeTotal + beltTotal;

            if (totalSum <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalSum - budget:f2}lv more.");
            }
        }
    }
}