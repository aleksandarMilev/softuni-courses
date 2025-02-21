using System;
using System.Linq;
using System.Collections.Generic;
namespace _07VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split("/");
                string type = arguments[0];
                string brand = arguments[1];
                string model = arguments[2];
                int horsePowerOrWeight = int.Parse(arguments[3]);

                switch (type)
                {
                    case "Car":
                        Car car = new Car();
                        car.Brand = brand;
                        car.Model = model;
                        car.HorsePower = horsePowerOrWeight;

                        catalog.CarList.Add(car);
                        break;
                    case "Truck":
                        Truck truck = new Truck();
                        truck.Brand = brand;
                        truck.Model = model;
                        truck.Weight = horsePowerOrWeight;

                        catalog.TruckList.Add(truck);
                        break;
                    default:
                        break;
                }
            }

            var orderedCars = catalog.CarList.OrderBy(car => car.Brand);
            var orderedTrucks = catalog.TruckList.OrderBy(truck => truck.Brand);

            Console.WriteLine("Cars:");
            foreach (Car car in orderedCars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");
            foreach (Truck truck in orderedTrucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }

    public class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }
    }

    public class Catalog
    {
        public List<Truck> TruckList { get; set; } 

        public List<Car> CarList { get; set; }

        public Catalog()
        {
            CarList = new List<Car>();
            TruckList = new List<Truck>();
        }
    }
}