using System;
namespace _01ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string reversedWord = string.Empty;
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    char c = input[i];
                    reversedWord += c;
                }

                Console.WriteLine($"{input} = {reversedWord}");
            }
        }
    }
}