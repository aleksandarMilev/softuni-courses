﻿using Handball.Models.Contracts;
using System;
using Handball.Utilities.Messages;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;

        protected Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }

                name = value;
            }
        }
        public double Rating { get; set; }
        public string Team { get; private set; }

        public void JoinTeam(string name) => Team = name;
        public abstract void IncreaseRating();
        public abstract void DecreaseRating();

        public override string ToString()
            => $"{GetType().Name}: {Name}{Environment.NewLine}--Rating: {Rating}";
    }
}
