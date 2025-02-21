using System;
using System.Collections.Generic;
using System.Linq;
namespace _07ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] arguments = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[0];
                string carNumber = arguments[1];

                switch (action)
                {
                    case "IN":
                        carNumbers.Add(carNumber);
                        break;
                    case "OUT":
                        carNumbers.Remove(carNumber);
                        break;
                    default:
                        break;
                }
            }

            if (carNumbers.Any())
            {
                foreach (string carNumber in carNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

        }
    }
}