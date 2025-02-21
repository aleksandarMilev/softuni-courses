namespace _02Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int currentRow = 0;
            int currentCol = 0;
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            const int FoodTarget = 10;
            int currentFood = 0;

            bool gameOver = false;
            bool fed = false;
            while (!gameOver && !fed)
            {
                if (matrix[currentRow, currentCol] == '*')
                {
                    currentFood++;
                    if (currentFood == FoodTarget)
                    {
                        fed = true;
                    }
                }

                matrix[currentRow, currentCol] = '.';

                if (matrix[currentRow, currentCol] == 'B')
                {
                    for (int row = 0; row < size; row++)
                    {
                        for (int col = 0; col < size; col++)
                        {
                            if (matrix[row, col] == 'B')
                            {
                                currentRow = row;
                                currentCol = col;
                            }
                        }
                    }
                }

                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        if (currentRow > 0)
                        {
                            currentRow--;
                        }
                        else
                        {
                            gameOver = true;
                        }
                        break;
                    case "down":
                        if (currentRow < size - 1)
                        {
                            currentRow++;
                        }
                        else
                        {
                            gameOver = true;
                        }
                        break;
                    case "left":
                        if (currentCol > 0)
                        {
                            currentCol--;
                        }
                        else
                        {
                            gameOver = true;
                        }
                        break;
                    case "right":
                        if (currentCol < size - 1)
                        {
                            currentCol++;
                        }
                        else
                        {
                            gameOver = true;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (gameOver)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                matrix[currentRow, currentCol] = 'S';
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {currentFood}");
            PrintMatrix(size, matrix);
        }

        private static void PrintMatrix(int size, char[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
