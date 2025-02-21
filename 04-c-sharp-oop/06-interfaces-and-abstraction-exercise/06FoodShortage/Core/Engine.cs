using FoodShortage.Core.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FoodShortage.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IBuyer> people = new();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IBuyer person;

                if (arguments.Length == 3)
                {
                    person = new Rebel(arguments[0], int.Parse(arguments[1]), arguments[2]);
                }
                else
                {
                    person = new Human(arguments[0], int.Parse(arguments[1]), arguments[2], arguments[3]);
                }

                people.Add(person);
            }

            int totalAmountOfFood = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string name = command;

                people.FirstOrDefault(buyer => buyer.Name == name)?.BuyFood();
            }

            int totalSum = people.Sum(p => p.Food);

            Console.WriteLine(totalSum);
        }
    }
}
