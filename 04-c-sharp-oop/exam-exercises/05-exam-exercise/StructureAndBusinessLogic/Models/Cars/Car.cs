﻿using CarRacing.Models.Cars.Contracts;
using System;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        protected Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            VIN = vin;
            HorsePower = horsePower;

            if (fuelAvailable < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarFuelAvailable);
            }
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get => make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }

                make = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }

                model = value;
            }
        }

        public string VIN
        {
            get => vin;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVINNameNull);
                }
                else if (value.Length != 17)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVINLength);
                }

                vin = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }

                horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => fuelAvailable;
            private set
            {
                fuelAvailable = Math.Max(value, 0);
            }
        }

        public double FuelConsumptionPerRace
        {
            get => fuelConsumptionPerRace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }

                fuelConsumptionPerRace = value;
            }
        }

        public virtual void Drive()
            => FuelAvailable -= FuelConsumptionPerRace;
    }
}
