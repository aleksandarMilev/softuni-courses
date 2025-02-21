using System;
using System.Linq;
namespace _08Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] columnInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = columnInput[col];
                }
            }

            string[] bombCoordinates = Console.ReadLine().Split(" ");

            foreach (string coordinate in bombCoordinates)
            {
                int[] currentBombCoordinate = coordinate
                    .Split(",")
                    .Select(int.Parse)
                    .ToArray();

                int bombRow = currentBombCoordinate[0];
                int bombCol = currentBombCoordinate[1];

                if (IsCellValid(matrixSize, bombRow, bombCol))
                {
                    if (matrix[bombRow, bombCol] > 0)
                    {
                        int bombValue = matrix[bombRow, bombCol];

                        if (IsCellValid(matrixSize, bombRow - 1, bombCol) &&
                            matrix[bombRow - 1, bombCol] > 0)
                        {
                            matrix[bombRow - 1, bombCol] -= bombValue;
                        }

                        if (IsCellValid(matrixSize, bombRow - 1, bombCol + 1) &&
                            matrix[bombRow - 1, bombCol + 1] > 0) 
                        {
                            matrix[bombRow - 1, bombCol + 1] -= bombValue;
                        }

                        if (IsCellValid(matrixSize, bombRow, bombCol + 1) &&
                            matrix[bombRow, bombCol + 1] > 0)
                        {
                            matrix[bombRow, bombCol + 1] -= bombValue;
                        }

                        if (IsCellValid(matrixSize, bombRow + 1, bombCol + 1) &&
                            matrix[bombRow + 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol + 1] -= bombValue;
                        }

                        if (IsCellValid(matrixSize, bombRow + 1, bombCol) &&
                            matrix[bombRow + 1, bombCol] > 0)
                        {
                            matrix[bombRow + 1, bombCol] -= bombValue;
                        }

                        if (IsCellValid(matrixSize, bombRow + 1, bombCol - 1) &&
                            matrix[bombRow + 1, bombCol - 1] > 0) 
                        {
                            matrix[bombRow + 1, bombCol - 1] -= bombValue;
                        }

                        if (IsCellValid(matrixSize, bombRow, bombCol - 1) &&
                            matrix[bombRow, bombCol - 1] > 0)
                        {
                            matrix[bombRow, bombCol - 1] -= bombValue;
                        }

                        if (IsCellValid(matrixSize, bombRow - 1, bombCol - 1) &&
                            matrix[bombRow - 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol - 1] -= bombValue;
                        }

                        matrix[bombRow, bombCol] = 0;
                    }
                }
            }
            
            int aliveCount = 0;
            int aliveSum = 0;
            for (int r = 0; r < matrixSize; r++)
            {
                for (int c = 0; c < matrixSize; c++)
                {
                    if (matrix[r, c] > 0)
                    {
                        aliveSum += matrix[r, c];
                        aliveCount++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCount}");
            Console.WriteLine($"Sum: {aliveSum}");
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool IsCellValid(int size, int row, int col)
        {
            return row >= 0 && row < size &&
                col >= 0 && col < size;
        }
    }
}