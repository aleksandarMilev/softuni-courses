using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly List<IRobot> robots;

        public RobotRepository()
        {
            robots = new();
        }

        public void AddNew(IRobot model)
            => robots.Add(model);

        public IRobot FindByStandard(int interfaceStandard)
            => robots.FirstOrDefault(r => r.InterfaceStandards.Contains(interfaceStandard));

        public IReadOnlyCollection<IRobot> Models()
            => robots.AsReadOnly();

        public bool RemoveByName(string typeName)
            => robots.Remove(robots.FirstOrDefault(r => r.GetType().Name == typeName));
    }
}
