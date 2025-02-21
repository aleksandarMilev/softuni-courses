using System;
using System.Text.RegularExpressions;
namespace _03MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<day>\d{2})([.\-\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";
            MatchCollection matchCollection = Regex.Matches(input, pattern);

            foreach (Match matchedItem in matchCollection)
            {
                var day = matchedItem.Groups["day"].Value;
                var month = matchedItem.Groups["month"].Value;
                var year = matchedItem.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}