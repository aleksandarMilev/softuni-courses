using System;
namespace _01OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string searchBook = Console.ReadLine();
            int num = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {num} books.");
                    break;
                }
                if (command == searchBook)
                {
                    Console.WriteLine($"You checked {num} books and found it.");
                    break;
                }
                num++;
            }
        }
    }
}