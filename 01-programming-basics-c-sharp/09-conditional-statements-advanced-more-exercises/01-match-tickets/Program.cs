using System;
namespace _01._Match_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int groupCount = int.Parse(Console.ReadLine());

            double transportPrice = 0;
            double ticketPrice = 0;
            if (groupCount >=1 && groupCount <= 4)
            {
                transportPrice = budget * 0.75;
            }
            else if (groupCount >= 5 && groupCount <= 9)
            {
                transportPrice = budget * 0.6;
            }
            else if (groupCount >= 10 && groupCount <= 24)
            {
                transportPrice = budget * 0.5;
            }
            else if (groupCount >= 25 && groupCount <= 49)
            {
                transportPrice = budget * 0.4;
            }
            else if (groupCount > 49)
            {
                transportPrice = budget * 0.25;
            }

            if (category == "VIP")
            {
                ticketPrice = 499.99;
            }
            else if (category == "Normal")
            {
                ticketPrice = 249.99;
            }
            double totalTickets = ticketPrice * groupCount;
            double totalSum = totalTickets + transportPrice;
            if (budget >= totalSum)
            {
                Console.WriteLine($"Yes! You have {budget - totalSum:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalSum - budget:f2} leva.");
            }
        }
    }
}