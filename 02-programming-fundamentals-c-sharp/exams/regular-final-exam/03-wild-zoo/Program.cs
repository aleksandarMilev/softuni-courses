namespace _03WildZoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Animal> animals = new();
            Dictionary<string, int> areas = new();

            string command;
            while ((command = Console.ReadLine()) != "EndDay")
            {
                string[] arguments = command.Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[0];
                string name = arguments[1];
                switch (action)
                {
                    case "Add":
                        int foodQuantity = int.Parse(arguments[2]);
                        string area = arguments[3];

                        if (!animals.ContainsKey(name))
                        {
                            animals.Add(name, new(name, 0, area));
                        }

                        animals[name].FoodNeedQuantity += foodQuantity;
                        break;
                    case "Feed":
                        int food = int.Parse(arguments[2]);

                        if (animals.ContainsKey(name))
                        {
                            animals[name].FoodNeedQuantity -= food;
                            if (animals[name].FoodNeedQuantity <= 0)
                            {
                                Console.WriteLine($"{name} was successfully fed");
                                animals.Remove(name);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            if (animals.Any())
            {
                Console.WriteLine("Animals:");
                foreach (var animal in animals)
                {
                    Console.WriteLine($"{animal.Key} -> {animal.Value.FoodNeedQuantity}g");

                    if (!areas.ContainsKey(animal.Value.Area))
                    {
                        areas.Add(animal.Value.Area, 0);
                    }

                    areas[animal.Value.Area]++;
                }
            }

            if (areas.Any())
            {
                Console.WriteLine("Areas with hungry animals:");
                foreach (var area in areas)
                {
                    Console.WriteLine($"{area.Key}: {area.Value}");
                }
            }
        }
    }

    class Animal
    {
        public Animal(string name, int foodNeedQuantity, string area)
        {
            Name = name;
            FoodNeedQuantity = foodNeedQuantity;
            Area = area;
        }

        public string Name { get; set; }
        public int FoodNeedQuantity { get; set; }
        public string Area { get; set; }
    }
}