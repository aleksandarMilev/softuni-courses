﻿using System;
namespace SquareRoot
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            try
			{
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(number), "Invalid number.");
                }

                Console.WriteLine(Math.Sqrt(number));
			}
			catch (ArgumentOutOfRangeException ex)
			{
                Console.WriteLine("Invalid number.");
            }
			finally
			{
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
