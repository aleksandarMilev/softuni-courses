using System;
using System.Collections.Generic;
using System.Linq;
namespace _03SpeedRacing
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
                double fuelAmount = double.Parse(arr[1]);
                double fuelConsPerKm = double.Parse(arr[2]);

                Car car = new Car();
                car.Model = model;
                car.FuelAmount = fuelAmount;
                car.FuelConsPerKm = fuelConsPerKm;

                list.Add(car);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arr2 = command.Split();
                string carModel = arr2[1];
                double amountOfKm = double.Parse(arr2[2]);

                Car currCar = list.Find(m => m.Model == carModel);

                if (currCar.CanDrive(amountOfKm))
                {
                    currCar.Drive(amountOfKm);
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            list.ForEach(x => Console.WriteLine(x));
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsPerKm { get; set; }
        public double TraveledDist { get; set; }

        public bool CanDrive(double distance)
        {
            double fuelNeeded = distance * FuelConsPerKm;
            return fuelNeeded <= FuelAmount;
        }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsPerKm;
            FuelAmount -= fuelNeeded;
            TraveledDist += distance;
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TraveledDist}";
        }
    }
}