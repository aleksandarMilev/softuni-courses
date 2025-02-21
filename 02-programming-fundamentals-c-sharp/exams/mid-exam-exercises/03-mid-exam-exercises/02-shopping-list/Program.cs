using System;
namespace _02ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split("!").ToList();

            string command;
            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] arrCommand = command.Split();
                switch (arrCommand[0])
                {
                    case "Urgent":
                        string itemUrgent = arrCommand[1];

                        if (!list.Contains(itemUrgent))
                        {
                            list.Insert(0, itemUrgent);
                        }
                        break;
                    case "Unnecessary":
                        string itemUnnecessary = arrCommand[1];

                        if (list.Contains(itemUnnecessary))
                        {
                            list.Remove(itemUnnecessary);
                        }
                        break;
                    case "Correct":
                        string oldItem = arrCommand[1];
                        string newItem = arrCommand[2];

                        if (list.Contains(oldItem))
                        {
                            int oldItemIndex = list.IndexOf(oldItem);
                            list.Insert(oldItemIndex, newItem);
                            list.Remove(oldItem);
                        }
                        break;
                    case "Rearrange":
                        string rearrangeItem = arrCommand[1];

                        if (list.Contains(rearrangeItem))
                        {
                            list.Remove(rearrangeItem);
                            list.Add(rearrangeItem);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
