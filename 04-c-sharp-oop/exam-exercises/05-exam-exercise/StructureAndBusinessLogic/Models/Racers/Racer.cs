using CarRacing.Enums;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private int drivingExperience;
        private ICar car;

        protected Racer(string username, RacingBehavior racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }

                username = value;
            }
        }

        public RacingBehavior RacingBehavior { get; private set; }

        public int DrivingExperience
        {
            get => drivingExperience;
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessages.InvalidRacerDrivingExperience);
                }

                drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => car;
            private set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidRacerCar);
                }

                car = value;
            }
        }

        public virtual void Race()
            => car.Drive();

        public bool IsAvailable()
            => car.FuelAvailable >= car.FuelConsumptionPerRace;

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{GetType().Name}: {Username}");
            result.AppendLine($"--Driving behavior: {RacingBehavior}");
            result.AppendLine($"--Driving experience: {DrivingExperience}");
            result.AppendLine($"--Car: {Car.Make} {Car.Model} ({Car.VIN})");

            return result.ToString().TrimEnd();
        }
    }
}
