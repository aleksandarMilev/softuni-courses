using System;
namespace _01UsdToBgn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dollars = double.Parse(Console.ReadLine());
            double leva = dollars * 1.79549;
            Console.WriteLine(leva);
        }
    }
}