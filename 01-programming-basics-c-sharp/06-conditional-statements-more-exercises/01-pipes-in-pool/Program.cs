using System;
namespace _01._Pipes_In_Pool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int poolVolume = int.Parse(Console.ReadLine());
            int firstPipeDebitPerHour = int.Parse(Console.ReadLine());
            int secondPipeDebitPerHour = int.Parse(Console.ReadLine());
            double hoursWorkerLeft = double.Parse(Console.ReadLine());

            double firstPipeDebit = firstPipeDebitPerHour * hoursWorkerLeft;
            double secondPipeDebit = secondPipeDebitPerHour * hoursWorkerLeft;
            double totalWaterIncome = firstPipeDebit + secondPipeDebit;

            double firstPipePercent = firstPipeDebit / totalWaterIncome * 100;
            double secondPipePercent = secondPipeDebit / totalWaterIncome * 100;
            double totalWaterPercent = totalWaterIncome / poolVolume * 100;
            if (poolVolume >= totalWaterIncome)
            {
                Console.WriteLine($"The pool is {totalWaterPercent:f2}% full. Pipe 1: {firstPipePercent:f2}%. Pipe 2: {secondPipePercent:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {hoursWorkerLeft} hours the pool overflows with {totalWaterIncome - poolVolume} liters.");
            }

        }
    }
}