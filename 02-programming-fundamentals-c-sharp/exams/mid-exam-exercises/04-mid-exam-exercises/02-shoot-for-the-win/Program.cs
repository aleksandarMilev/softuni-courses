using System;
using System.Collections.Generic;
namespace _02ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int shotCount = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int indexInput = int.Parse(command);

                if (!IsIndexValid(numbers, indexInput))
                {
                    continue;
                }

                int currentNum = numbers[indexInput];
                numbers.RemoveAt(indexInput);

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (currentNum < numbers[i] && numbers[i] != -1)
                    {
                        numbers[i] -= currentNum;
                    }
                    else if (currentNum >= numbers[i] && numbers[i] != -1)
                    {
                        numbers[i] += currentNum;
                    }
                }
                numbers.Insert(indexInput, currentNum);
                numbers[indexInput] = -1;
                shotCount++;
            }

            Console.Write($"Shot targets: {shotCount} -> ");
            Console.WriteLine(string.Join(" ", numbers));
        }
        static bool IsIndexValid(List<int> numbers, int index)
        {
            return index >= 0 && index <= numbers.Count - 1;
        }
    }
}