using System;
namespace _01Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int n = int.Parse(Console.ReadLine());
            int[] train = new int[n];
            for (int i = 0; i < n; i++)
            {
                int wagon = int.Parse(Console.ReadLine());
                train[i] = wagon;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(train[i] + " ");
                sum += train[i];
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}