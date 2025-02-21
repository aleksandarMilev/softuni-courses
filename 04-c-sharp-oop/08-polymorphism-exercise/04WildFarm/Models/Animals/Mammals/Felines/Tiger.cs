using System;
using System.Collections.Generic;
using WildFarm.Models.Food;
namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightMultiplier
            => TigerWeightMultiplier;

        protected override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type>() { typeof(Meat) };

        public override string ProduceSound()
            => "ROAR!!!";
    }
}
