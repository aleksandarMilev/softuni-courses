using System;
using System.Linq;
namespace _02SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int columns = input[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] inputColumn = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = inputColumn[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int columnSum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    columnSum += matrix[row, col];
                }
                Console.WriteLine(columnSum);
            }
        }
    }
}