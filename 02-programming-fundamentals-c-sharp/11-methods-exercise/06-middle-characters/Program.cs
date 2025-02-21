using System;
namespace _06MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            PrintMiddleCharacter(text);
        }

        static void PrintMiddleCharacter(string text)
        {
            int length = text.Length;

            if (length % 2 == 0)
            {
                char firstMidDigit = text[text.Length / 2 - 1];
                char secondMidDigit = text[text.Length / 2];
                string midDigit = $"{firstMidDigit}{secondMidDigit}";
                Console.WriteLine(midDigit);
            }
            else
            {
                char midDigit = text[text.Length / 2];
                Console.WriteLine(midDigit);
            }
        }
    }
}