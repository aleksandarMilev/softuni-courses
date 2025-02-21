using System;
namespace _02._Letters_Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char skip = char.Parse(Console.ReadLine());
            int loop = 0;

            for (char i = start; i <= end; i++)
            {
                for (char j = start; j <= end; j++)
                {
                    for (char k = start; k <= end; k++)
                    {
                        if (i == skip || j == skip || k == skip)
                        {
                            continue;
                        }
                        else
                        {
                            loop++;
                            Console.Write($"{i}{j}{k} ");
                        }
                    }
                }
            }
            Console.WriteLine(loop);
        }
    }
}