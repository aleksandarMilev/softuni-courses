﻿using WildFarm.Models.Animals.Interfaces;
namespace WildFarm.Models.Animals.Birds
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
            => $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}
