using System;
namespace _07EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool areEqual = false;
            int sum = 0;
            int[] arr1 = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse) 
                .ToArray();

            int[] arr2 = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    areEqual = false;
                    break;
                }
                else
                {
                    areEqual = true;
                    sum += arr1[i];
                }
            }

            if (areEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}