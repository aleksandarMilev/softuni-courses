using System;
namespace _05._Challenge_the_Wedding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mens = int.Parse(Console.ReadLine());
            int womens = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int loop = 0;

            for (int m = 1; m <= mens; m++)
            {
                for (int w = 1; w <= womens; w++)
                {
                    Console.Write($"({m} <-> {w})" + " ");
                    loop++;
                    if (loop >= capacity)
                    {
                        break;
                    }
                }
                if (loop >= capacity)
                {
                    break;
                }
            }         
        }
    }
}