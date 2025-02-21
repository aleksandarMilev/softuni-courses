using System;
namespace _05AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalSum = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "NoMoreMoney")
                {
                    Console.WriteLine($"Total: {totalSum:f2}");
                    break;
                }
                double sum = double.Parse(command);
                if (sum < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine($"Total: {totalSum:f2}");
                    break;
                }
                Console.WriteLine($"Increase: {sum:f2}");

                totalSum += sum;
            }
        }
    }
}