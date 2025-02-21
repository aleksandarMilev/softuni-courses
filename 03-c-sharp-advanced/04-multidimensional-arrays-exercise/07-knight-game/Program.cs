using System;
using System.Linq;
namespace _07KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                string colInput = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = colInput[col];
                }
            }

            int knightsRemovedCount = 0;
            while (true)
            {
                int mostAttackingCount = 0;
                int mostAttackingRow = 0;
                int mostAttackingCol = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int attackedKnights = AttackedKnightsCount(row, col, size, matrix);
                            if (mostAttackingCount < attackedKnights)
                            {
                                mostAttackingCount = attackedKnights;
                                mostAttackingRow = row;
                                mostAttackingCol = col;
                            }
                        }
                    }
                }

                if (mostAttackingCount == 0)
                {
                    break;
                }
                else
                {
                    matrix[mostAttackingRow, mostAttackingCol] = '0';
                    knightsRemovedCount++;
                }
            }

            Console.WriteLine(knightsRemovedCount);
        }

        static bool AreCoordinatesValid(int row, int col, int size)
        {
            return row >= 0 && row < size &&
                col >= 0 && col < size;
        }

        static int AttackedKnightsCount(int row, int col, int size, char[,] matrix)
        {
            int attackedKnights = 0;

            if (AreCoordinatesValid(row - 1, col - 2, size))//
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (AreCoordinatesValid(row + 1, col - 2, size))//
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (AreCoordinatesValid(row - 1, col + 2, size))//
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (AreCoordinatesValid(row + 1, col + 2, size))//
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (AreCoordinatesValid(row - 2, col - 1, size))//
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (AreCoordinatesValid(row - 2, col + 1, size))//
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (AreCoordinatesValid(row + 2, col - 1, size))//
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (AreCoordinatesValid(row + 2, col + 1, size))//
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }
             
            return attackedKnights;
        }
    }
}
