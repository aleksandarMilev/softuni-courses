using System;
using System.Linq;
namespace _06JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            string command;
            while ((command = Console.ReadLine()).ToLower() != "end")
            {
                string[] arguments = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string action = arguments[0].ToLower();
                int row = int.Parse(arguments[1]);
                int col = int.Parse(arguments[2]);
                int value = int.Parse(arguments[3]);

                if (!AreCoordinatesValid(jaggedArray, row, col))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (action)
                {
                    case "add":
                        jaggedArray[row][col] += value;
                        break;
                    case "subtract":
                        jaggedArray[row][col] -= value;
                        break;
                    default:
                        break;
                }
            }

            foreach (int[] arr in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
        static bool AreCoordinatesValid(int[][] jaggedArray, int row, int col)
        {
            return ((row >= 0 && row < jaggedArray.Length) &&
                (col >= 0 && col < jaggedArray[row].Length));
        }
    }
}