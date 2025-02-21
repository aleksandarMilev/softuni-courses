using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private readonly List<IPeak> all;

        public PeakRepository()
        {
            all = new();
        }

        public IReadOnlyCollection<IPeak> All => all.AsReadOnly();

        public void Add(IPeak model)
            => all.Add(model);

        public IPeak Get(string name)
            => all.FirstOrDefault(p => p.Name == name);
    }
}
