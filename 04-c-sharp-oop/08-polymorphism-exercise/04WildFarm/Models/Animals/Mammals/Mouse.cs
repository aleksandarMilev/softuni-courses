using System;
using System.Collections.Generic;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double MouseWeightMultiplier = 0.1;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightMultiplier
            => MouseWeightMultiplier;

        protected override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit)}; 

        public override string ProduceSound()
            => "Squeak";
    }
}
