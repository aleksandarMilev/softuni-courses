using System;
namespace _02._Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());
            int doctors = 7;
            int examinedPatiens = 0;
            int unexaminedPatiens = 0;
            for (int i = 1; i <= daysCount; i++)
            {
                if (i % 3 == 0)
                {
                    if (unexaminedPatiens > examinedPatiens)
                    {
                        doctors++;
                    }
                }
                int patiens = int.Parse(Console.ReadLine());
                if (doctors >= patiens)
                {
                    examinedPatiens += patiens;
                }
                else
                {
                    examinedPatiens += doctors;
                    unexaminedPatiens += patiens - doctors;
                }
            }
            Console.WriteLine($"Treated patients: {examinedPatiens}.");
            Console.WriteLine($"Untreated patients: {unexaminedPatiens}.");
        }
    }
}