using System;
namespace _08LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }
                , StringSplitOptions
                .RemoveEmptyEntries);

            decimal result = 0;

            foreach (var word in input)
            {
                string temp = word;
                char firstLetter = word[0];
                char lastLetter = word[word.Length - 1];
                temp = word.Remove(0, 1);
                temp = temp.Remove(temp.Length - 1, 1);
                int number = int.Parse(temp);

                decimal firstLetterPosition = char.ToLower(firstLetter) - 'a' + 1;
                if (char.IsUpper(firstLetter))
                {
                    result += number / firstLetterPosition;
                }
                else
                {
                    result += number * firstLetterPosition;
                }

                decimal lastLetterPosition = char.ToLower(lastLetter) - 'a' + 1;
                if (char.IsUpper(lastLetter))
                {
                    result -= lastLetterPosition;
                }
                else
                {
                    result += lastLetterPosition;
                }
            }

            Console.WriteLine($"{result:f2}");
        }
    }
}