using System;
namespace _09SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int totalSpice = 0;
            int days = 0;
            while (startingYield >= 100)
            {
                totalSpice += startingYield;
                totalSpice -= 26;
                startingYield -= 10; 
                days++;
            }
            if (totalSpice >= 26)
            {
                totalSpice -= 26;
            }
            else
            {
                totalSpice = 0;
            }
            Console.WriteLine(days);
            Console.WriteLine(totalSpice);
        }
    }
}