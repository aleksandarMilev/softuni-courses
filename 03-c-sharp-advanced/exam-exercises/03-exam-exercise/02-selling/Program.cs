namespace _02Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] bakery = new char[size, size];

            int currentRow = 0;
            int currentCol = 0;
            ReadBakery(size, bakery, ref currentRow, ref currentCol);

            int currentMoney = 0;
            const int MoneyTarget = 50;
            bool outOfBakery = false;
            bool enoughMoney = false;

            while (!outOfBakery && !enoughMoney)
            {
                string command = Console.ReadLine();
                MoveBaker(size, ref currentRow, ref currentCol, ref outOfBakery, command);

                if (char.IsDigit(bakery[currentRow, currentCol]))
                {
                    AddMoney(bakery, currentRow, currentCol, ref currentMoney, MoneyTarget, ref enoughMoney);
                }
                else if (bakery[currentRow, currentCol] == 'O')
                {
                    SearchTheAnotherPillar(size, bakery, ref currentRow, ref currentCol);
                }
            }

            PrintOutput(size, bakery, currentRow, currentCol, currentMoney, outOfBakery, enoughMoney);
        }

        private static void ReadBakery(int size, char[,] bakery, ref int currentRow, ref int currentCol)
        {
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    bakery[row, col] = input[col];
                    if (input[col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                        bakery[currentRow, currentCol] = '-';
                    }
                }
            }
        }
        private static void MoveBaker(int size, ref int currentRow, ref int currentCol, ref bool outOfBakery, string command)
        {
            switch (command)
            {
                case "up":
                    if (currentRow > 0)
                    {
                        currentRow--;
                    }
                    else
                    {
                        outOfBakery = true;
                    }
                    break;
                case "down":
                    if (currentRow < size - 1)
                    {
                        currentRow++;
                    }
                    else
                    {
                        outOfBakery = true;
                    }
                    break;
                case "right":
                    if (currentCol < size - 1)
                    {
                        currentCol++;
                    }
                    else
                    {
                        outOfBakery = true;
                    }
                    break;
                case "left":
                    if (currentCol > 0)
                    {
                        currentCol--;
                    }
                    else
                    {
                        outOfBakery = true;
                    }
                    break;
                default:
                    break;
            }
        }
        private static void SearchTheAnotherPillar(int size, char[,] bakery, ref int currentRow, ref int currentCol)
        {
            bakery[currentRow, currentCol] = '-';
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (bakery[row, col] == 'O')
                    {
                        currentRow = row;
                        currentCol = col;
                        bakery[currentRow, currentCol] = '-';
                    }
                }
            }
        }
        private static void AddMoney(char[,] bakery, int currentRow, int currentCol, ref int currentMoney, int MoneyTarget, ref bool enoughMoney)
        {
            currentMoney += int.Parse(bakery[currentRow, currentCol].ToString());
            bakery[currentRow, currentCol] = '-';
            if (currentMoney >= MoneyTarget)
            {
                enoughMoney = true;
            }
        }
        private static void PrintOutput(int size, char[,] bakery, int currentRow, int currentCol, int currentMoney, bool outOfBakery, bool enoughMoney)
        {
            if (outOfBakery)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                bakery[currentRow, currentCol] = 'S';
            }

            if (enoughMoney)
            {
                Console.WriteLine($"Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {currentMoney}");

            PrintMatrix(size, bakery);
        }
        private static void PrintMatrix(int size, char[,] bakery)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(bakery[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
