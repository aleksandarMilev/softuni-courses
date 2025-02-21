using System;
namespace _06Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int piecesCount = width * length;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "STOP")
                {
                    Console.WriteLine($"{piecesCount} pieces are left.");
                    break;
                }

                int pieceToTake = int.Parse(command);
                if (pieceToTake > piecesCount)
                {
                    Console.WriteLine($"No more cake left! You need {pieceToTake - piecesCount} pieces more.");
                    break;
                }
                piecesCount -= pieceToTake;
            }
        }
    }
}