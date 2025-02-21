using System;
namespace _08OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minuteExam = int.Parse(Console.ReadLine());
            int incomingHour = int.Parse(Console.ReadLine());
            int incomingMinute = int.Parse(Console.ReadLine());

            int examTotalMinuets = hourExam * 60 + minuteExam;
            int incomeTotalMinutes = incomingHour * 60 + incomingMinute;
            int timeDifference = examTotalMinuets - incomeTotalMinutes;

            if (timeDifference < 0)
            {
                Console.WriteLine("Late");
                int timeAbsolute = Math.Abs(timeDifference);

                if (timeAbsolute < 60)
                {
                    Console.WriteLine($"{timeAbsolute} minutes after the start");
                }
                else
                {
                    int hour = timeAbsolute / 60;
                    int minute = timeAbsolute % 60;
                    Console.WriteLine($"{hour}:{minute:D2} hours after the start");
                }
            }
            else if (timeDifference > 30)
            {
                Console.WriteLine("Early");
                if (timeDifference < 60)
                {
                    Console.WriteLine($"{timeDifference} minutes before the start");
                }
                else
                {
                    int hour = timeDifference / 60;
                    int minute = timeDifference % 60;
                    Console.WriteLine($"{hour}:{minute:D2} hours before the start");
                }
            }
            else
            {
                Console.WriteLine("On Time");
                if (timeDifference > 0)
                {
                    Console.WriteLine($"{timeDifference} minutes before the start");
                }
            }
        }
    }
}
