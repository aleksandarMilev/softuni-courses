using System;
using System.Collections.Generic;
namespace _06StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxList = new List<Box>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();
                string serialNumber = arguments[0];
                string itemName = arguments[1];
                int itemQuantity = int.Parse(arguments[2]);
                decimal itemPrice = decimal.Parse(arguments[3]);

                Item item = new Item();
                item.Name = itemName;
                item.Price = itemPrice;

                Box box = new Box();
                box.SerialNumber = serialNumber;
                box.Item = item;
                box.Quantity = itemQuantity;
                box.PriceForBox = itemQuantity * itemPrice;

                boxList.Add(box);
            }

            var orderedBoxes = boxList.OrderByDescending(box => box.PriceForBox);

            foreach (Box box in orderedBoxes)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f2}");
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public class Box
    {
        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal PriceForBox { get; set; }

    }
}