using System;
namespace _03SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            Stack<string> stack = new(input.Reverse());
            int result = int.Parse(stack.Pop());

            while (stack.Any())
            {
                string sign = stack.Pop();
                int number = int.Parse(stack.Pop());

                if (sign == "+")
                {
                    result += number;
                }
                else if (sign == "-")
                {
                    result -= number;
                }
            }

            Console.WriteLine(result);
        }
    }
}