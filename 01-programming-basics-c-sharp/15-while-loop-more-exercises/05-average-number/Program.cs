using System;
namespace _05._Average_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                sum += input;
            }
            double finalSum = (double)sum / n;
            Console.WriteLine($"{finalSum:f2}");
        }
    }
}