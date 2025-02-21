using System;
namespace _03Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string input = Console.ReadLine();

            while (input.Contains(wordToRemove))
            {
                int indexRemove = input.IndexOf(wordToRemove);
                input = input.Remove(indexRemove, wordToRemove.Length);
            }

            Console.WriteLine(input);
        }
    }
}