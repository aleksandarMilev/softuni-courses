using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using CarRacing.Enums;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            double racerOneBehaviorMultiplier = racerOne.RacingBehavior == RacingBehavior.strict
                ? 1.2
                : 1.1;

            double racerTwoBehaviorMultiplier = racerTwo.RacingBehavior == RacingBehavior.strict
                ? 1.2
                : 1.1;

            double racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneBehaviorMultiplier;
            double racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoBehaviorMultiplier;

            string winnerName = racerOneChanceOfWinning > racerTwoChanceOfWinning
                ? racerOne.Username
                : racerTwo.Username;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winnerName);
        }
    }
}
