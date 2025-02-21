using System;
using Animals.Models;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            string animalType;
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (animalType)
                    {
                        case "Dog":
                            Dog dog = new(arguments[0], int.Parse(arguments[1]), arguments[2]);
                            PrintAnimal<Dog>(animalType, dog);
                            break;
                        case "Cat":
                            Cat cat = new(arguments[0], int.Parse(arguments[1]), arguments[2]);
                            PrintAnimal<Cat>(animalType, cat);
                            break;
                        case "Frog":
                            Frog frog = new(arguments[0], int.Parse(arguments[1]), arguments[2]);
                            PrintAnimal<Frog>(animalType, frog);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new(arguments[0], int.Parse(arguments[1]));
                            PrintAnimal<Tomcat>(animalType, tomcat);
                            break;
                        case "Kitten":
                            Kitten kitten = new(arguments[0], int.Parse(arguments[1]));
                            PrintAnimal<Kitten>(animalType, kitten);
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private static void PrintAnimal<T>(string animalType, T animal) where T : Animal
        {
            Console.WriteLine(animalType);
            Console.WriteLine(animal);
        }
    }
}
