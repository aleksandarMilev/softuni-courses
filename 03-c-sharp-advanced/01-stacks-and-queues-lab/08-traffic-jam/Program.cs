using System;
namespace _08TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsPassPerGreen = int.Parse(Console.ReadLine());
            Queue<string> queue = new();
            int totalCarsPassed = 0;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                int currentCarsPassed = carsPassPerGreen;
                if (command == "green")
                {
                    while (currentCarsPassed > 0 && queue.Any())
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        currentCarsPassed--;
                        totalCarsPassed++;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }

            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
        }
    }
}