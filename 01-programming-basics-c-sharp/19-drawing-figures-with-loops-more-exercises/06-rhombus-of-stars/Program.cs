using System;
namespace _06RhombusOfStars
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                PrintSpaces(n - i);
                PrintStars(i);
            }

            for (int i = n - 1; i >= 1; i--)
            {
                PrintSpaces(n - i);
                PrintStars(i);
            }
        }

        static void PrintSpaces(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(" ");
            }
        }

        static void PrintStars(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                Console.Write("*");
                if (i < count)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}