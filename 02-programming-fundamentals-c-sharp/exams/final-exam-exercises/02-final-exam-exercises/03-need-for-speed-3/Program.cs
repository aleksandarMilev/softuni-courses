namespace _03NeedForSpeed3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new();

            int inputsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsCount; i++)
            {
                string[] carsInfo = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string car = carsInfo[0];
                int mileage = int.Parse(carsInfo[1]);
                int fuel = int.Parse(carsInfo[2]);

                if (!cars.ContainsKey(car))
                {
                    cars.Add(car, new(car, mileage, fuel));
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] arguments = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[0];
                string car = arguments[1];
                switch (action)
                {
                    case "Drive":
                        int distance = int.Parse(arguments[2]);
                        int fuelNeed = int.Parse(arguments[3]);

                        if (cars[car].Fuel < fuelNeed)
                        {
                            Console.WriteLine("Not enough fuelNeed to make that ride");
                        }
                        else
                        {
                            cars[car].Mileage += distance;
                            cars[car].Fuel -= fuelNeed;
                            Console.WriteLine($"{car} driven for {distance} kilometers. {fuelNeed} liters of fuelNeed consumed.");

                            if (cars[car].Mileage >= 100_000)
                            {
                                Console.WriteLine($"Time to sell the {car}!");
                                cars.Remove(car);
                            }
                        }
                        break;
                    case "Refuel":
                        int fuelFill = int.Parse(arguments[2]);

                        if (cars[car].Fuel + fuelFill > 75)
                        {
                            fuelFill = 75 - cars[car].Fuel;
                        }
                        cars[car].Fuel += fuelFill;

                        Console.WriteLine($"{car} refueled with {fuelFill} liters");
                        break;
                    case "Revert":
                        int km = int.Parse(arguments[2]);

                        if (cars[car].Mileage - km < 10_000)
                        {
                            cars[car].Mileage = 10_000;
                        }
                        else
                        {
                            cars[car].Mileage -= km;
                            Console.WriteLine($"{car} mileage decreased by {km} kilometers");
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }

    class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            Name = name;
            Mileage = mileage;
            Fuel = fuel;
        }
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}