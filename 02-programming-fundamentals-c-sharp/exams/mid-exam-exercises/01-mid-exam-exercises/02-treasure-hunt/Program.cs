using System;
using System.Collections.Generic;
namespace _02TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> initialChest = Console.ReadLine()
                .Split("|")
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                List<string> arguments = command.Split().ToList();
                switch (arguments[0])
                {
                    case "Loot":
                        LootItems(initialChest, arguments);
                        break;
                    case "Drop":
                        DropIndex(initialChest, arguments);
                        break;
                    case "Steal":
                        PrintStealItems(initialChest, arguments);
                        break;

                }
            }

            int sum = 0;
            for (int i = 0; i < initialChest.Count; i++)
            {
                string currentitem = initialChest[i];
                sum += currentitem.Length;
            }

            if (initialChest.Count <= 0)
            {
                Console.WriteLine("Failed treasure hunt.");
                return;
            }

            double averageGain = (double)sum / initialChest.Count;
            Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
        }

        static void LootItems(List<string> initialChest, List<string> arguments)
        {
            List<string> lootItmes = new List<string>();
            arguments.RemoveAt(0);
            lootItmes.InsertRange(0, arguments);
            for (int i = 0; i < lootItmes.Count; i++)
            {
                if (!initialChest.Contains(lootItmes[i]))
                {
                    initialChest.Insert(0, lootItmes[i]);
                }
            }
        }

        static void DropIndex(List<string> initialChest, List<string> arguments)
        {
            int indexRemove = int.Parse(arguments[1]);
            if (!IsIndexValid(initialChest, indexRemove))
            {
                return;
            }
            string itemRemoved = initialChest[indexRemove];
            initialChest.RemoveAt(indexRemove);
            initialChest.Add(itemRemoved);
        }

        static void PrintStealItems(List<string> initialChest, List<string> arguments)
        {
            List<string> itemsStolen = new List<string>();
            int stealCount = int.Parse(arguments[1]);
            if (stealCount > initialChest.Count)
            {
                stealCount = initialChest.Count;
            }
            List<string> itemsToInsert = initialChest.GetRange(initialChest.Count - stealCount, stealCount);
            itemsStolen.InsertRange(0, itemsToInsert);
            initialChest.RemoveRange(initialChest.Count - stealCount, stealCount);
            Console.WriteLine(string.Join(", ", itemsStolen));
        }

        static bool IsIndexValid(List<string> initialChest, int index)
        {
            return index >= 0 && index <= initialChest.Count - 1;
        }
    }
}