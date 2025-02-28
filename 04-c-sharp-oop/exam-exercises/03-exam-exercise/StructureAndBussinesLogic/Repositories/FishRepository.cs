﻿using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private readonly List<IFish> models;

        public FishRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<IFish> Models
            => models.AsReadOnly();

        public void AddModel(IFish model)
            => models.Add(model);

        public IFish GetModel(string name)
            => models.FirstOrDefault(m => m.Name == name);
    }
}
