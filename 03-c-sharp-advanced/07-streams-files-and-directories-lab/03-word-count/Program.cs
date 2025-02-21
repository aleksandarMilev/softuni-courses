namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> map = new();
            using StreamReader textReader = new(textFilePath);
            using StreamWriter writer = new(outputFilePath);
            using StreamReader wordsReader = new(wordsFilePath);

            string[] words = wordsReader.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string line = string.Empty;
            while (!textReader.EndOfStream)
            {
                line = textReader.ReadLine();
                string[] wordsInCurrLine = line.Split(new char[] { ' ', '.', ',', '!', '?', '-' });
                foreach (string word in words)
                {
                    for (int i = 0; i < wordsInCurrLine.Length; i++)
                    {
                        if (word.ToLower() == wordsInCurrLine[i].ToLower())
                        {
                            if (!map.ContainsKey(word))
                            {
                                map.Add(word, 0);
                            }

                            map[word]++;
                        }
                    }
                }
            }

            foreach (var item in map.OrderByDescending(x => x.Value))
            {
                writer.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
