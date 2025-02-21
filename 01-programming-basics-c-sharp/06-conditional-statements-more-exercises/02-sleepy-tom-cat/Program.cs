using System;
namespace _02._Sleepy_Tom_Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int restDays = int.Parse(Console.ReadLine());
            int catNorm = 30_000;

            int workDays = 365 - restDays;
            int restDaysPlayTime = restDays * 127;
            int workDaysPlayTime = workDays * 63;
            int totalPlay = restDaysPlayTime + workDaysPlayTime;
            if (totalPlay > catNorm)
            {
                double diff1 = totalPlay - catNorm;
                double hours1 = Math.Floor(diff1 / 60);
                double mins1 = diff1 % 60;
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours1} hours and {mins1} minutes more for play");
            }
            else
            {
                double diff2 = catNorm - totalPlay;
                double hours2 = Math.Floor(diff2 / 60);
                double mins2 = diff2 % 60;
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours2} hours and {mins2} minutes less for play");
            }
        }
    }
}