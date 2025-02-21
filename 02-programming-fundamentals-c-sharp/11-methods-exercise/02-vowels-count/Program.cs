using System;
namespace _02VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintVowelsCountInString();
        }

        private static void PrintVowelsCountInString()
        {
            string text = Console.ReadLine();
            int vowelsCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char currentLetter = text[i];
                if (isVowel(currentLetter))
                {
                    vowelsCount++;
                }
            }
            Console.WriteLine(vowelsCount);
        }

        static bool isVowel(char letter)
        {
            char[] vowelLetters = { 'a', 'e', 'o', 'u', 'i', 'A', 'E', 'O', 'U', 'I' };
            return vowelLetters.Contains(letter);
        }
    }
}