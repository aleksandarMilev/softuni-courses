using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private readonly List<IStudent> models;

        public StudentRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<IStudent> Models
            => models.AsReadOnly();

        public void AddModel(IStudent model)
            => models.Add(model);

        public IStudent FindById(int id)
            => models.FirstOrDefault(s => s.Id == id);

        public IStudent FindByName(string name)
        {
            string[] studentFullName = name.Split();

            return models.FirstOrDefault(s => s.FirstName == studentFullName[0] && s.LastName == studentFullName[1]);
        }
    }
}
