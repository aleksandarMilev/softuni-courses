using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private readonly List<IUniversity> models;

        public UniversityRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<IUniversity> Models
            => models.AsReadOnly();

        public void AddModel(IUniversity model)
            => models.Add(model);

        public IUniversity FindById(int id)
            => models.FirstOrDefault(u => u.Id == id);

        public IUniversity FindByName(string name)
            => models.FirstOrDefault(u => u.Name == name);
    }
}
