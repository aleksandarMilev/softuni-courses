namespace CarSalesman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Engine> engines = new();
            List<Car> cars = new();

            int enginesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                int displacement = -1;
                string efficiency = "n/a";

                if (engineInfo.Length > 2)
                {
                    int tryDisplacement;
                    bool isDigit = int.TryParse(engineInfo[2], out tryDisplacement);

                    if (isDigit)
                    {
                        displacement = tryDisplacement;
                        if (engineInfo.Length > 3)
                        {
                            efficiency = engineInfo[3];
                        }
                    }
                    else
                    {
                        efficiency = engineInfo[2];
                        if (engineInfo.Length > 3)
                        {
                            displacement = int.Parse(engineInfo[3]);
                        }
                    }
                }

                Engine engine = new(model, power, displacement, efficiency);
                engines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                Engine engine = engines.Find(e => e.Model == carInfo[1]);
                int weight = -1;
                string color = "n/a";

                if (carInfo.Length > 2)
                {
                    int tryWeight;
                    bool isDigit = int.TryParse(carInfo[2], out tryWeight);

                    if (isDigit)
                    {
                        weight = tryWeight;
                        if (carInfo.Length > 3)
                        {
                            color = carInfo[3];
                        }
                    }
                    else
                    {
                        color = carInfo[2];
                        if (carInfo.Length > 3)
                        {
                            weight = int.Parse(carInfo[3]);
                        }
                    }
                }

                Car car = new(model, engine, weight, color);
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                string output = car.PrintCar();
                Console.Write(output);
            }
        }
    }
}