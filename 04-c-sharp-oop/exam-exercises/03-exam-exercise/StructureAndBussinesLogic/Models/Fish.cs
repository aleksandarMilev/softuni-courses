﻿using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        private string name;
        private double points;

        protected Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            TimeToCatch = timeToCatch;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }

                name = value;
            }
        }
        public double Points
        {
            get => points;
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.PointsNotInRange);
                }

                points = value;
            }
        }
        public int TimeToCatch { get; private set; }

        public override string ToString()
            => $"{GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
    }
}
