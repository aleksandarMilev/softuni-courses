namespace NeedForSpeed.Models
{
    public class RaceMotorcycle : Motorcycle
    {
        public const double RaceMotorcycleDefaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption
            => RaceMotorcycleDefaultFuelConsumption;
    }
}
