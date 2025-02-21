namespace PokemonTrainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new();

            string command;
            while ((command = Console.ReadLine()).TrimEnd() != "Tournament")
            {
                string[] arguments = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = arguments[0];
                string pokemonName = arguments[1];
                string element = arguments[2];
                int health = int.Parse(arguments[3]);

                Pokemon pokemon = new(pokemonName, element, health);

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new(trainerName);
                    trainers.Add(trainerName, trainer);
                }

                trainers[trainerName].Pokemons.Add(pokemon);
            }

            string elementInput;
            while ((elementInput = Console.ReadLine()).TrimEnd() != "End")
            {
                foreach (Trainer trainer in trainers.Values)
                {
                    if (trainer.Pokemons.Any(n => n.Element == elementInput))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(h => h.Health -= 10);
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            Pokemon currPokemon = trainer.Pokemons[i];
                            if (currPokemon.Health <= 0)
                            {
                                trainer.Pokemons.Remove(currPokemon);
                            }
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(b => b.Value.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBadges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}