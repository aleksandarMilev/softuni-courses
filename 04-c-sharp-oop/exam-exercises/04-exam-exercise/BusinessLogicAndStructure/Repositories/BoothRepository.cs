﻿using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private readonly List<IBooth> models;

        public BoothRepository()
        {
            models = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models
            => models;

        public void AddModel(IBooth model)
            => models.Add(model);
    }
}
