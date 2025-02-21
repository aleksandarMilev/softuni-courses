using System;
using System.Diagnostics;

namespace _07.Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneySum = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Start")
                {
                    break;
                }
                double coinInput = double.Parse(command);
                if (coinInput == 2)
                {
                    moneySum += 2;
                }
                else if (coinInput == 1)
                {
                    moneySum += 1;
                }
                else if (coinInput == 0.5)
                {
                    moneySum += 0.5;
                }
                else if (coinInput == 0.2)
                {
                    moneySum += 0.2;
                }
                else if (coinInput == 0.1)
                {
                    moneySum += 0.1;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coinInput}");
                }
            }
            while (true)
            {
                string newCommand = Console.ReadLine();
                if (newCommand == "End")
                {
                    Console.WriteLine($"Change: {moneySum:f2}");
                    break;
                }
                string productName = newCommand;
                if (productName == "Nuts")
                {
                    if (moneySum >= 2)
                    {
                        Console.WriteLine($"Purchased {productName.ToLower()}");
                        moneySum -= 2;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (productName == "Water")
                {
                    if (moneySum >= 0.7)
                    {
                        Console.WriteLine($"Purchased {productName.ToLower()}");
                        moneySum -= 0.7;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (productName == "Crisps")
                {
                    if (moneySum >= 1.5)
                    {
                        Console.WriteLine($"Purchased {productName.ToLower()}");
                        moneySum -= 1.5;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (productName == "Soda")
                {
                    if (moneySum >= 0.8)
                    {
                        Console.WriteLine($"Purchased {productName.ToLower()}");
                        moneySum -= 0.8;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (productName == "Coke")
                {
                    if (moneySum >= 1)
                    {
                        Console.WriteLine($"Purchased {productName.ToLower()}");
                        moneySum -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
        }
    }
}