using System;
using System.Collections.Generic;
using System.Linq;
namespace _04EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbersMap = new();

            for (int i = 0; i < numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbersMap.ContainsKey(number))
                {
                    numbersMap.Add(number, 0);
                }

                numbersMap[number]++;
            }

            Console.WriteLine(numbersMap.Single(x => x.Value % 2 == 0).Key);
        }
    }
}