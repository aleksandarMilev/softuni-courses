using CarRacing.Enums;
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int ProfessionalRacerDrivingExperience = 30;
        private const int ProfessionalRacerDrivingExperienceIncreasePerRace = 10;

        public ProfessionalRacer(string username, ICar car)
            : base(username, RacingBehavior.strict, ProfessionalRacerDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();

            DrivingExperience += ProfessionalRacerDrivingExperienceIncreasePerRace;
        }
    }
}
