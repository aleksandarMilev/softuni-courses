using System;
namespace _03FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal epsilon = 0.000001m;
            decimal a = decimal.Parse(Console.ReadLine());
            decimal b = decimal.Parse(Console.ReadLine());
            if (Math.Abs(a - b) < epsilon)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}