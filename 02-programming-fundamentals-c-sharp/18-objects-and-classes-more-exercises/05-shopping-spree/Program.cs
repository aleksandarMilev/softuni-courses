using System;
using System.Collections.Generic;
using System.Linq;
namespace _05ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            List<Product> productList = new List<Product>();

            string[] peopleArr = Console.ReadLine()
                .Split(";");
            foreach (var personInfo in peopleArr)
            {
                string[] data = personInfo.Split("=");
                string personName = data[0];
                double personMoney = double.Parse(data[1]);

                Person person = new Person(personName, personMoney);
                personList.Add(person);
            }

            string[] productArr = Console.ReadLine()
                .Split(new char[] { ';' }
                , StringSplitOptions.
                RemoveEmptyEntries);
            foreach (var prodcutInfo in productArr)
            {
                string[] data = prodcutInfo.Split("=");
                string productName = data[0];
                double productCost = double.Parse(data[1]);

                Product product = new Product(productName, productCost);
                productList.Add(product);
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split();
                string personName = data[0];
                string productName = data[1];

                Person person = personList.Find(n => n.PersonName == personName);
                Product product = productList.Find(c => c.ProductName == productName);

                if (person is null || product is null)
                {
                    continue;
                }

                if (person.Money - product.ProductCost >= 0)
                {
                    person.ProductsBag.Add(product);
                    person.Money -= product.ProductCost;
                    Console.WriteLine($"{person.PersonName} bought {product.ProductName}");
                }
                else
                {
                    Console.WriteLine($"{person.PersonName} can't afford {product.ProductName}");
                }
            }

            List<Person> zeroProducts = personList.Where(p => p.ProductsBag.Count <= 0).ToList();
            if (zeroProducts is not null)
            {
                foreach (Person person in zeroProducts)
                {
                    Console.WriteLine($"{person.PersonName} - Nothing bought");
                    personList.Remove(person);
                }
            }

            personList.ForEach(x => Console.WriteLine(x));
        }
    }

    class Product
    {
        public Product(string productName, double prdouctCost)
        {
            ProductName = productName;
            ProductCost = prdouctCost;
        }
        public string ProductName { get; set; }

        public double ProductCost { get; set; }
    }

    class Person
    {
        public Person(string personName, double money)
        {
            PersonName = personName;
            Money = money;
            ProductsBag = new List<Product>();
        }
        public string PersonName { get; set; }

        public double Money { get; set; }

        public List<Product> ProductsBag { get; set; }

        public override string ToString()
        {
            return $"{PersonName} - {PrintPersonBag(ProductsBag)}";
        }

        private string PrintPersonBag(List <Product> list)
        {
            return string.Join(", ", list.Select(n => n.ProductName));
        }
    }
}