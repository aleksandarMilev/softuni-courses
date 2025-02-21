using System;
using System.Collections.Generic;
using System.Linq;
namespace _04WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split()
                .Where(x => x.Length % 2 == 0)
                .ToList();
            words.ForEach(x => Console.WriteLine(x));
        }
    }
}