using System;
using System.Collections.Generic;
namespace _09KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());
            string[] bestDNA = Array.Empty<string>();
            int bestSum = 0;
            int bestCount = 0;
            int bestStartIndex = 0;
            int sample = 0;
            int bestSample = 0;

            string command;
            while ((command = Console.ReadLine()) != "Clone them!")
            {
                string[] dna = command.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);
                sample++;
                int count = 0;
                int sum = 0;

                for (int i = dna.Length - 1; i >= 0; i--)
                {
                    if (dna[i] == "1")
                    {
                        count++;
                        sum++;
                        if (count > bestCount || sum > bestSum || bestStartIndex > i)
                        {
                            bestSum = sum;
                            bestCount = count;
                            bestSample = sample;
                            bestStartIndex = i;
                            bestDNA = dna;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDNA));
        }
    }
}
