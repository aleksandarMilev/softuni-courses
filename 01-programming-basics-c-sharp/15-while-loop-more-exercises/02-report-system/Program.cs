using System;
namespace _02._Report_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double targetSum = double.Parse(Console.ReadLine());
            int loop = 0;
            double totalSum = 0;
            bool isOver = false;
            double cashTotal = 0;
            double cardTotal = 0;
            int cashLoop = 0;
            int cardLoop = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine("Failed to collect required money for charity.");
                    break;
                }
                double inputPrice = double.Parse(input);
                loop++;
                if (loop % 2 != 0)
                {
                    if (inputPrice > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                        continue;
                    }
                    Console.WriteLine("Product sold!");
                    cashTotal += inputPrice;
                    cashLoop++;
                    totalSum += inputPrice;
                    if (totalSum >= targetSum)
                    {
                        isOver = true;
                        break;
                    }
                }
                else
                {
                    if (inputPrice < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                        continue;
                    }
                    Console.WriteLine("Product sold!");
                    cardTotal += inputPrice;
                    cardLoop++;
                    totalSum += inputPrice;
                    if (totalSum >= targetSum)
                    {
                        isOver = true;
                        break;
                    }
                }
            }
            double cashAverage = cashTotal / cashLoop;
            double cardAverage = cardTotal / cardLoop;
            if (isOver)
            {
                Console.WriteLine($"Average CS: {cashTotal / (double)cashLoop:f2}");
                Console.WriteLine($"Average CC: {cardTotal / (double)cardLoop:f2}");
            }
        }
    }
}