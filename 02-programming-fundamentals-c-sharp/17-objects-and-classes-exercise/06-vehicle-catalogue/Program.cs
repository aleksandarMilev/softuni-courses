using System;
using System.Collections.Generic;
namespace _06VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehList = new List<Vehicle>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split();
                string type = commandArr[0];
                string model = commandArr[1];
                string color = commandArr[2];
                int horsePower = int.Parse(commandArr[3]);

                type = char.ToUpper(type[0]) + type.Substring(1);

                Vehicle vehicle = new Vehicle();
                vehicle.Type = type;
                vehicle.Model = model;
                vehicle.Color = color;
                vehicle.HorsePower = horsePower;

                vehList.Add(vehicle);
            }

            string input;
            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle vehicle = vehList.Find(v => v.Model == input);

                Console.WriteLine($"Type: {vehicle.Type}");
                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Color: {vehicle.Color}");
                Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
            }

            double carsAv = CalculateAverage(vehList, "Car");
            double trucksAv = CalculateAverage(vehList, "Truck");

            Console.WriteLine($"Cars have average horsepower of: {carsAv:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAv:f2}.");
        }

        static double CalculateAverage(List<Vehicle> vehicles, string model)
        {
            var vehOfType = vehicles.Where(v => v.Type == model);
            if (vehOfType.Any())
            {
                return vehOfType.Average(v => v.HorsePower);
            }
            return 0;
        }
    }

    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
}