namespace SpeedRacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new();
            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);

                cars.Add(new(model, fuelAmount, fuelConsumptionFor1km));
            }

            string command;
            while ((command = Console.ReadLine()).TrimEnd() != "End")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = arguments[1];
                double distance = double.Parse(arguments[2]);

                Car car = cars.Find(n => n.Model == carModel);
                car.Drive(distance);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}