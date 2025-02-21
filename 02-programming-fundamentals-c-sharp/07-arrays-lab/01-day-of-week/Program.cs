using System;
namespace _01DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] days =
            { 
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            int input = int.Parse(Console.ReadLine());
            if (input >= 1 && input <= 7)
            {
                string day = days[input - 1];
                Console.WriteLine(day);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}