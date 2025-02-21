using System;
namespace _03DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depositedAmount = double.Parse(Console.ReadLine());
            int depositPeriodInMonths = int.Parse(Console.ReadLine());
            double yearlyInterestPercentage = double.Parse(Console.ReadLine());

            double yearlyAccumulatedInterest = depositedAmount * yearlyInterestPercentage / 100;
            double interstForOneMonth = yearlyAccumulatedInterest / 12;
            double totalSum = depositedAmount + depositPeriodInMonths * interstForOneMonth;
            Console.WriteLine(totalSum);
        }
    }
}