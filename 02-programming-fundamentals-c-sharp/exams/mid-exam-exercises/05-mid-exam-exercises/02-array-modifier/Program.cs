using System;
namespace _02ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "swap":
                        int firstSwap = int.Parse(arguments[1]);
                        int secondSwap = int.Parse(arguments[2]);
                        SwapTwoIndex(numbers, firstSwap, secondSwap);
                        break;
                    case "multiply":
                        int firstMultiply = int.Parse(arguments[1]);
                        int secondMultiply = int.Parse(arguments[2]);
                        MultiplyTwoIndex(numbers, firstMultiply, secondMultiply);
                        break;
                    case "decrease":
                        DecreaseElements(numbers);
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }


        static void SwapTwoIndex(int[] numbers, int firstSwap, int secondSwap)
        {
            int temp = numbers[firstSwap];
            numbers[firstSwap] = numbers[secondSwap];
            numbers[secondSwap] = temp;
        }
        static void MultiplyTwoIndex(int[] numbers, int firstMultiply, int secondMultiply)
        {
            int product = numbers[firstMultiply] * numbers[secondMultiply];
            numbers[firstMultiply] = product;
        }
        static void DecreaseElements(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] -= 1;
            }
        }
    }
}