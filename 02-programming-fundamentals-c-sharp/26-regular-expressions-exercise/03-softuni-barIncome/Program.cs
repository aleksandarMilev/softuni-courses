using System;
using System.Text.RegularExpressions;
namespace _03SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal totalSum = 0m;
            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                string pattern = @"\%(?<name>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+(?:\.\d+)?)\$";

                foreach (Match match in Regex.Matches(input, pattern))
                {
                    decimal currentProductPrice = int.Parse(match.Groups[3].Value) * decimal.Parse(match.Groups[4].Value);

                    Console.WriteLine($"{match.Groups[1].Value}: {match.Groups[2].Value} - {currentProductPrice:f2}");
                    totalSum += currentProductPrice;
                }
            }
            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}