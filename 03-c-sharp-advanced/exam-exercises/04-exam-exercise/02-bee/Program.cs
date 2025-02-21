namespace _02Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] territory = new char[size, size];
            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < size; row++)
            {
                string colInput = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    territory[row, col] = colInput[col];
                    if (colInput[col] == 'B')
                    {
                        currentRow = row;
                        currentCol = col;
                        territory[row, col] = '.';
                    }
                }
            }

            bool isOutOfTheTerritory = false;
            int pollinatedFlowersCount = 0;

            string command;
            while ((command = Console.ReadLine()) != "End" && !isOutOfTheTerritory)
            {
                MoveBee(size, ref currentRow, ref currentCol, ref isOutOfTheTerritory, command);
                pollinatedFlowersCount = CheckForFlower(territory, currentRow, currentCol, pollinatedFlowersCount);

                if (territory[currentRow, currentCol] == 'O')
                {
                    territory[currentRow, currentCol] = '.';
                    MoveBee(size, ref currentRow, ref currentCol, ref isOutOfTheTerritory, command);
                    pollinatedFlowersCount = CheckForFlower(territory, currentRow, currentCol, pollinatedFlowersCount);
                }
            }

            if (command == "End" && !isOutOfTheTerritory)
            {
                territory[currentRow, currentCol] = 'B';
            }

            PrintResult(size, territory, isOutOfTheTerritory, pollinatedFlowersCount);
            PrintMatrix(size, territory);
        }

        private static void MoveBee(int size, ref int currentRow, ref int currentCol, ref bool outOfArray, string command)
        {
            switch (command)
            {
                case "right":
                    if (currentCol < size - 1)
                    {
                        currentCol++;
                    }
                    else
                    {
                        outOfArray = true;
                        break;
                    }
                    break;
                case "left":
                    if (currentCol > 0)
                    {
                        currentCol--;
                    }
                    else
                    {
                        outOfArray = true;
                        break;
                    }
                    break;
                case "up":
                    if (currentRow > 0)
                    {
                        currentRow--;
                    }
                    else
                    {
                        outOfArray = true;
                        break;
                    }
                    break;
                case "down":
                    if (currentRow < size - 1)
                    {
                        currentRow++;
                    }
                    else
                    {
                        outOfArray = true;
                        break;
                    }
                    break;
                default:
                    break;
            }
        }
        private static int CheckForFlower(char[,] territory, int currentRow, int currentCol, int pollinatedFlowersCount)
        {
            if (territory[currentRow, currentCol] == 'f')
            {
                territory[currentRow, currentCol] = '.';
                pollinatedFlowersCount++;
            }

            return pollinatedFlowersCount;
        }
        private static void PrintResult(int size, char[,] territory, bool isOutOfTheTerritory, int flowersCount)
        {
            if (isOutOfTheTerritory)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (flowersCount < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowersCount} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowersCount} flowers!");
            }
        }
        private static void PrintMatrix(int size, char[,] territory)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(territory[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
