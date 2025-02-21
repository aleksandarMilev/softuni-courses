using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private readonly List<ITeam> models;

        public TeamRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<ITeam> Models
            => models.AsReadOnly();

        public void AddModel(ITeam model)
            => models.Add(model);

        public bool RemoveModel(string name)
        {
            ITeam team = models
               .FirstOrDefault(p => p.Name == name);

            if (team != null)
            {
                models.Remove(team);

                return true;
            }

            return false;
        }

        public bool ExistsModel(string name)
        {
            ITeam team = models
                .FirstOrDefault(t => t.Name == name);

            if (team != null)
            {
                return true;
            }

            return false;
        }

        public ITeam GetModel(string name)
            => models.FirstOrDefault(t => t.Name == name);
    }
}
