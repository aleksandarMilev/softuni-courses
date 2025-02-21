using System;
using System.Collections.Generic;
namespace _01UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new();
            int namesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < namesCount; i++)
            {
                names.Add(Console.ReadLine());
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}