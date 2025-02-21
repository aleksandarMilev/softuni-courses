using System;
using System.Linq;
namespace _05SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string word = Console.ReadLine();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            int wordIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (wordIndex == word.Length)
                        {
                            wordIndex = 0;
                        }

                        matrix[row, col] = word[wordIndex];
                        wordIndex++;
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (wordIndex == word.Length)
                        {
                            wordIndex = 0;
                        }

                        matrix[row, col] = word[wordIndex];
                        wordIndex++;
                    }
                }
            }

            PrintMatrix(rows, cols, matrix);
        }
        static void PrintMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}