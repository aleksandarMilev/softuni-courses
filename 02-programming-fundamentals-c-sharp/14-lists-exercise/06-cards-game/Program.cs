using System;
using System.Collections.Generic;
namespace _06CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCount = Math.Max(firstCards.Count, secondCards.Count);

            for (int i = 0; i < maxCount;)
            {
                if (secondCards.Count == 0)
                {
                    int sum = firstCards.Sum();
                    Console.WriteLine($"First player wins! Sum: {sum}");
                    break;
                }

                if (firstCards.Count == 0)
                {
                    int sum = secondCards.Sum();
                    Console.WriteLine($"Second player wins! Sum: {sum}");
                    break;
                }

                if (firstCards[i] > secondCards[i])
                {
                    int cardWinner = firstCards[i];
                    int cardLost = secondCards[i];
                    firstCards.Remove(cardWinner);
                    secondCards.Remove(cardLost);
                    firstCards.Add(cardWinner);
                    firstCards.Add(cardLost);
                }

                else if (secondCards[i] > firstCards[i])
                {
                    int cardWinner = secondCards[i];
                    int cardLost = firstCards[i];
                    secondCards.Remove(cardWinner);
                    firstCards.Remove(cardLost);
                    secondCards.Add(cardWinner);
                    secondCards.Add(cardLost);
                }

                else
                {
                    firstCards.Remove(firstCards[i]);
                    secondCards.Remove(secondCards[i]);
                }
            }
        }
    }
}