using System;
namespace _03SquareOfStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    Console.Write('*' + " ");
                }
                Console.WriteLine();
            }
        }
    }
}