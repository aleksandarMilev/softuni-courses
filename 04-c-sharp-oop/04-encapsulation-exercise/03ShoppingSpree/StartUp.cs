using ShoppingSpree.Models;
using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICollection<Person> people = new List<Person>();
            ICollection<Product> products = new List<Product>();

            try
            {
                string[] peopleInfo = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (string info in peopleInfo)
                {
                    string[] currentPersonInfo = info.Split("=");
                    string personName = currentPersonInfo[0];
                    decimal money = decimal.Parse(currentPersonInfo[1]);

                    Person person = new(personName, money);
                    people.Add(person);
                }

                string[] productInfo = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (string info in productInfo)
                {
                    string[] currentProductInfo = info.Split("=");
                    string productName = currentProductInfo[0];
                    decimal cost = decimal.Parse(currentProductInfo[1]);

                    Product product = new(productName, cost);
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }


            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] arguments = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = arguments[0];
                string productName = arguments[1];

                Person person = people.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);

                if (person != null && product != null)
                {
                    Console.WriteLine(person.Add(product));
                }
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
