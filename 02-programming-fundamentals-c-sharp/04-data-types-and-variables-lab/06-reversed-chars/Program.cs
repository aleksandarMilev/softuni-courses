﻿using System;
namespace _06ReversedChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());
            for (int i = thirdChar; i >= firstChar; i--)
            {
                Console.Write(i + " ");
            }
        }
    }
}