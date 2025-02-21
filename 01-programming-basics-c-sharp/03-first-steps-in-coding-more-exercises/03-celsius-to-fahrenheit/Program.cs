using System;
namespace _03._Celsius_to_Fahrenheit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double celsium = double.Parse(Console.ReadLine());
            double fahreheit = celsium * 1.8 + 32;
            Console.WriteLine($"{fahreheit:f2}");
        }
    }
}