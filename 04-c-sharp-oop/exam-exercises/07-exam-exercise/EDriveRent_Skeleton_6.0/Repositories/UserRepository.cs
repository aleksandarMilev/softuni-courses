using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        public readonly List<IUser> getAll;

        public UserRepository()
        {
            getAll = new();
        }

        public void AddModel(IUser model)
            => getAll.Add(model);

        public IUser FindById(string identifier)
            => getAll.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);

        public IReadOnlyCollection<IUser> GetAll()
            => getAll.AsReadOnly();

        public bool RemoveById(string identifier)
        {
            IUser user = getAll.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);

            if (user != null)
            {
                getAll.Remove(user);

                return true;
            }

            return false;
        }
    }
}
