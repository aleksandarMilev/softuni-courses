using System;
namespace _05SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pensCount = int.Parse(Console.ReadLine());
            int markersCount = int.Parse(Console.ReadLine());
            int cleaningAgentInLiters = int.Parse(Console.ReadLine());
            int discountPerecentage = int.Parse(Console.ReadLine());

            double totalSum = 0;
            totalSum = totalSum + pensCount * 5.8;
            totalSum = totalSum + markersCount * 7.2;
            totalSum = totalSum + cleaningAgentInLiters * 1.2;

            double discountedAmount = totalSum * (discountPerecentage / 100.0);
            totalSum = totalSum - discountedAmount;
            Console.WriteLine(totalSum);
        }
    }
}