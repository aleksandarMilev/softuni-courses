using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core.Contracts
{
    public class Controller : IController
    {
        IRepository<ISupplement> supplements;
        IRepository<IRobot> robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            switch (typeName)
            {
                case nameof(DomesticAssistant):
                    robots.AddNew(new DomesticAssistant(model));
                    break;
                case nameof(IndustrialAssistant):
                    robots.AddNew(new IndustrialAssistant(model));
                    break;
                default:
                    return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            switch (typeName)
            {
                case nameof(SpecializedArm):
                    supplements.AddNew(new SpecializedArm());
                    break;
                case nameof(LaserRadar):
                    supplements.AddNew(new LaserRadar());
                    break;
                default:
                    return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            IEnumerable<IRobot> robotsFilter = robots
                .Models()
                .Where(r => r.InterfaceStandards.Contains(intefaceStandard))
                .OrderByDescending(r => r.BatteryLevel);

            if (!robotsFilter.Any())
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int availablePower = robotsFilter.Sum(r => r.BatteryLevel);

            if (availablePower < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - availablePower);
            }

            int robotsPerfServiceCount = 0;
            foreach (IRobot robot in robotsFilter)
            {
                robotsPerfServiceCount++;

                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);

                    break;
                }

                totalPowerNeeded -= robot.BatteryLevel;

                robot.ExecuteService(robot.BatteryLevel);
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotsPerfServiceCount);
        }

        public string Report()
        {
            StringBuilder result = new();

            IEnumerable<IRobot> orderedRobots = robots
                .Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity);

            foreach (IRobot robot in orderedRobots)
            {
                result.AppendLine(robot.ToString());
            }

            return result.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            IEnumerable<IRobot> filteredRobots = robots
                .Models()
                .Where(r => r.Model == model &&
                r.BatteryLevel < r.BatteryCapacity / 2);

            int fedCount = 0;
            foreach (IRobot robot in filteredRobots)
            {
                robot.Eating(minutes);

                fedCount++;
            }

            return string.Format(OutputMessages.RobotsFed, fedCount);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models()
                .FirstOrDefault(s => s.GetType().Name == supplementTypeName);

            IRobot robot = robots.Models()
                .FirstOrDefault(r => r.Model == model &&
                !r.InterfaceStandards.Contains(supplement.InterfaceStandard));

            if (robot == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            robot.InstallSupplement(supplement);

            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}
