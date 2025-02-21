using System;
namespace _05PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbersAsQueue = new(numbersInput);

            string result = "";
            while (numbersAsQueue.Any())
            {
                int number = numbersAsQueue.Dequeue();
                if (number % 2 == 0)
                {
                    result += $"{number}, ";
                }
            }

            Console.WriteLine(result.TrimEnd(',', ' '));
        }
    }
}