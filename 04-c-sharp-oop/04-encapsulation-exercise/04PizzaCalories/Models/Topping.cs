using System;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const int ToppingBaseCaloriesPerGram = 2;
        private const int ToppingMinWeight = 1;
        private const int ToppingMaxWeight = 50;

        private string type;
        private double grams;

        public Topping(string type, double grams)
        {
            Type = type;
            Grams = grams;
        }

        public string Type
        {
            get => type;
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }
        public double Grams
        {
            get => grams;
            private set
            {
                if (value < ToppingMinWeight || value > ToppingMaxWeight)
                {
                    throw new ArgumentException($"{nameof(Type)} weight should be in the range [1..50].");
                }

                grams = value;
            }
        }

        public double GetCalories()
        {
            double typeModifier = 0;
            switch (Type.ToLower())
            {
                case "meat":
                    typeModifier = 1.2;
                    break;
                case "veggies":
                    typeModifier = 0.8;
                    break;
                case "cheese":
                    typeModifier = 1.1;
                    break;
                case "sauce":
                    typeModifier = 0.9;
                    break;
            }

            return (Grams * ToppingBaseCaloriesPerGram) * typeModifier;
        }
    }
}
