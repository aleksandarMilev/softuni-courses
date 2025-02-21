using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        public readonly List<IRoute> getAll;

        public RouteRepository()
        {
            getAll = new();
        }

        public void AddModel(IRoute model)
            => getAll.Add(model);

        public IRoute FindById(string identifier)
            => getAll.FirstOrDefault(r => r.RouteId == int.Parse(identifier));

        public IReadOnlyCollection<IRoute> GetAll()
            => getAll.AsReadOnly();

        public bool RemoveById(string identifier)
        {
            IRoute route = getAll.FirstOrDefault(r => r.RouteId == int.Parse(identifier));

            if (route != null)
            {
                getAll.Remove(route);

                return true;
            }

            return false;
        }
    }
}
