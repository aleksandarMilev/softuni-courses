using System;
using Vehicles.Models.Interfaces;
namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double consumptionIncrease;

        public Vehicle(double fuelQuantity, double fuelConsumption, double consumptionIncrease)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.consumptionIncrease = consumptionIncrease;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            double totalConsumption = FuelConsumption + consumptionIncrease;

            if (distance * totalConsumption > FuelQuantity)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= totalConsumption * distance;

            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount)
            => FuelQuantity += amount;

        public override string ToString()
            => $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
