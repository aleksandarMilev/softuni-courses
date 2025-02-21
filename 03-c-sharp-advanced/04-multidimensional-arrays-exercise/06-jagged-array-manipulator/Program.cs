using System;
using System.Linq;
namespace _06JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];

            PopulateJagged(jagged);

            MultiplyOrDivideJaggedRows(jagged);

            string command;
            while ((command = Console.ReadLine()).ToLower() != "end")
            {
                string[] arguments = command.Split();

                string action = arguments[0].ToLower();
                int row = int.Parse(arguments[1]);
                int col = int.Parse(arguments[2]);
                int value = int.Parse(arguments[3]);

                if (AreCoordinatesValid(jagged, row, col))
                {
                    switch (action)
                    {
                        case "add":
                            jagged[row][col] += value;
                            break;
                        case "subtract":
                            jagged[row][col] -= value;
                            break;
                        default:
                            break;
                    }
                }
            }

            PrintJaggedArray(jagged);
        }

        static void PopulateJagged(int[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                int[] columnInput = Console.ReadLine().
                    Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jagged[row] = columnInput;
            }
        }

        static void MultiplyOrDivideJaggedRows(int[][] jagged)
        {
            for (int i = 0; i < jagged.Length - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] *= 2;
                        jagged[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] /= 2;
                    }

                    for (int j = 0; j < jagged[i + 1].Length; j++)
                    {
                        jagged[i + 1][j] /= 2;
                    }
                }
            }
        }

        static bool AreCoordinatesValid(int[][] jagged, int row, int col)
        {
            return row >= 0 && row < jagged.Length &&
                col >= 0 && col < jagged[row].Length;
        }

        static void PrintJaggedArray(int[][] jagged)
        {
            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }
        }
    }
}