using System;
using System.Collections.Generic;
namespace _03MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> firstList = ReadIntList();
            List<int> secondList = ReadIntList();
               
            List<int> resultList = new List<int>();

            int itterations = Math.Max(firstList.Count, secondList.Count);

            for (int i = 0; i < itterations; i++)
            {
                if (i < firstList.Count)
                {
                    resultList.Add(firstList[i]);
                }

                if (i < secondList.Count)
                {
                    resultList.Add(secondList[i]);
                }
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
        static List<int> ReadIntList()
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
        }
    }
}