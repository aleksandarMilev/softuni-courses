using System;
namespace _4._Numbers_devided_by_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i + " ");
                }
            }
        }

    }
}