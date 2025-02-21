using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private readonly List<IPlayer> players;

        public Team(string name)
        {
            Name = name;
            PointsEarned = 0;
            players = new();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }

                name = value;
            }
        }
        public int PointsEarned { get; private set; }
        public double OverallRating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }

                double averageRating = players
                    .Select(player => player.Rating)
                    .Average();

                return Math.Round(averageRating, 2);
            }
        }
        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void SignContract(IPlayer player)
            => players.Add(player);

        public void Win()
        {
            PointsEarned += 3;

            foreach (Player player in players)
            {
                player.IncreaseRating();
            }
        }
        public void Draw()
        {
            PointsEarned++;

            Goalkeeper goalkeeper = players.
                FirstOrDefault(p => p.GetType().Name == "Goalkeeper") as Goalkeeper;

            goalkeeper.IncreaseRating();
        }
        public void Lose()
        {
            foreach (Player player in players)
            {
                player.DecreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new();

            result.AppendLine($"Team: {Name} Points: {PointsEarned}");
            result.AppendLine($"--Overall rating: {OverallRating}");

            string[] playersNames = players
                .Select(p => p.Name)
                .ToArray();

            string playersString = players.Any()
                ? $"{string.Join(", ", playersNames)}"
                : "none";

            result.AppendLine($"--Players: {playersString}");

            return result.ToString().TrimEnd();
        }
    }
}
