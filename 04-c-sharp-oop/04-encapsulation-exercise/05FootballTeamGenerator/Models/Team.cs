using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new();
        }


        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(Name)} can not be empty.");
                }

                name = value;
            }
        }
        public double Rating
        {
            get
            {
                if (players.Any())
                {
                    return players.Average(x => x.SkillLevel);
                }

                return 0;
            }
        }


        public void Add(Player player) => players.Add(player);
        public void Remove(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                throw new ArgumentException($"{nameof(Player)} {playerName} is not in {Name} team.");
            }

            players.Remove(player);
        }
    }
}
