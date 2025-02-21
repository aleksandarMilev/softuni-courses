using System;
using System.Text.RegularExpressions;

namespace _02EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            List<string> validList = new List<string>();

            string input = Console.ReadLine();
            string emojiPattern = @"\:\:[A-Z][a-z]{2,}\:\:|\*\*[A-Z][a-z]{2,}\*\*";
            string digitPattern = @"\d";

            foreach (Match match in Regex.Matches(input, emojiPattern))
            {
                list.Add(match.Value);
            }

            ulong coolNumber = 1;
            foreach (Match match in Regex.Matches(input, digitPattern))
            {
                coolNumber *= ulong.Parse(match.Value);
            }

            foreach (string emoji in list)
            {
                ulong currEmojiSum = 0;
                foreach (char c in emoji)
                {
                    if (!char.IsLetter(c))
                    {
                        continue;
                    }
                    currEmojiSum += c;
                }

                if (currEmojiSum > coolNumber)
                {
                    validList.Add(emoji);
                }
            }

            Console.WriteLine($"Cool threshold: {coolNumber}");
            Console.WriteLine($"{list.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join(Environment.NewLine, validList));
        }
    }
}