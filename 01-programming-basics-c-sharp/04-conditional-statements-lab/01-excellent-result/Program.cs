using System;
namespace _01ExcellentResult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double result = double.Parse(Console.ReadLine());
            if (result >= 5.5)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}