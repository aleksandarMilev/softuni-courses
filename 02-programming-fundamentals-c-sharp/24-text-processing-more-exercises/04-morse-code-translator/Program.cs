using System;
using System.Text;
namespace _04MorseCodeTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> morseCodeMap = new Dictionary<string, char>()
            {
                { ".-", 'a'},
                { "-...", 'b'},
                { "-.-.", 'c'},
                { "-..", 'd'},
                { ".", 'e'},
                { "..-.", 'f'},
                { "--.", 'g'},
                { "....", 'h'},
                { "..", 'i'},
                { ".---", 'j'},
                { "-.-", 'k'},
                { ".-..", 'l'},
                { "--", 'm'},
                { "-.", 'n'},
                { "---", 'o'},
                { ".--.", 'p'},
                { "--.-", 'q'},
                { ".-.", 'r'},
                { "...", 's'},
                { "-", 't'},
                { "..-", 'u'},
                { "...-", 'v'},
                { ".--", 'w'},
                { "-..-", 'x'},
                { "-.--", 'y'},
                { "--..", 'z'},
            };

            string[] input = Console.ReadLine().Split();
            StringBuilder translatedMessage = new StringBuilder();

            foreach (string morseSymb in input)
            {
                if (morseCodeMap.ContainsKey(morseSymb))
                {
                    translatedMessage.Append(char.ToUpper(morseCodeMap[morseSymb]));
                }

                if (morseSymb == "|")
                {
                    translatedMessage.Append(" ");
                }
            }
            Console.WriteLine(translatedMessage.ToString());
        }
    }
}