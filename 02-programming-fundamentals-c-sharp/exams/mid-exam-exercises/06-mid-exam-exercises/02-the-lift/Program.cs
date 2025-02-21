using System;
namespace _02TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peoples = int.Parse(Console.ReadLine());

            int[] lift = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int taken = 0;
            for (int i = 0; i < lift.Length; i++)
            {
                taken += lift[i];
            }

            int max = (lift.Length * 4) - taken;

            for (int i = 0; i < lift.Length && max > 0; i++)
            {
                while (lift[i] < 4 && peoples > 0 && max > 0)
                {
                    lift[i]++;
                    peoples--;
                    max--;
                }

                if (peoples == 0 && max > 0)
                {
                    Console.WriteLine("The lift has empty spots!");
                    Console.WriteLine(string.Join(" ", lift));
                    break;
                }

                if (peoples > 0 && max == 0)
                {
                    Console.WriteLine($"There isn't enough space! {peoples} people in a queue!");
                    Console.WriteLine(string.Join(" ", lift));
                    break;
                }

                if (peoples == 0 && max == 0)
                {
                    Console.WriteLine(string.Join(" ", lift));
                    break;
                }
            }
        }
    }
}