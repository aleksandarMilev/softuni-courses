﻿namespace PokemonTrainer
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;


        public Pokemon(string name, string element, int health)
        {
            Name = name;
            Element = element;
            Health = health;
        }

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
