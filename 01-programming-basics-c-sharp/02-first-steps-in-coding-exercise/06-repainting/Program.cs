using System;
namespace _06Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sqMetersNylon = int.Parse(Console.ReadLine());
            int litersPaint = int.Parse(Console.ReadLine());
            int litersThinner = int.Parse(Console.ReadLine());
            int hoursForWork = int.Parse(Console.ReadLine());

            double sumNylon = (sqMetersNylon + 2) * 1.5;
            double sumPaint = (litersPaint + litersPaint * 0.1) * 14.5;
            double sumThinner = litersThinner * 5.0;
            double sumBags = 0.4;
            double totalSumMaterials = sumNylon + sumPaint + sumThinner + sumBags;
            double sumWorkers = (totalSumMaterials * 0.3) * hoursForWork;
            double totalSum = totalSumMaterials + sumWorkers;
            Console.WriteLine(totalSum);
        }
    }
}