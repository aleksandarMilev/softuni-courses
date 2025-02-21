using System;
using System.Collections.Generic;
namespace _03Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] arguments = command.Split(" - ");
                switch (arguments[0])
                {
                    case "Collect":
                        string itemCollect = arguments[1];

                        if (!journal.Contains(itemCollect))
                        {
                            journal.Add(itemCollect);
                        }

                        break;
                    case "Drop":
                        string itemDrop = arguments[1];

                        if (journal.Contains(itemDrop))
                        {
                            journal.Remove(itemDrop);
                        }

                        break;
                    case "Combine Items":
                        string[] collectItemsArr = arguments[1].Split(":");
                        string oldItem = collectItemsArr[0];
                        string newItem = collectItemsArr[1];

                        if (journal.Contains(oldItem))
                        {
                            int oldItemIndex = journal.IndexOf(oldItem);
                            journal.Insert(oldItemIndex + 1, newItem);
                        }

                        break;
                    case "Renew":
                        string itemRenew = arguments[1];

                        if (journal.Contains(itemRenew))
                        {
                            journal.Remove(itemRenew);
                            journal.Add(itemRenew);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", journal));
        }
    }
}