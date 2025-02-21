namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            List<Tire[]> tires = new();
            List<Engine> engines = new();
            List<Car> cars = new();

            string command;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] tiresInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] tireArr = new Tire[4];
                {
                    tireArr[0] = new Tire(int.Parse(tiresInfo[0]), double.Parse(tiresInfo[1]));
                    tireArr[1] = new Tire(int.Parse(tiresInfo[2]), double.Parse(tiresInfo[3]));
                    tireArr[2] = new Tire(int.Parse(tiresInfo[4]), double.Parse(tiresInfo[5]));
                    tireArr[3] = new Tire(int.Parse(tiresInfo[6]), double.Parse(tiresInfo[7]));
                }

                tires.Add(tireArr);
            }

            string command2;
            while ((command2 = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = command2
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new(int.Parse(engineInfo[0]), double.Parse(engineInfo[1]));
                engines.Add(engine);
            }

            string command3;
            while ((command3 = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = command3
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int endgineIndex = int.Parse(carInfo[5]);
                int tireIndex = int.Parse(carInfo[6]);
                double pressureSum = tires[tireIndex].Sum(x => x.Pressure);

                Car car = new(make, model, year, fuelQuantity, fuelConsumption, engines[endgineIndex], tires[tireIndex], pressureSum);
                cars.Add(car);
            }

            List<Car> specialCars = cars
                .Where(c => c.Year >= 2_017 &&
                c.Engine.HorsePower > 330 &&
                c.PressureSum >= 9 && c.PressureSum <= 10)
                .ToList();

            if (specialCars.Any())
            {
                foreach (Car car in specialCars)
                {
                    car.Drive(20);
                    car.PrintCarInfo();
                }
            }
        }
    }
}