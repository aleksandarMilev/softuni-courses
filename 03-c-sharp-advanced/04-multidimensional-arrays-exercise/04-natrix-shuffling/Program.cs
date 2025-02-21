using System;
using System.Linq;
namespace _04MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] columnInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = columnInput[col];
                }
            }

            string command;
            while ((command = Console.ReadLine()).ToLower() != "end")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!IsInputValid(arguments, matrix))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    int row1 = int.Parse(arguments[1]);
                    int col1 = int.Parse(arguments[2]);
                    int row2 = int.Parse(arguments[3]);
                    int col2 = int.Parse(arguments[4]);
                    Swap(matrix, row1, col1, row2, col2);
                    PrintMatrix(matrix);
                }
            }
        }

        static bool IsInputValid(string[] arguments, string[,] matrix)
        {
            return arguments[0].ToLower() == "swap" &&
                arguments.Length == 5 &&
                int.Parse(arguments[1]) >= 0 && int.Parse(arguments[1]) < matrix.GetLength(0) &&
                int.Parse(arguments[2]) >= 0 && int.Parse(arguments[2]) < matrix.GetLength(1) &&
                int.Parse(arguments[3]) >= 0 && int.Parse(arguments[3]) < matrix.GetLength(0) &&
                int.Parse(arguments[4]) >= 0 && int.Parse(arguments[4]) < matrix.GetLength(1);
                
        }

        static void Swap(string[,] matrix, int row1, int col1, int row2, int col2)
        {
            string temp = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = temp;
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}