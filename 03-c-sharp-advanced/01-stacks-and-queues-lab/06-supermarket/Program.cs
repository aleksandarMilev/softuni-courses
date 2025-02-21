using System;
namespace _06Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    while (customers.Any())
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }
                else
                {
                    string customer = command;
                    customers.Enqueue(customer);
                }
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}