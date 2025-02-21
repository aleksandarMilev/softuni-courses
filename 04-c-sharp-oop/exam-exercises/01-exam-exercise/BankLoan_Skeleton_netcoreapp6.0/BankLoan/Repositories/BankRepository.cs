using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private readonly List<IBank> models;

        public BankRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<IBank> Models
            => models.AsReadOnly();

        public void AddModel(IBank model)
            => models.Add(model);

        public bool RemoveModel(IBank model)
            => models.Remove(model);

        public IBank FirstModel(string name)
            => models.FirstOrDefault(m => m.Name == name);
    }
}
