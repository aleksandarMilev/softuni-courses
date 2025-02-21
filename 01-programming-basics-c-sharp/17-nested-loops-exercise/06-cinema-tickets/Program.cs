using System;
namespace _06CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentTickets = 0;
            int standardTickets = 0;
            int kidTickets = 0;
            int allTicketsCount = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Finish")
                {
                    Console.WriteLine($"Total tickets: {allTicketsCount}");
                    double studentP = studentTickets / (double)allTicketsCount * 100;
                    Console.WriteLine($"{studentP:f2}% student tickets.");
                    double standardP = standardTickets / (double)allTicketsCount * 100;
                    Console.WriteLine($"{standardP:f2}% standard tickets.");
                    double kidP = kidTickets / (double)allTicketsCount * 100;
                    Console.WriteLine($"{kidP:f2}% kids tickets.");
                    break;
                }
                string movieName = command;
                int halLCapacity = int.Parse(Console.ReadLine());
                int ticketsSold = 0;
                for (int i = 0; i < halLCapacity; i++)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")
                    {
                        break;
                    }

                    switch (ticketType)
                    {
                        case "student": studentTickets++; break;
                        case "standard": standardTickets++; break;
                        case "kid": kidTickets++; break;
                    }
                    ticketsSold++;
                    allTicketsCount++;
                }

                double hallCapacityTaken = ticketsSold / (double)halLCapacity * 100;
                Console.WriteLine($"{movieName} - {hallCapacityTaken:f2}% full.");
            }
        }
    }
}