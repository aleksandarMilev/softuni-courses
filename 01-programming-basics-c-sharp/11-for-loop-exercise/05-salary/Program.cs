using System;
namespace _05Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int openedSitesCount = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < openedSitesCount; i++)
            {
                string input = Console.ReadLine();
                if (input == "Facebook")
                {
                    salary -= 150;
                }
                else if (input == "Instagram")
                {
                    salary -= 100;
                }
                else if (input == "Reddit")
                {
                    salary -= 50;
                }
                if (salary <= 0)
                {
                    break;
                }
            }
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine($"{salary}");
            }
        }
    }
}