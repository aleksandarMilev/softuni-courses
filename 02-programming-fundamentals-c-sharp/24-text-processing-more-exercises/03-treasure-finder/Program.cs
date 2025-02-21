using System;
namespace _03TreasureFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input;
            while ((input = Console.ReadLine()) != "find")
            {
                int keyIndex = -1;
                for (int i = 0; i < input.Length; i++)
                {
                    keyIndex++;
                    if (keyIndex == key.Length)
                    {
                        keyIndex = 0;
                    }

                    int currentNumber = key[keyIndex];
                    char currentChar = input[i];
                    char newChar = (char)(currentChar - currentNumber);

                    input = input.Remove(i, 1);
                    input = input.Insert(i, newChar.ToString());
                }

                int startIndexType = input.IndexOf('&');
                int endIndexType = input.LastIndexOf('&');
                string type = input.Substring(startIndexType + 1, endIndexType - startIndexType - 1);

                int startIndexCoordinates = input.IndexOf('<');
                int endIndexCoordinates = input.IndexOf('>');
                string coordinates = input.Substring(startIndexCoordinates + 1, endIndexCoordinates - startIndexCoordinates - 1);

                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}