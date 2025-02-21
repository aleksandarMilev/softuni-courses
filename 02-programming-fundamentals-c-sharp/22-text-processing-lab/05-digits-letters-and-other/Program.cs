using System;
namespace _05DigitsLettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(string.Join("", input.Where(char.IsDigit)));
            Console.WriteLine(string.Join("", input.Where(char.IsLetter)));
            Console.WriteLine(string.Join("", input.Where(x => !char.IsLetterOrDigit(x))));
        }
    }
}