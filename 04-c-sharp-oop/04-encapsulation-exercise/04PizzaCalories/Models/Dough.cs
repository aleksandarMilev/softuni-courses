using System;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const int DoughBaseCaloriesPerGram = 2;
        private const int DoughMinWeight = 1;
        private const int DoughMaxWeight = 200;

        private string type;
        private string bakingTechnique;
        private double grams;

        public Dough(string type, string bakingTechnique, double grams)
        {
            Type = type;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string Type
        {
            get => type;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                type = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }
        public double Grams
        {
            get => grams;
            private set
            {
                if (value < DoughMinWeight || value > DoughMaxWeight)
                {
                    throw new ArgumentException($"{nameof(Dough)} weight should be in the range [1..200].");
                }

                grams = value;
            }
        }

        public double GetCalories()
        {
            double flourTypeModifier = 0;
            double bakingTechniqueModifier = 0;

            switch (Type.ToLower())
            {
                case "white":
                    flourTypeModifier = 1.5;
                    break;
                case "wholegrain":
                    flourTypeModifier = 1;
                    break;
            }

            switch (BakingTechnique.ToLower())
            {
                case "crispy":
                    bakingTechniqueModifier = 0.9;
                    break;
                case "chewy":
                    bakingTechniqueModifier = 1.1;
                    break;
                case "homemade":
                    bakingTechniqueModifier = 1;
                    break;
            }

            return (Grams * DoughBaseCaloriesPerGram) * flourTypeModifier * bakingTechniqueModifier;
        }
    }
}
