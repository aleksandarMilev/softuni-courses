using System;
namespace _02TaxCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(">>");
            double totalTax = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] arguments = input[i].Split();
                string carType = arguments[0];
                switch (carType)
                {
                    case "family":
                        int familyYears = int.Parse(arguments[1]);
                        int familyKilometers = int.Parse(arguments[2]);

                        int familyTimesIncrease = familyKilometers / 3_000;

                        double familyTax = familyTimesIncrease * 12 + (50 - familyYears * 5);
                        totalTax += familyTax;
                        Console.WriteLine($"A {carType} car will pay {familyTax:f2} euros in taxes.");
                        break;
                    case "heavyDuty":
                        int heavuDutyYears = int.Parse(arguments[1]);
                        int heavyDutyKilometers = int.Parse(arguments[2]);

                        int heavuDutyTimesIncrease = heavyDutyKilometers / 9_000;

                        double heavyDutyTax = heavuDutyTimesIncrease * 14 + (80 - heavuDutyYears * 8);
                        totalTax += heavyDutyTax;
                        Console.WriteLine($"A {carType} car will pay {heavyDutyTax:f2} euros in taxes.");
                        break;
                    case "sports":
                        int sportsYears = int.Parse(arguments[1]);
                        int sportsKilometers = int.Parse(arguments[2]);

                        int sportsTimesIncrease = sportsKilometers / 2_000;

                        double sportsTax = sportsTimesIncrease * 18 + (100 - sportsYears * 9);
                        totalTax += sportsTax;
                        Console.WriteLine($"A {carType} car will pay {sportsTax:f2} euros in taxes.");
                        break;
                    default:
                        Console.WriteLine("Invalid car type.");
                        break;
                }
            }

            Console.WriteLine($"The National Revenue Agency will collect {totalTax:f2} euros in taxes.");
        }
    }
}