using System;
namespace _07AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figures = (Console.ReadLine());
            double area = 0;
            if (figures == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = a * a;
            }
            else if (figures == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (figures == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                area = Math.PI * r * r;
            }
            else if (figures == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double ha = double.Parse(Console.ReadLine());
                area = (a * ha) / 2;
            }
            Console.WriteLine($"{area:f3}");
        }
    }
}