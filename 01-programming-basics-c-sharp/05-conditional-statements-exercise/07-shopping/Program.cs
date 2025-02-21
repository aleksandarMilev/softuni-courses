using System;
namespace _07Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int graphicCards = int.Parse(Console.ReadLine());
            int procesors = int.Parse(Console.ReadLine());
            int ramMemory = int.Parse(Console.ReadLine());

            double cardsCost = graphicCards * 250;
            double procesorsCost = cardsCost * 0.35;
            double procesorPrice = procesorsCost * procesors;
            double ramCost = cardsCost * 0.10;
            double ramPrice = ramCost * ramMemory;
            double sumNeed = cardsCost + procesorPrice + ramPrice;
            if (graphicCards > procesors)
            {
                sumNeed = sumNeed - (sumNeed * 0.15);
            }
            if (budget >= sumNeed)
            {
                Console.WriteLine($"You have {budget - sumNeed:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {sumNeed - budget:f2} leva more!");
            }
        }
    }
}