using System;
namespace _05AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int sum = SumCalaculations(a, b);
            int result = SubtractCalculations(sum, c);
            Console.WriteLine(result);
        }

        static int SumCalaculations(int a, int b)
        {
            int result = a + b;
            return result;
        }

        static int SubtractCalculations(int sum, int c)
        {
            int result = sum - c;
            return result;
        }
    }
}