namespace SpeedRacing
{
    public class Car
    {
        public string model;
        public double fuelAmount;
        public double fuelConsumptionPerKilometer;
        public double travelledDistance;


        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }


        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }


        public void Drive(double distance)
        {
            if (this.FuelConsumptionPerKilometer * distance <= this.FuelAmount)
            {
                this.FuelAmount -= this.FuelConsumptionPerKilometer * distance;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
