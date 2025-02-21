namespace NeedForSpeed.Models
{
    public class SportCar : Car
    {
        public const double SportCarDefaultFuelConsumption = 10;

        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption
            => SportCarDefaultFuelConsumption;
    }
}
