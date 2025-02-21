using System;
namespace _05Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal change = decimal.Parse(Console.ReadLine());
            int coinsCount = 0;

            while (change > 0)
            {
                if (change >= 2m)
                {
                    change -= 2m;
                }
                else if (change >= 1m)
                {
                    change -= 1m;
                }
                else if (change >= 0.5m)
                {
                    change -= 0.5m;
                }
                else if (change >= 0.2m)
                {
                    change -= 0.2m;
                }
                else if (change >= 0.1m)
                {
                    change -= 0.1m;
                }
                else if (change >= 0.05m)
                {
                    change -= 0.05m;
                }
                else if (change >= 0.02m)
                {
                    change -= 0.02m;
                }
                else
                {
                    change -= 0.01m;
                }
                coinsCount++;
            }
            Console.WriteLine(coinsCount);
        }
    }
}