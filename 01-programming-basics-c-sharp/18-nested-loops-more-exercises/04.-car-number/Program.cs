using System;
namespace _04._Car_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                for (int k = start; k <= end; k++)
                {
                    for (int l = start; l <= end; l++)
                    {
                        for (int j = start; j <= end; j++)
                        {
                            if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0)) 
                            {
                                if (i > j)
                                {
                                    if ((k + l) % 2 == 0)
                                    {
                                        Console.Write($"{i}{k}{l}{j}" + " ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}