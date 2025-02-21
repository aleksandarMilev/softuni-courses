using System;
namespace _06WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceToSwimInMeters = double.Parse(Console.ReadLine());
            double secondsForOneMeter = double.Parse(Console.ReadLine());

            double timeToSwimTheWholeDistance = distanceToSwimInMeters * secondsForOneMeter;
            double timesSlowedDown = Math.Floor(distanceToSwimInMeters / 15);
            timeToSwimTheWholeDistance += timesSlowedDown * 12.5;
            if (recordInSeconds > timeToSwimTheWholeDistance)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {timeToSwimTheWholeDistance:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {timeToSwimTheWholeDistance - recordInSeconds:f2} seconds slower.");
            }
        }
    }
}