using System;
namespace _07NxNMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintNxNMatrix(n);
        }

        private static void PrintNxNMatrix(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }
    }
}