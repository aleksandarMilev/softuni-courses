﻿using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        private readonly SortedSet<string> residents;

        public BaseCamp()
        {
            residents = new();
        }

        public IReadOnlyCollection<string> Residents => residents;

        public void ArriveAtCamp(string climberName)
            => residents.Add(climberName);

        public void LeaveCamp(string climberName)
            => residents.Remove(climberName);
    }
}
