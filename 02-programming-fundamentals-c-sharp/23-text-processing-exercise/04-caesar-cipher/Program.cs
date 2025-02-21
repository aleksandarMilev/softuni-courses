using System;
namespace _04CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = (char)(input[i] + 3);
                result += currentChar;
            }

            Console.WriteLine(result);
        }
    }
}