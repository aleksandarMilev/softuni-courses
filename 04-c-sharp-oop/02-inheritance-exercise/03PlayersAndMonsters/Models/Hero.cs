﻿namespace PlayersAndMonsters.Models
{
    public class Hero
    {
        public Hero(string username, int level)
        {
            Username = username;
            Level = level;
        }

        public string Username { get; set; }
        public int Level { get; set; }

        public override string ToString()
            => $"Type: {GetType().Name} Username: {Username} Level: {Level}";
    }
}
