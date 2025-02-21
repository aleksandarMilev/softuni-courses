namespace VehiclesExtension.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }
        string Drive(double distance, bool isConsumptionIncreased = true);
        void Refuel(double amount);
    }
}
