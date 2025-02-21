using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> supplements;

        public SupplementRepository()
        {
            supplements = new();
        }

        public void AddNew(ISupplement model)
            => supplements.Add(model);

        public ISupplement FindByStandard(int interfaceStandard)
            => supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);

        public IReadOnlyCollection<ISupplement> Models()
            => supplements.AsReadOnly();

        public bool RemoveByName(string typeName)
            => supplements.Remove(supplements.FirstOrDefault(s => s.GetType().Name == typeName));
    }
}
