using System;
using System.Collections.Generic;
using System.Linq;
namespace _03Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string command;
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] input = command.Split();
                string name = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                Product product = new Product(name, price, quantity);
                if (!products.ContainsKey(name))
                {
                    products[name] = product;
                }
                else
                {
                    products[name].AddQuantity(quantity);
                    if (price != products[name].Price)
                    {
                        products[name].SetPrice(price);
                    }
                }
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {product.Value.GetTotalSum():f2}");
            }
        }
    }

    class Product
    {
        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public double GetTotalSum()
        {
            return Price * Quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void SetPrice(double price)
        {
            Price = price;
        }
    }
}