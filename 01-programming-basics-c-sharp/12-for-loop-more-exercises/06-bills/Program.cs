using System;
namespace _06._Bills
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            double totalElectricity = 0;
            int totalWater = 0;
            int totalInternet = 0;
            double totalOthers = 0;

            for (int i = 1; i <= months; i++)
            {
                double electricityBill = double.Parse(Console.ReadLine());
                totalElectricity += electricityBill;
                int waterBill = 20;
                totalWater += waterBill;
                int internetBill = 15;
                totalInternet += internetBill;
                double othersBill = (electricityBill + waterBill + internetBill) * 1.2;
                totalOthers += othersBill;
            }
            Console.WriteLine($"Electricity: {totalElectricity:f2} lv");
            Console.WriteLine($"Water: {totalWater:f2} lv");
            Console.WriteLine($"Internet: {totalInternet:f2} lv");
            Console.WriteLine($"Other: {totalOthers:f2} lv");
            double total = totalElectricity + totalWater + totalInternet + totalOthers;
            double totalAverage = total / months;
            Console.WriteLine($"Average: {totalAverage:f2} lv");
        }
    }
}