using System;
using System.Linq;
namespace _09Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[fieldSize, fieldSize];

            int currentRow = 0;
            int currentCol = 0;
            int coalsCount = 0;
            for (int row = 0; row < fieldSize; row++)
            {
                char[] colInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = colInput[col];
                    if (colInput[col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    else if (colInput[col] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }

            foreach (string command in commands)
            {
                switch (command.ToLower())
                {
                    case "left":
                        if (currentCol > 0)
                        {
                            currentCol--;
                        }
                        break;
                    case "right":
                        if (currentCol < fieldSize - 1)
                        {
                            currentCol++;
                        }
                        break;
                    case "up":
                        if (currentRow > 0)
                        {
                            currentRow--;                           
                        }
                        break;
                    case "down":
                        if (currentRow < fieldSize - 1)
                        {
                            currentRow++;
                        }
                        break;
                    default:
                        break;
                }

                if (field[currentRow, currentCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }
                else if (field[currentRow, currentCol] == 'c')
                {
                    coalsCount--;
                    if (coalsCount == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        return;
                    }

                    field[currentRow, currentCol] = '*';
                }
            }

            Console.WriteLine($"{coalsCount} coals left. ({currentRow}, {currentCol})");
        }
    }
}