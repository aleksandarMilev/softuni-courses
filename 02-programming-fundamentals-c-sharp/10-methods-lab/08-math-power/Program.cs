using System;
namespace _08MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            Console.WriteLine(CalculatePower(number, power));
        }

        static double CalculatePower(double number, double power)
        { 
            return Math.Pow(number, power);
        }
    }
}