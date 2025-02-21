using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private readonly List<ISubject> models;

        public SubjectRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<ISubject> Models
            => models.AsReadOnly();

        public void AddModel(ISubject subject)
            => models.Add(subject);

        public ISubject FindById(int id)
            => models.FirstOrDefault(s => s.Id == id);

        public ISubject FindByName(string name)
            => models.FirstOrDefault(s => s.Name == name);
    }
}
