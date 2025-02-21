using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private readonly IRepository<ICar> cars;
        private readonly IRepository<IRacer> racers;
        private readonly IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            ICar car = CreateCar(type, make, model, VIN, horsePower);

            cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);

            if (car is null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            IRacer racer = CreateRacer(type, username, car);

            racers.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            if (racerTwo is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            foreach (IRacer racer in racers
                .Models
                .OrderByDescending(r => r.DrivingExperience)
                .ThenBy(r => r.Username))
            {
                result.AppendLine(racer.ToString());
            }

            return result.ToString().TrimEnd();
        }

        private ICar CreateCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;
            switch (type)
            {
                case "SuperCar":
                    car = new SuperCar(make, model, VIN, horsePower);
                    break;
                case "TunedCar":
                    car = new TunedCar(make, model, VIN, horsePower);
                    break;
            }

            return car;
        }

        private IRacer CreateRacer(string type, string username, ICar car)
        {
            IRacer racer = null;

            switch (type)
            {
                case "ProfessionalRacer":
                    racer = new ProfessionalRacer(username, car);
                    break;
                case "StreetRacer":
                    racer = new StreetRacer(username, car);
                    break;
            }

            return racer;
        }

    }
}
