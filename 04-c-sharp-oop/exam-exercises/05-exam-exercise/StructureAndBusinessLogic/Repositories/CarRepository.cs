using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models
            => models.AsReadOnly();

        public void Add(ICar model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            models.Add(model);
        }

        public bool Remove(ICar model)
            => models.Remove(model);

        public ICar FindBy(string vin)
            => models.FirstOrDefault(c => c.VIN == vin);
    }
}
