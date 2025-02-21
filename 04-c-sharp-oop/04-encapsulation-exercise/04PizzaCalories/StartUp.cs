using PizzaCalories.Models;
using System;

namespace PizzaCalories
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaArguments = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Pizza pizza = new(pizzaArguments[1]);

                string[] doughArguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                string doughType = doughArguments[1];
                string bakingTechnique = doughArguments[2];
                double doughGrams = double.Parse(doughArguments[3]);

                Dough dough = new(doughType, bakingTechnique, doughGrams);
                pizza.Dough = dough;

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingArguments = command
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string toppingName = toppingArguments[1];
                    double toppingGrams = double.Parse(toppingArguments[2]);

                    Topping topping = new(toppingName, toppingGrams);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
