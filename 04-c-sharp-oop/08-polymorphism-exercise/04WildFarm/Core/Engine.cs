using System;
using System.Collections.Generic;
using WildFarm.Core.Interfaces;
using WildFarm.Factories.interfaces;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Food.Interfaces;
namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private IFoodFactory foodFactory;
        private IAnimalFactory animalFactory;
        private ICollection<IAnimal> animals;

        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory)
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
            animals = new List<IAnimal>();
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string[] foodInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);

                try
                {
                    IAnimal animal = animalFactory.Create(animalInfo);
                    Console.WriteLine(animal.ProduceSound()); 
                    animals.Add(animal);

                    IFood food = foodFactory.Create(foodType, foodQuantity);
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
