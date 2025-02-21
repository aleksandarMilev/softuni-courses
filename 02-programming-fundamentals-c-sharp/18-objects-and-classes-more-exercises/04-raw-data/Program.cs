using System;
using System.Collections.Generic;
using System.Linq;
namespace _04RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> list = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();
                string model = arr[0];
                int engineSpeed = int.Parse(arr[1]);
                int enginePower = int.Parse(arr[2]);
                int cargoWeight = int.Parse(arr[3]);
                string cargoType = arr[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo);

                list.Add(car);
            }

            string command = Console.ReadLine();
            switch (command)
            {
                case "fragile":
                    var fragiles = list.Where(t => t.Cargo.CargoType == "fragile" &&
                    t.Cargo.CargoWeight < 1000)
                        .ToList();
                    fragiles.ForEach(x => Console.WriteLine(x.Model));
                    break;
                case "flamable":
                    var flamables = list.Where(t => t.Cargo.CargoType == "flamable" &&
                    t.Engine.EnginePower > 250)
                        .ToList();
                    flamables.ForEach(x => Console.WriteLine(x.Model));
                    break;
                default:
                    break;
            }
        }
    }

    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }

    class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            EngineSpeed = engineSpeed;
            EnginePower = enginePower;
        }
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }

    class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            CargoWeight = cargoWeight;
            CargoType = cargoType;
        }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}