using System;
namespace _07._House_Painting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double sideWallArea = x * y;
            double windowArea = 1.5 * 1.5;
            double sideWallsSumNoWindows = 2 * sideWallArea - 2 * windowArea;
            double backWall = x * x;
            double door = 1.2 * 2;
            double frontAndBackSumNoDoor = backWall * 2 - door;
            double totalWallSum = sideWallsSumNoWindows + frontAndBackSumNoDoor;
            double greenPaint = totalWallSum / 3.4;

            double roofSides = 2 * x * y;
            double roofFrontAndBack = 2 * (x * h / 2);
            double roofTotalSum = roofFrontAndBack + roofSides;
            double redPaint = roofTotalSum / 4.3;

            Console.WriteLine($"{greenPaint:f2}");
            Console.WriteLine($"{redPaint:f2}");
        }
    }
}