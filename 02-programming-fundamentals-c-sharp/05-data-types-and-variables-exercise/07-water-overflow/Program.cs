using System;
namespace _07WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double capacity = 255;
            for (int i = 0; i < n; i++)
            {
                double litersIncome = double.Parse(Console.ReadLine());
                if (capacity >= litersIncome)
                {
                    capacity -= litersIncome;
                }
                else if (capacity < litersIncome)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(255 - capacity);
        }
    }
}