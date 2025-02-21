using CarRacing.Enums;
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int StreetRacerDrivingExperience = 10;
        private const int StreetRacerDrivingExperienceIncreasePerRace = 5;

        public StreetRacer(string username, ICar car)
            : base(username, RacingBehavior.aggressive, StreetRacerDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();

            DrivingExperience += StreetRacerDrivingExperienceIncreasePerRace;
        }
    }
}
