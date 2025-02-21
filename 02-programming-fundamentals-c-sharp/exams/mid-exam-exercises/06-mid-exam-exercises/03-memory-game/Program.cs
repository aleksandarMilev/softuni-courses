using System;
using System.Collections.Generic;
namespace _03MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split()
                .ToList();

            bool isOver = false;
            int movesCount = 0;
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                int[] indexesInput = command.Split()
                    .Select(int.Parse)
                    .ToArray();
                movesCount++;

                int firstIndex = indexesInput[0];
                int secondIndex = indexesInput[1];
                if (!IsIndexesValid(elements, firstIndex, secondIndex))
                {
                    elements.Insert(elements.Count / 2, $"-{movesCount}a");
                    elements.Insert(elements.Count / 2 + 1, $"-{movesCount}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    continue;
                }

                if (elements[firstIndex] == elements[secondIndex])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[firstIndex]}!");
                    elements.Remove(elements[firstIndex]);
                    if (secondIndex > 0)
                    {
                        elements.Remove(elements[secondIndex - 1]);
                    }
                    else
                    {
                        elements.Remove(elements[secondIndex]);
                    }
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                if (elements.Count == 0)
                {
                    isOver = true;
                    Console.WriteLine($"You have won in {movesCount} turns!");
                    return;
                }
            }

            if (!isOver)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", elements));
            }
        }
        static bool IsIndexesValid(List<string> elements, int firstIndex, int secondIndex)
        {
            return (firstIndex != secondIndex) &&
                (firstIndex >= 0 && firstIndex <= elements.Count - 1) &&
                (secondIndex >= 0 && secondIndex <= elements.Count - 1);
        }
    }
}