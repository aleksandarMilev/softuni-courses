using System;
namespace _08TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournamentsCount = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());

            int tournamentPoints = 0;
            double wons = 0;
            for (int i = 0; i < tournamentsCount; i++)
            {

                string tournamentsVar = Console.ReadLine();
                if (tournamentsVar == "W")
                {
                    tournamentPoints += 2000;
                    wons++;
                }
                else if (tournamentsVar == "F")
                {
                    tournamentPoints += 1200;
                }
                else if (tournamentsVar == "SF")
                {
                    tournamentPoints += 720;
                }
            }
            Console.WriteLine($"Final points: {startingPoints + tournamentPoints}");
            Console.WriteLine($"Average points: {tournamentPoints / tournamentsCount}");
            Console.WriteLine($"{wons / tournamentsCount * 100:f2}%");
        }
    }
}