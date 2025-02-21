using System;
namespace _1.Dishwasher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int preparationMl = int.Parse(Console.ReadLine()) * 750;
            int preparationLeft = preparationMl;
            int inputCount = 0;
            int plateCount = 0;
            int potCount = 0;
            int loop = 0;
            int preparationForPlatesMl = 0;
            int preparationForPotsMl = 0;
            bool IsOver = false;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                inputCount = int.Parse(input);
                loop++;
                if (loop % 3 == 0)
                {
                    preparationForPotsMl += inputCount * 15;
                    if (preparationLeft < inputCount * 15)
                    {
                        IsOver = true;
                        Console.WriteLine($"Not enough detergent, {inputCount * 15 - preparationLeft} ml. more necessary!");
                        break;
                    }
                    preparationLeft -= inputCount * 15;
                    potCount += inputCount;
                }
                else
                {
                    preparationForPlatesMl += inputCount * 5;
                    if (preparationLeft < inputCount * 5)
                    {
                        IsOver = true;
                        Console.WriteLine($"Not enough detergent, {inputCount * 5 - preparationLeft} ml. more necessary!");
                        break;
                    }
                    preparationLeft -= inputCount * 5;
                    plateCount += inputCount;
                }
            }
            if (!IsOver)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{plateCount} dishes and {potCount} pots were washed.");
                Console.WriteLine($"Leftover detergent {preparationLeft} ml.");
            }
        }
    }
}
