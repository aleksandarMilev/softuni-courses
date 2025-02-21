namespace NeedForSpeed.Models
{
    public class Vehicle
    {
        public const double VehicleDefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }


        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        public virtual double FuelConsumption
            => VehicleDefaultFuelConsumption;

        public virtual void Drive(double kilometers)
            => Fuel -= kilometers * FuelConsumption;
    }
}
