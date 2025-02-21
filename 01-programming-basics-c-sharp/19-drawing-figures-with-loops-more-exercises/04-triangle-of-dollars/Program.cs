using System;
namespace _04TriangleOfDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            for (int i = 1; i <= rows; i++)
            {
                for (int c = 1; c <= i; c++)
                {
                    Console.Write("$" + " ");
                }
                Console.WriteLine();
            }
        }
    }
}