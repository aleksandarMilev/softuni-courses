using System;
using System.Collections.Generic;
namespace _09PokemonDoNotGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int sum = 0;

            while (list.Count > 0)
            {
                int indexRemove = int.Parse(Console.ReadLine());
                int firstNum = list[0];
                int lastNum = list[list.Count - 1];

                if (indexRemove < 0)
                {
                    list.RemoveAt(0);
                    list.Insert(0, lastNum);

                    for (int i = 0; i < list.Count; i++)
                    {
                        AddOrSubtract(list, firstNum, i);
                    }

                    sum += firstNum;
                }
                else if (indexRemove > list.Count - 1)
                {
                    list.RemoveAt(list.Count - 1);
                    list.Insert(list.Count, firstNum);

                    for (int i = 0; i < list.Count; i++)
                    {
                        AddOrSubtract(list, lastNum, i);
                    }

                    sum += lastNum;
                }
                else
                {
                    int element = list[indexRemove];
                    list.RemoveAt(indexRemove);

                    for (int i = 0; i < list.Count; i++)
                    {
                        AddOrSubtract(list, element, i);
                    }

                    sum += element;
                }
            }

            Console.WriteLine(sum);
        }

        private static void AddOrSubtract(List<int> list, int element, int i)
        {
            if (list[i] <= element)
            {
                list[i] += element;
            }
            else
            {
                list[i] -= element;
            }
        }
    }
}