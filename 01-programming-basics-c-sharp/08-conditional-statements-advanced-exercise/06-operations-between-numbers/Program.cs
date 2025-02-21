using System;
namespace _06OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char o = char.Parse(Console.ReadLine());
            if (o == '+')
            {
                int result = num1 + num2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{num1} + {num2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} + {num2} = {result} - odd");
                }
            }
            else if (o == '-')
            {
                int result = num1 - num2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{num1} - {num2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} - {num2} = {result} - odd");
                }
            }
            else if (o == '*')
            {
                int result = num1 * num2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{num1} * {num2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} * {num2} = {result} - odd");
                }
            }
            else if (o == '/')
            {

                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    Console.WriteLine($"{num1} / {num2} = {(double)num1 / num2:f2}");
                }
            }
            else if (o == '%')
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    Console.WriteLine($"{num1} % {num2} = {num1 % num2}");
                }
            }
        }
    }
}
