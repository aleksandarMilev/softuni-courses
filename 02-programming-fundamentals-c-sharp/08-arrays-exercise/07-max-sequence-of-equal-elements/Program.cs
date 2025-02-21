using System;
namespace _07MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int longestSequenceStart = 0;
            int longestSequenceLength = 1;

            int currentSequenceStart = 0; 
            int currentSequenceLength = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    currentSequenceLength++;
                    if (currentSequenceLength > longestSequenceLength)
                    {
                        longestSequenceLength = currentSequenceLength;
                        longestSequenceStart = currentSequenceStart;
                    }
                }
                else
                {
                    currentSequenceStart = i;
                    currentSequenceLength = 1;
                }
            }

            for (int i = longestSequenceStart; i < longestSequenceStart + longestSequenceLength; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}