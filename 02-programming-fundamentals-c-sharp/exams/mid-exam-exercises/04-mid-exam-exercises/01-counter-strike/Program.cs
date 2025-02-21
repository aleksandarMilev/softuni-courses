using System;
namespace _01CounterStrike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int winsCount = 0;
            int i = 0;
            bool endBasttle = false;

            string command;
            while ((command = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(command);
                i++;

                if (energy >= distance)
                {
                    energy -= distance;
                    if (energy >= 0)
                    {
                        winsCount++;
                        if (i % 3 == 0)
                        {
                            energy += winsCount;
                        }
                    }
                }

                else
                {
                    endBasttle = true;
                    Console.WriteLine($"Not enough energy! Game ends with {winsCount} won battles and {energy} energy");
                    break;
                }
            }

            if (!endBasttle)
            {
                Console.WriteLine($"Won battles: {winsCount}. Energy left: {energy}");
            }
        }
    }
}