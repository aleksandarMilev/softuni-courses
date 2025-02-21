using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Collections.ObjectModel;
using System.Text;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private IRepository<IPeak> peaks;
        private IRepository<IClimber> climbers;
        private IBaseCamp baseCamp;

        private readonly string[] difficultyLevelOptions = { "Extreme", "Hard", "Moderate" };

        public Controller()
        {
            peaks = new PeakRepository();
            climbers = new ClimberRepository();
            baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (peaks.All.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            if (!difficultyLevelOptions.Contains(difficultyLevel))
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, name);
            }

            IPeak peak = new Peak(name, elevation, difficultyLevel);
            peaks.Add(peak);

            return string.Format(OutputMessages.PeakIsAllowed, name, peaks.GetType().Name);
        }
        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (climbers.All.Any(c => c.Name == name))
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, climbers.GetType().Name);
            }

            IClimber climber;

            if (isOxygenUsed)
            {
                climber = new OxygenClimber(name);
            }
            else
            {
                climber = new NaturalClimber(name);
            }

            climbers.Add(climber);

            baseCamp.ArriveAtCamp(name);

            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);

        }
        public string AttackPeak(string climberName, string peakName)
        {
            if (!climbers.All.Any(c => c.Name == climberName))
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            if (!peaks.All.Any(p => p.Name == peakName))
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName ,peakName);
            }

            IClimber climber = climbers.All.First(c => c.Name == climberName);
            IPeak peak = peaks.All.First(c => c.Name == peakName);

            if (climber.GetType().Name == "NaturalClimber" && peak.DifficultyLevel == "Extreme")
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            baseCamp.LeaveCamp(climberName);

            climber.Climb(peak);

            if (climber.Stamina <= 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }

            baseCamp.ArriveAtCamp(climberName);
            return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
            
        }
        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber climber = climbers.All.First(c => c.Name == climberName);

            if (climber.Stamina == 10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }

            climber.Rest(daysToRecover);

            return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
        }
        public string BaseCampReport()
        {
            if (!baseCamp.Residents.Any())
            {
                return "BaseCamp is currently empty.";
            }

            StringBuilder result = new();
            result.AppendLine("BaseCamp residents:");

            foreach (string climberName in baseCamp.Residents)
            {
                IClimber climber = climbers.All.First(c => c.Name == climberName);

                result.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
            }

            return result.ToString().TrimEnd();
        }
        public string OverallStatistics()
        {
            StringBuilder result = new();
            result.AppendLine("***Highway-To-Peak***");

            List<IClimber> climbersSorted = climbers
                .All
                .OrderByDescending(c => c.ConqueredPeaks.Count)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (IClimber climber in climbersSorted)
            {
                result.AppendLine(climber.ToString());

                ICollection<IPeak> currentPeaks = new Collection<IPeak>();

                foreach (string peakName in climber.ConqueredPeaks)
                {
                    IPeak currentPeak = peaks.All.First(p => p.Name == peakName);

                    currentPeaks.Add(currentPeak);
                }

                List<IPeak> currentPeaksSorted = currentPeaks
                    .OrderByDescending(p => p.Elevation)
                    .ToList();

                foreach (IPeak peak in currentPeaksSorted)
                {
                    result.AppendLine(peak.ToString());
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
