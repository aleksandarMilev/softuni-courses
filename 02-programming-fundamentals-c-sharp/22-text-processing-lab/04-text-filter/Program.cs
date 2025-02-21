using System;
namespace _04TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine().Split(", ");
            string input = Console.ReadLine();

            foreach (var word in banWords)
            {
                input = input.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(input);
        }
    }
}