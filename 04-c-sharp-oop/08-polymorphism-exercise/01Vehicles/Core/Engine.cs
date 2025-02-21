using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.Models.Interfaces;
namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private IVehicleFactory vehicleFactory;
        private ICollection<IVehicle> vehicles;

        public Engine(IVehicleFactory vehicleFactory)
        {
            this.vehicleFactory = vehicleFactory;
            vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            IVehicle car = CreateVehicle();
            IVehicle truck = CreateVehicle();

            vehicles.Add(car);
            vehicles.Add(truck);

            int inputCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                try
                {
                    ProcessInput();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (IVehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private IVehicle CreateVehicle()
        {
            string[] arguments = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = arguments[0];
            double fuelQuantity = double.Parse(arguments[1]);
            double fuelConsumption = double.Parse(arguments[2]);

            IVehicle vehicle = vehicleFactory.Create(vehicleType, fuelQuantity, fuelConsumption);
            return vehicle;
        }

        private void ProcessInput()
        {
            string[] arguments = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = arguments[0];
            string vehicleType = arguments[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);
            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle");
            }

            switch (command)
            {
                case "Drive":
                    double distance = double.Parse(arguments[2]);
                    Console.WriteLine(vehicle.Drive(distance));
                    break;
                case "Refuel":
                    double amount = double.Parse(arguments[2]);
                    vehicle.Refuel(amount);
                    break;
                default:
                    break;
            }
        }
    }
}
