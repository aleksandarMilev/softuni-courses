using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        private readonly List<IClimber> all;

        public ClimberRepository()
        {
            all = new();
        }

        public IReadOnlyCollection<IClimber> All => all.AsReadOnly();

        public void Add(IClimber model)
            => all.Add(model);

        public IClimber Get(string name)
            => all.FirstOrDefault(c => c.Name == name);
    }
}
