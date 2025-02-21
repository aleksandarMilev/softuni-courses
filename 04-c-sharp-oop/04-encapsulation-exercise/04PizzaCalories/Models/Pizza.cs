using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private const int PizzaNameMaxLength = 15;
        private const int ToppingsMaxCount = 10;

        private string name;
        private ICollection<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }


        public Dough Dough { get => dough; set => dough = value; }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > PizzaNameMaxLength)
                {
                    throw new ArgumentException($"{nameof(Pizza)} name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }
        public double Calories
            => Dough.GetCalories() + toppings.Sum(t => t.GetCalories());

        public void AddTopping(Topping topping)
        {
            if (toppings.Count > ToppingsMaxCount)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }

        public override string ToString()
            => $"{Name} - {Calories:f2} Calories.";
    }
}
