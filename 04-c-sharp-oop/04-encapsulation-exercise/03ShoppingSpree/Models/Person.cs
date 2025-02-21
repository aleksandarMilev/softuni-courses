using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private ICollection<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(Name)} cannot be empty");
                }

                name = value;
            }
        }
        public decimal Money
        {
            private get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Money)} cannot be negative");
                }

                money = value;
            }
        }

        public string Add(Product product)
        {
            if (Money < product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }
            else
            {
                products.Add(product);
                Money -= product.Cost;

                return $"{Name} bought {product.Name}";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new();

            result.Append($"{Name} - ");
            result.Append(products.Any()
                ? string.Join(", ", products.Select(p => p.Name))
                : "Nothing bought");

            return result.ToString().TrimEnd();
        }
    }
}
