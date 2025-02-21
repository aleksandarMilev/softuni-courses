using System;
namespace _04CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int sum = 0;
            int moneyForBirthday = 10;


            for (int currentAge = 1; currentAge <= age; currentAge++)
            {
                if (currentAge % 2 == 0)
                {
                    sum += moneyForBirthday - 1;
                    moneyForBirthday += 10;
                }
                else
                {
                    sum += toyPrice;
                }
            }
            if (sum >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {sum - washingMachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice - sum:f2}");
            }
        }
    }
}