using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        public readonly List<IVehicle> getAll;

        public VehicleRepository()
        {
            getAll = new();
        }

        public void AddModel(IVehicle model)
            => getAll.Add(model);

        public IVehicle FindById(string identifier)
            => getAll.FirstOrDefault(v => v.LicensePlateNumber == identifier);

        public IReadOnlyCollection<IVehicle> GetAll()
            => getAll.AsReadOnly();

        public bool RemoveById(string identifier)
        {
            IVehicle vehicle = getAll.FirstOrDefault(v => v.LicensePlateNumber == identifier);

            if (vehicle != null)
            {
                getAll.Remove(vehicle);

                return true;
            }

            return false;
        }
    }
}
