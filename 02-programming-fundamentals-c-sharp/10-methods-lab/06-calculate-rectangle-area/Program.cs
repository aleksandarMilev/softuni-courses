﻿using System;
namespace _06CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(GetRectangleArea(width, height));
        }

        static double GetRectangleArea(double width, double height)
        {
            return height * width;
        }
    }
}