using System;
using System.Text.RegularExpressions;
namespace _02FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputsCount = int.Parse(Console.ReadLine());
            string barcodePattern = @"\@\#+[A-Z]([A-Za-z0-9]{4,})[A-Z]\@\#+";

            for (int i = 0; i < inputsCount; i++)
            {
                string barcode = Console.ReadLine();

                Match match = Regex.Match(barcode, barcodePattern);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    string sum = "";
                    if (match.Value.Any(x => char.IsDigit(x)))
                    {
                        foreach (char c in match.Value.Where(x => char.IsDigit(x)))
                        {
                            sum = sum += c;
                        }
                    }
                    else
                    {
                        sum = "00";
                    }
                    Console.WriteLine($"Product group: {sum}");
                }
            }
        }
    }
}