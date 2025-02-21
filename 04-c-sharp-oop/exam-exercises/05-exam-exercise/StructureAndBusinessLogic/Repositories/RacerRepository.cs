using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models
            => models.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            models.Add(model);
        }

        public bool Remove(IRacer model)
            => models.Remove(model);

        public IRacer FindBy(string username)
            => models.FirstOrDefault(c => c.Username == username);
    }
}
