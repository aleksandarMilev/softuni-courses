namespace _02Garden 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] garden = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    garden[row, col] = 0;
                }
            }

            List<int[]> positionsBloomed = new();
            int listIndex = 0;

            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] positionsPlanted = command
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                int row = positionsPlanted[0];
                int col = positionsPlanted[1];

                if (row >= rows || col >= cols)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    garden[row, col]++;

                    while (row > 0)
                    {
                        garden[--row, col]++;
                    }
                    ResetCoordinates(positionsPlanted, out row, out col);

                    while (row < rows - 1)
                    {
                        garden[++row, col]++;
                    }
                    ResetCoordinates(positionsPlanted, out row, out col);

                    while (col > 0)
                    {
                        garden[row, --col]++;
                    }
                    ResetCoordinates(positionsPlanted, out row, out col);

                    while (col < cols - 1)
                    {
                        garden[row, ++col]++;
                    }
                }
            }

            PrtintMatrix(rows, cols, garden);
        }

        private static void ResetCoordinates(int[] positionsPlanted, out int row, out int col)
        {
            row = positionsPlanted[0];
            col = positionsPlanted[1];
        }
        private static void PrtintMatrix(int rows, int cols, int[,] garden)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
