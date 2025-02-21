using System;
using WildFarm.Factories.interfaces;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Felines;
namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal Create(string[] arguments)
        {
            string type = arguments[0];
            string name = arguments[1];
            double weight = double.Parse(arguments[2]);

            switch (type)
            {
                case "Owl":
                    double wingSize = double.Parse(arguments[3]);
                    return new Owl(name, weight, wingSize);
                case "Hen":
                    wingSize = double.Parse(arguments[3]);
                    return new Hen(name, weight, wingSize);
                case "Dog":
                    string livingRegion = arguments[3];
                    return new Dog(name, weight, livingRegion);
                case "Mouse":
                    livingRegion = arguments[3];
                    return new Mouse(name, weight, livingRegion);
                case "Tiger":
                    livingRegion = arguments[3];
                    string breed = arguments[4];
                    return new Tiger(name, weight, livingRegion, breed);
                case "Cat":
                    livingRegion = arguments[3];
                    breed = arguments[4];
                    return new Cat(name, weight, livingRegion, breed);
                default:
                    throw new ArgumentException("Invalid animal type!");
            }
        }
    }
}
