using System;
using System.Collections.Generic;
namespace _07AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] stringArrays = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);

            List<string> swapList = GetSwapList(stringArrays);
            Console.WriteLine(string.Join(" ", swapList));
        }

        static List<string> GetSwapList(string[] stringArrays)
        {
            List<string> result = new List<string>();

            for (int i = stringArrays.Length - 1; i >= 0; i--)
            {
                string sequence = stringArrays[i];
                string[] array = sequence.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                result.AddRange(array);
            }
            return result;
        }
    }
}