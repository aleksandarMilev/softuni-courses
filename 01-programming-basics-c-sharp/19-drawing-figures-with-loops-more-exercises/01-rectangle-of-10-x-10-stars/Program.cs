﻿using System;
namespace _01RectangleOf10X10Stars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
}