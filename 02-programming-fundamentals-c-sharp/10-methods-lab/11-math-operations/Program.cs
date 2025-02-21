using System;
namespace _11MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            char operatorr = char.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            double result = 0;

            switch (operatorr)
            {
                case '+': result = GetSumOfNumbers(a, b); break;
                case '-': result = GetDifferenceOfNumbers(a, b); break;
                case '*': result = GetProductOfNumbers(a, b); break;
                case '/': result = GetQuotientOfNumbers(a, b); break;
                default: Console.WriteLine("Invalid input!"); break;
            }
            Console.WriteLine(result);
        }

        static double GetSumOfNumbers(int a, int b)
        {
            int sum = a + b;
            return sum;
        }

        static double GetDifferenceOfNumbers(int a, int b)
        {
            int difference = a - b;
            return difference;
        }

        static double GetProductOfNumbers(int a, int b)
        {
            int product = a * b;
            return product;
        }

        static double GetQuotientOfNumbers(int a, int b)
        {
            int quotient = a / b;
            return quotient;
        }

    }
}