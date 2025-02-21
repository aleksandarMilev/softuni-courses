using System;
using System.Linq;
namespace _01DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] colInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = colInput[col];
                }
            }

            int firstSum = 0;
            int secondSum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                firstSum += matrix[i, i];
                secondSum += matrix[matrix.GetLength(0) - 1 - i, i];
            }

            int result = Math.Abs(firstSum - secondSum);
            Console.WriteLine(result);
        }
    }
}