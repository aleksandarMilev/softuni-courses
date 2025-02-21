using System;
namespace _09HeartDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToArray();

            int lastIndex = 0;
            int index = 0;

            string command;
            while ((command = Console.ReadLine()) != "Love!")
            {
                string[] arrCommand = command.Split();

                int jumpLength = int.Parse(arrCommand[1]);
                index += jumpLength;

                if (index > numbers.Length - 1)
                {
                    index = 0;
                }

                lastIndex = index;

                if (numbers[index] == 0)
                {
                    Console.WriteLine($"Place {index} already had Valentine's day.");
                    continue;
                }
                else
                {
                    numbers[index] -= 2;
                }


                if (numbers[index] == 0)
                {
                    Console.WriteLine($"Place {index} has Valentine's day.");
                }

            }

            bool isLove = true;
            int unloveCount = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    isLove = false;
                    unloveCount++;
                }
            }

            Console.WriteLine($"Cupid's last position was {lastIndex}.");

            if (isLove)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {unloveCount} places.");
            }
        }
    }
}