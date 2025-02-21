using System;
namespace _03GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double gamePrice = 0;
            double moneySpent = 0;
            while (budget > 0)
            {
                string command = Console.ReadLine();
                if (command == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${moneySpent:f2}. Remaining: ${budget:f2}");
                    break;
                }
                string gameName = command;
                if (budget == 0)
                {
                    Console.WriteLine($"Bought {gameName}");
                    Console.WriteLine("Out of money!");
                    break;
                }
                if (gameName == "OutFall 4")
                {
                    if (budget > 39.99)
                    {
                        Console.WriteLine($"Bought {gameName}");
                        budget -= 39.99;
                        moneySpent += 39.99;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "CS: OG")
                {
                    if (budget > 15.99)
                    {
                        Console.WriteLine($"Bought {gameName}");
                        budget -= 15.99;
                        moneySpent += 15.99;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "Zplinter Zell")
                {
                    if (budget > 39.99)
                    {
                        Console.WriteLine($"Bought {gameName}");
                        budget -= 19.99;
                        moneySpent += 19.99;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "Honored 2")
                {
                    if (budget > 59.99)
                    {
                        Console.WriteLine($"Bought {gameName}");
                        budget -= 59.99;
                        moneySpent += 59.99;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "RoverWatch")
                {
                    if (budget > 29.99)
                    {
                        Console.WriteLine($"Bought {gameName}");
                        budget -= 29.99;
                        moneySpent += 29.99;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "RoverWatch Origins Edition")
                {
                    if (budget > 39.99)
                    {
                        Console.WriteLine($"Bought {gameName}");
                        budget -= 39.99;
                        moneySpent += 39.99;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }
        }
    }
}