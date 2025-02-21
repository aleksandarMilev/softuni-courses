using System;
using System.Collections.Generic;
namespace _03ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToArray();

            int[] warShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToArray();

            int maxHealth = int.Parse(Console.ReadLine());
            double minHealth = (double)maxHealth * 0.2;
            bool isOver = false;

            string command;
            while ((command = Console.ReadLine()) != "Retire")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "Fire":
                        int index = int.Parse(arguments[1]);
                        int damageWarship = int.Parse(arguments[2]);
                        if (IsIndexValid(warShip, index))
                        {
                            warShip[index] -= damageWarship;
                            if (warShip[index] <= 0)
                            {
                                isOver = true;
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                        break;
                    case "Defend":
                        int startIndex = int.Parse(arguments[1]);
                        int endIndex = int.Parse(arguments[2]);
                        int damagePirate = int.Parse(arguments[3]);
                        if (IsIndexRangeValid(pirateShip, startIndex, endIndex))
                        {
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                pirateShip[i] -= damagePirate;
                                if (pirateShip[i] <= 0)
                                {
                                    isOver = true;
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        }
                        break;
                    case "Repair":
                        int indexRepair = int.Parse(arguments[1]);
                        int health = int.Parse(arguments[2]);
                        if (IsIndexValid(pirateShip, indexRepair))
                        {
                            pirateShip[indexRepair] += health;
                            if (pirateShip[indexRepair] > maxHealth)
                            {
                                pirateShip[indexRepair] = maxHealth;
                            }
                        }
                        break;
                    case "Status":
                        int count = 0;
                        for (int i = 0; i < pirateShip.Length; i++)
                        {
                            if (pirateShip[i] < minHealth)
                            {
                                count++;
                            }
                        }
                        Console.WriteLine($"{count} sections need repair.");
                        break;


                }
            }

            if (isOver == false)
            {
                int pirateSum = 0;
                for (int i = 0; i < pirateShip.Length; i++)
                {
                    pirateSum += pirateShip[i];
                }

                int warShipSum = 0;
                for (int i = 0; i < warShip.Length; i++)
                {
                    warShipSum += warShip[i];
                }

                Console.WriteLine($"Pirate ship status: {pirateSum}");
                Console.WriteLine($"Warship status: {warShipSum}");
            }

        }

        static bool IsIndexRangeValid(int[] array, int startIndex, int endIndex)
        {
            return (startIndex >= 0 && startIndex <= array.Length - 1) &&
                (endIndex >= 0 && endIndex <= array.Length - 1);
        }

        static bool IsIndexValid(int[] array, int index)
        {
            return index >= 0 && index <= array.Length - 1;
        }
    }
}