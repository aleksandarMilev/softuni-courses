using VehiclesExtension.Models;
namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double BusConsumptionIncrease = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, BusConsumptionIncrease)
        {
        }
    }
}
