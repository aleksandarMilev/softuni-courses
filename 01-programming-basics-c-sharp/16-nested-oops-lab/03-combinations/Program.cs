﻿using System;
namespace _03Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int isValidCounter = 0;

            for (int x1 = 0; x1 <= n; x1++)
            {
                for (int x2 = 0; x2 <= n; x2++)
                {
                    for (int x3 = 0; x3 <= n; x3++)
                    {
                        if (x1 + x2 + x3 == n)
                        {
                            isValidCounter++;
                        }
                    }
                }
            }
            Console.WriteLine(isValidCounter);
        }
    }
}