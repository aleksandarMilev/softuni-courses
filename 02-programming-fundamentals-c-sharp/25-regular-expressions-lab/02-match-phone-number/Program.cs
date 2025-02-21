using System;
using System.Text.RegularExpressions;
namespace _02MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regex = @"(\+359 2 \d{3} \d{4})|(\+359-2-\d{3}-\d{4}\b)";

            MatchCollection matched = Regex.Matches(input, regex);
            string[] output = matched
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", output));
        }
    }
}