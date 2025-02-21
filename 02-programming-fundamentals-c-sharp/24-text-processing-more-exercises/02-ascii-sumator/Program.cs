using System;
namespace _02AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            int result = 0;

            foreach (char c in text)
            {
                if (c > firstChar && c < secondChar)
                {
                    result += c;
                }
            }
            Console.WriteLine(result);
        }
    }
}