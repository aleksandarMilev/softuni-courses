namespace _03PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Plant> plants = new();
            int plantsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < plantsCount; i++)
            {
                string[] plantsInfo = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = plantsInfo[0];
                int rarity = int.Parse(plantsInfo[1]);

                if (!plants.ContainsKey(plant))
                {
                    plants.Add(plant, new(plant, rarity));
                }
                else
                {
                    plants[plant].Rarity = rarity;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] arguments = command.Split(new char[] { ' ', ':', '-'}, StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[0];
                string plant = arguments[1];

                if (!plants.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                    continue;
                }

                switch (action)
                {
                    case "Rate":
                        int ratingAdd = int.Parse(arguments[2]);
                        plants[plant].AddRatings.Add(ratingAdd);
                        break;
                    case "Update":
                        int newRarity = int.Parse(arguments[2]);
                        plants[plant].Rarity = newRarity;
                        break;
                    case "Reset":
                        plants[plant].AddRatings.Clear();
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants)
            {
                if (item.Value.AddRatings.Any())
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; Rating: {item.Value.AddRatings.Average():f2}");
                }
                else
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; Rating: 0.00");
                }
            }
        }
    }

    class Plant
    {
        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            AddRatings = new();
        }
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> AddRatings { get; set; }
    }
}