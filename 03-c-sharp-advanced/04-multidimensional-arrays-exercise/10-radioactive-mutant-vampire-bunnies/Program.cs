using System;
using System.Linq;
namespace _10RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];

            char[,] matrix = new char[rowsCount, colsCount];

            int currentRow = 0;
            int currentCol = 0;
            for (int row = 0; row < rowsCount; row++)
            {
                string colInput = Console.ReadLine();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = colInput[col];
                    if (colInput[col] == 'P')
                    {
                        currentRow = row;
                        currentCol = col;
                        matrix[currentRow, currentCol] = '.';
                    }
                }
            }

            string commands = Console.ReadLine();
            foreach (char command in commands)
            {
                int previousRow = currentRow;
                int previousCol = currentCol;
                switch (command)
                {
                    case 'L':
                        currentCol--;
                        break;
                    case 'R':
                        currentCol++;
                        break;
                    case 'U':
                        currentRow--;
                        break;
                    case 'D':
                        currentRow++;
                        break;
                    default:
                        break;
                }

                matrix = PopulateB(matrix, rowsCount, colsCount);

                if (currentCol < 0 ||
                    currentCol >= colsCount ||
                    currentRow < 0 ||
                    currentRow >= rowsCount)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {previousRow} {previousCol}");
                    return;
                }

                if (matrix[currentRow, currentCol] == 'B')
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {currentRow} {currentCol}");
                    return;
                }

            }
        }
        static char[,] PopulateB(char[,] matrix, int rows, int cols)
        {
            char[,] newMatrix = new char[rows, cols];

            CopyMatrix(matrix, rows, cols, newMatrix);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (col > 0)
                        {
                            newMatrix[row, col - 1] = 'B';
                        }

                        if (col < cols - 1)
                        {
                            newMatrix[row, col + 1] = 'B';
                        }

                        if (row > 0)
                        {
                            newMatrix[row - 1, col] = 'B';
                        }

                        if (row < rows - 1)
                        {
                            newMatrix[row + 1, col] = 'B';
                        }
                    }
                }
            }

            return newMatrix;
        }

        static void CopyMatrix(char[,] matrix, int rows, int cols, char[,] newMatrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    newMatrix[row, col] = matrix[row, col];
                }
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}