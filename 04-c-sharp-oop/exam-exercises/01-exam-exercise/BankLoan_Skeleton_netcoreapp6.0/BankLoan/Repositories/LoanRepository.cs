using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private readonly List<ILoan> models;

        public LoanRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<ILoan> Models
            => models.AsReadOnly();

        public void AddModel(ILoan model)
            => models.Add(model);

        public bool RemoveModel(ILoan model)
            => models.Remove(model);

        public ILoan FirstModel(string name)
            => models.FirstOrDefault(m => m.GetType().Name == name);
    }
}
