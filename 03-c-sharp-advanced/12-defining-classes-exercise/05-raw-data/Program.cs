namespace RawData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new();

            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = arguments[0];

                int engineSpeed = int.Parse(arguments[1]);
                int enginePower = int.Parse(arguments[2]);
                Engine engine = new(engineSpeed, enginePower);

                int cargoWeight = int.Parse(arguments[3]);
                string cargoType = arguments[4];
                Cargo cargo = new(cargoType, cargoWeight);

                double tire1Pressure = double.Parse(arguments[5]);
                int tire1Age = int.Parse(arguments[6]);

                double tire2Pressure = double.Parse(arguments[7]);
                int tire2Age = int.Parse(arguments[8]);

                double tire3Pressure = double.Parse(arguments[9]);
                int tire3Age = int.Parse(arguments[10]);

                double tire4Pressure = double.Parse(arguments[11]);
                int tire4Age = int.Parse(arguments[12]);

                Tire[] tires = new Tire[4];
                {
                    tires[0] = new(tire1Age, tire1Pressure);
                    tires[1] = new(tire2Age, tire2Pressure);
                    tires[2] = new(tire3Age, tire3Pressure);
                    tires[3] = new(tire4Age, tire4Pressure);
                }

                Car car = new(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine().TrimEnd();
            switch (command)
            {
                case "fragile":
                    foreach (Car car in cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(p => p.Pressure < 1)))
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;
                case "flammable":
                    foreach (Car car in cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250))
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}