using System.Text.RegularExpressions;
namespace _02MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textInput = Console.ReadLine();
            string pattern = @"(\#[A-Za-z]{3,}\#\#[A-Za-z]{3,}\#)|(\@[A-Za-z]{3,}\@\@[A-Za-z]{3,}\@)";

            MatchCollection matches = Regex.Matches(textInput, pattern);
            if (!matches.Any())
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }

            Dictionary<string, string> mirrorWords = new();
            foreach (Match match in matches)
            {
                string currentText = match.Value;
                var words = currentText.Where(ch => char.IsLetter(ch));
                string currentWords = new string(words.ToArray());

                if (currentWords.Length % 2 == 0)
                {
                    string firstPart = currentWords.Substring(0, currentWords.Length / 2);
                    string secondPart = currentWords.Substring(currentWords.Length / 2, currentWords.Length / 2);

                    string secondPartReversed = new string(secondPart.Reverse().ToArray());
                    if (secondPartReversed == firstPart)
                    {
                        mirrorWords.Add(firstPart, secondPart);
                    }
                }
            }


            Console.WriteLine($"{matches.Count} word pairs found!");

            if (mirrorWords.Any())
            {
                Console.WriteLine("The mirror words are:");

                string result = "";
                foreach (var item in mirrorWords)
                {
                    result += $"{item.Key} <=> {item.Value}, ";
                }

                Console.WriteLine(result.TrimEnd(',', ' '));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}