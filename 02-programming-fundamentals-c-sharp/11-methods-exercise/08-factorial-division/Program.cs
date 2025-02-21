using System;
namespace _08FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            double result = PrintQotient(a, b);
            Console.WriteLine($"{result:f2}");
        }

        static double PrintQotient(int a, int b)
        {
            double aFactorial = 1;
            double bFactorial = 1;
            for (int i = 1; i <= a; i++)
            {
                aFactorial *= i;
            }
            for (int i = 1; i <= b; i++)
            {
                bFactorial *= i;
            }
            double result = aFactorial / bFactorial;
            return result;
        }
    }
}