using System;
using System.Text.RegularExpressions;
namespace _01MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b([A-Z][a-z]{1,}) ([A-Z][a-z]{1,})\b";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match name in matches)
            {
                Console.Write(name.Value + " ");
            }
        }
    }
}