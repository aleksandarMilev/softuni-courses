using System;
namespace _03Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add": AddNumbers(a, b); break;
                case "subtract": SubtractNumbers(a, b); break;
                case "multiply": MultiplyNumbers(a, b); break;
                case "divide": DivideNumbers(a, b); break;
                default: Console.WriteLine("Invalid command"); break;
            }
        }

        static void AddNumbers(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static void SubtractNumbers(int a, int b)
        {
            Console.WriteLine(a / b);
        }

        static void MultiplyNumbers(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        static void DivideNumbers(int a, int b)
        {
            Console.WriteLine(a / b);
        }
    }
}