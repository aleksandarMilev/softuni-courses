using System;
using VehiclesExtension.Models.Interfaces;
namespace VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double consumptionIncrease;
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double consumptionIncrease)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.consumptionIncrease = consumptionIncrease;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (TankCapacity < value)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }

        public string Drive(double distance, bool isConsumptionIncreased)
        {
            double totalConsumption = isConsumptionIncreased
                ? FuelConsumption + consumptionIncrease
                : FuelConsumption;
             
            if (distance * totalConsumption > FuelQuantity)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= totalConsumption * distance;

            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount)
        {
            if (FuelQuantity + amount > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
            else if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            FuelQuantity += amount;
        }

        public override string ToString()
            => $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
