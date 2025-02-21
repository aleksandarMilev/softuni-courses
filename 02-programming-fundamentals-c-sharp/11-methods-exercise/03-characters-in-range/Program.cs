using System;
namespace _03CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintCharsBetweenTwoChars();
        }

        private static void PrintCharsBetweenTwoChars()
        {
            char firstCharacter = char.Parse(Console.ReadLine());
            char secondCharacter = char.Parse(Console.ReadLine());

            if (secondCharacter < firstCharacter)
            {
                char temp = firstCharacter;
                firstCharacter = secondCharacter;
                secondCharacter = temp;
            }

            for (char character = (char)(firstCharacter + 1); character < secondCharacter; character++)
            {
                Console.Write(character + " ");
            }
        }
    }
}