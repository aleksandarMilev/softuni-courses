using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge.Core.Contracts
{
    public class Controller : IController
    {
        private IRepository<IFish> fish;
        private IRepository<IDiver> divers;

        public Controller()
        {
            fish = new FishRepository();
            divers = new DiverRepository();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != "FreeDiver" && diverType != "ScubaDiver")
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (divers.Models.Any(d => d.Name == diverName))
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, divers.GetType().Name);
            }

            IDiver diver = null;

            if (diverType == "FreeDiver")
            {
                diver = new FreeDiver(diverName);
            }
            else if (diverType == "ScubaDiver")
            {
                diver = new ScubaDiver(diverName);
            }

            divers.AddModel(diver);

            return string.Format(OutputMessages.DiverRegistered, diverName, divers.GetType().Name);
        }
        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != "ReefFish" && fishType != "DeepSeaFish" && fishType != "PredatoryFish")
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (fish.Models.Any(f => f.Name == fishName))
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, fish.GetType().Name);
            }

            IFish currentFish = null;

            if (fishType == "ReefFish")
            {
                currentFish = new ReefFish(fishName, points);
            }
            else if (fishType == "PredatoryFish")
            {
                currentFish = new PredatoryFish(fishName, points);
            }
            else if (fishType == "DeepSeaFish")
            {
                currentFish = new DeepSeaFish(fishName, points);
            }

            fish.AddModel(currentFish);

            return string.Format(OutputMessages.FishCreated, fishName);
        }
        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (!divers.Models.Any(d => d.Name == diverName))
            {
                return string.Format(OutputMessages.DiverNotFound, divers.GetType().Name, diverName);
            }

            if (!fish.Models.Any(f => f.Name == fishName))
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            IDiver diver = divers.GetModel(diverName);

            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            IFish currentFish = fish.GetModel(fishName);

            if (diver.OxygenLevel < currentFish.TimeToCatch)
            {
                diver.Miss(currentFish.TimeToCatch);

                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == currentFish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(currentFish);

                    return string.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
                }
                else
                {
                    diver.Miss(currentFish.TimeToCatch);

                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }
            else
            {
                diver.Hit(currentFish);

                return string.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
            }
        }
        public string HealthRecovery()
        {
            int counter = 0;

            foreach (Diver diver in divers.Models.Where(d => d.HasHealthIssues == true))
            {
                diver.HasHealthIssues = false;

                diver.RenewOxy();

                counter++;
            }

            return string.Format(OutputMessages.DiversRecovered, counter);
        }
        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);

            StringBuilder result = new();

            result.AppendLine(diver.ToString());
            result.AppendLine("Catch Report:");

            foreach (string fishName in diver.Catch)
            {
                IFish currFish = fish.Models.FirstOrDefault(f => f.Name == fishName);

                result.AppendLine(currFish.ToString());
            }

            return result.ToString().TrimEnd();
        }
        public string CompetitionStatistics()
        {
            StringBuilder result = new();

            result.AppendLine("**Nautical-Catch-Challenge**");

            List<IDiver> diversWithoutIssues = divers
                .Models
                .Where(d => d.HasHealthIssues == false)
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name)
                .ToList();

            foreach (Diver diver in diversWithoutIssues)
            {
                result.AppendLine(diver.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
