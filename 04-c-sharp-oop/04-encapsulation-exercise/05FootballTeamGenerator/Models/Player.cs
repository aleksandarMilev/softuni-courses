using System;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private const int MinStatsValue = 0;
        private const int MaxStatsValue = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(Name)} value can not be empty!");
                }

                name = value;
            }
        }
        public int Endurance
        {
            get => endurance;
            set
            {
                if (!ValidStatValue(value))
                {
                    throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
                }

                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            set
            {
                if (!ValidStatValue(value))
                {
                    throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
                }

                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            set
            {
                if (!ValidStatValue(value))
                {
                    throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
                }

                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            set
            {
                if (!ValidStatValue(value))
                {
                    throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
                }

                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            set
            {
                if (!ValidStatValue(value))
                {
                    throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
                }

                shooting = value;
            }
        }
        public double SkillLevel
            => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

        public bool ValidStatValue(int value)
            => value >= MinStatsValue && value <= MaxStatsValue;
    }
}
