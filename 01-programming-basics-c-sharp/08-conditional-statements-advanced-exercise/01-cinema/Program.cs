using System;
namespace _01Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                string ticketType = Console.ReadLine();
                int row = int.Parse(Console.ReadLine());
                int column = int.Parse(Console.ReadLine());
                int totalSeats = row * column;
                double ticketPrice = 0;
                switch (ticketType)
                {
                    case "Premiere": ticketPrice = 12; break;
                    case "Normal": ticketPrice = 7.50; break;
                    case "Discount": ticketPrice = 5.00; break;
                }
                Console.WriteLine($"{ticketPrice * totalSeats:f2} leva");
            }
        }
    }
}