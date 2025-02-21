using System;
using System.Collections.Generic;
namespace _01Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxWagon = int.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "Add":
                        int passengersAdd = int.Parse(arguments[1]);
                        AddWagon(train, passengersAdd);
                        break;
                    default:
                        int passengersFit = int.Parse(arguments[0]);
                        FitPassengers(train, passengersFit, maxWagon);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", train));
        }
        static void AddWagon(List<int> train, int wagonAdd)
        {
            train.Add(wagonAdd);
        }

        static void FitPassengers(List<int> train, int passengersFit, int maxWagon)
        {
            for (int i = 0; i < train.Count; i++)
            {
                int available = maxWagon - train[i];
                if (passengersFit <= available)
                {
                    train[i] += passengersFit;
                    break;
                }
            }
        }

    }
}