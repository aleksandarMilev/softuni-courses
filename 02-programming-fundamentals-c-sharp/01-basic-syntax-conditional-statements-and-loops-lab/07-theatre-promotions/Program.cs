using System;
namespace _7._Theatre_Promotions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();  
            int peopleAge = int.Parse(Console.ReadLine());
            if (peopleAge < 0 || peopleAge > 122)
            {
                Console.WriteLine("Error!");
                return;
            }
            int ticketPrice = 0;
            if (peopleAge >= 0 && peopleAge <=18)
            {
                switch (typeOfDay)
                {
                    case "Weekday": ticketPrice = 12; break;
                    case "Weekend": ticketPrice = 15; break;
                    case "Holiday": ticketPrice = 5; break;
                    default: break;
                }
            }
            else if (peopleAge > 18 && peopleAge <= 64)
            {
                switch (typeOfDay)
                {
                    case "Weekday": ticketPrice = 18; break;
                    case "Weekend": ticketPrice = 20; break;
                    case "Holiday": ticketPrice = 12; break;
                    default: break;
                }
            }
            else if (peopleAge > 64 && peopleAge <= 122)
            {
                switch (typeOfDay)
                {
                    case "Weekday": ticketPrice = 12; break;
                    case "Weekend": ticketPrice = 15; break;
                    case "Holiday": ticketPrice = 10; break;
                    default: break;
                }
            }
            Console.WriteLine($"{ticketPrice}$");
        }
    }
}