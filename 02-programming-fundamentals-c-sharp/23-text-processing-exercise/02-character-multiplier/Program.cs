using System;
namespace _02CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string firstWord = input[0];
            string secondWord = input[1];

            double result = GetSum(firstWord, secondWord);
            Console.WriteLine(result);
        }

        private static double GetSum(string firstWord, string secondWord)
        {
            double result = 0;
            int length = Math.Max(firstWord.Length, secondWord.Length);

            for (int i = 0; i < length; i++)
            {
                if (i < firstWord.Length && i < secondWord.Length)
                {
                    result += firstWord[i] * secondWord[i];
                }
                else if (i < firstWord.Length)
                {
                    result += firstWord[i];
                }
                else if (i < secondWord.Length)
                {
                    result += secondWord[i];
                }
            }
            return result;
        }
    }
}