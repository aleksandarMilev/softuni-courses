using System;
namespace _12TheSongOfTheWheels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int counter = 0;
            bool isFound = false;
            bool isFouthNumFound = false;
            string password = "";

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if (b > a && c > d && a * b + c *d == m)
                            {
                                isFound = true;
                                Console.Write($"{a}{b}{c}{d}" + " ");
                                counter++;
                                if (counter == 4)
                                {
                                    isFouthNumFound = true;
                                    password = ($"{a}{b}{c}{d}".ToString());
                                }
                            }
                        }
                    }
                }
            }
            if (isFouthNumFound)
            {
                Console.WriteLine();
                Console.WriteLine($"Password: {password}");
            }
            else if (!isFound && !isFouthNumFound)
            {
                Console.WriteLine("No!");
            }
            else if (!isFouthNumFound)
            {
                Console.WriteLine();
                Console.WriteLine("No!");
            }
        }
    }
}