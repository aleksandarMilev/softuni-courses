using System;
using System.Text.RegularExpressions;
namespace _06ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"[^\.\-_]\b(?![\._\-])[A-Za-z0-9]+[\.\-_]*[A-Za-z0-9]+@[^\.\-](?:[A-Za-z\.\-]+\.)+[A-Za-z]+";

            foreach (Match match in Regex.Matches(input, pattern))
            {
                Console.WriteLine($"{match.Value}");
            }
        }
    }
}