﻿using WildFarm.Factories.interfaces;
using WildFarm.Models.Food;
using WildFarm.Models.Food.Interfaces;
using System;
namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood Create(string type, int quantity)
        {
            switch (type)
            {
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
