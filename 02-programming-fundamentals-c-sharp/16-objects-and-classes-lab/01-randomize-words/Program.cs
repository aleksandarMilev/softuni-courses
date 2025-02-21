using System;
namespace _01RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split();

            Random random = new Random();

            for (int i = 0; i < text.Length; i++)
            {
                int randomIndex = random.Next(text.Length);

                string currWord = text[i];
                string randomWord = text[randomIndex];

                text[i] = randomWord;
                text[randomIndex] = currWord;
            }

            foreach (string word in text)
            {
                Console.WriteLine(word);
            }
        }
    }
}