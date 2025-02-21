using System;
namespace _06._Wedding_Seats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rowsInFirstSector = int.Parse(Console.ReadLine());
            int seatsInOddRow = int.Parse(Console.ReadLine());
            int sectorsCount = 0;
            int seatsCount = 0;

            for (char i = 'A'; i <= lastSector; i++)
            {
                for (int rows = 1; rows <= rowsInFirstSector; rows++)
                {
                    if (rows % 2 != 0)
                    {
                        for (char seats = 'a'; seats < 'a' + seatsInOddRow; seats++)
                        {
                            Console.WriteLine($"{i}{rows}{seats}");
                            seatsCount++;
                        }
                    }
                    else
                    {
                        for (char seats = 'a'; seats < 'a' + seatsInOddRow + 2; seats++)
                        {
                            Console.WriteLine($"{i}{rows}{seats}");
                            seatsCount++;
                        }
                    }
                }
                rowsInFirstSector++;
            }
            Console.WriteLine(seatsCount);
        }
    }
}   