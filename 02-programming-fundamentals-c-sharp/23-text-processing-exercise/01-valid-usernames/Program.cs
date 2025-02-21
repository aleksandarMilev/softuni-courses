using System;
using System.Collections.Generic;
namespace _01ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            string[] input = Console.ReadLine().Split(", ");

            foreach (var word in input)
            {
                bool isIllegal = false;
                if (word.Length < 3 || word.Length > 16)
                {
                    continue;
                }

                foreach (char c in word)
                {
                    if (!char.IsLetter(c) &&
                        !char.IsDigit(c) &&
                        c != '-' &&
                        c != '_')
                    {
                        isIllegal = true;
                        break;
                    }
                }

                if (!isIllegal)
                {
                    words.Add(word);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}