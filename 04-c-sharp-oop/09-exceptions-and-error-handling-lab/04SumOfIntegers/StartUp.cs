﻿using System;
namespace SumOfIntegers
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split();

            int sum = 0;

            foreach (string element in elements)
            {
                try
                {
                    int currNumber = int.Parse(element);
                    sum += currNumber;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
