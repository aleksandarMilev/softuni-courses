using System;
namespace _05._Training_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double lengthCm = double.Parse(Console.ReadLine()) * 100;
            double widthCm = double.Parse(Console.ReadLine()) * 100 - 100;

            double spaceRemainderAtLength = lengthCm % 120;
            double freeSpaceAtLength = lengthCm - spaceRemainderAtLength;
            double seatsAtLength = freeSpaceAtLength / 120;

            double spaceRemainderAtWidth = widthCm % 70;
            double freeSpaceAtWidth = widthCm - spaceRemainderAtWidth;
            double seatsAtWidth = freeSpaceAtWidth / 70;

            double totalSeats = seatsAtLength * seatsAtWidth - 3;
            Console.WriteLine(totalSeats);
        }
    }
}