using System;
namespace _05Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                double budget = double.Parse(Console.ReadLine());
                double income = 0;
                while (budget > income)
                {
                    income += double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {input}!");
                input = Console.ReadLine();
            }
    }
}