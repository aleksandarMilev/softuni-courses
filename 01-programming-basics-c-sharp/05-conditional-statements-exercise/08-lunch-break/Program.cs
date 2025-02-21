using System;
namespace _08LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int episodeLenght = int.Parse(Console.ReadLine());
            double lunchBreakLenght = int.Parse(Console.ReadLine());

            double lunchTime = lunchBreakLenght / 8;
            double restTime = lunchBreakLenght / 4;
            double timeLeft = lunchBreakLenght - (lunchTime + restTime);
            if (timeLeft > episodeLenght)
            {
                Console.WriteLine($"You have enough time to watch {seriesName} and left with {Math.Ceiling(timeLeft - episodeLenght)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {Math.Ceiling(episodeLenght - timeLeft)} more minutes.");
            }
        }
    }
}