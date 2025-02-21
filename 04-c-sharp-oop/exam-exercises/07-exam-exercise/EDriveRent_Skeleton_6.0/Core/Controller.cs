using EDriveRent.Core.Contracts;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using System.Linq;
using System;
using EDriveRent.Utilities.Messages;
using EDriveRent.Models;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;
using System.Text;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private IRepository<IUser> users;
        private IRepository<IVehicle> vehicles;
        private IRepository<IRoute> routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            if (routes.GetAll()
                .Any(r => r.StartPoint == startPoint &&
                r.EndPoint == endPoint &&
                r.Length == length))
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }

            if (routes.GetAll()
                .Any(r => r.StartPoint == startPoint &&
                r.EndPoint == endPoint &&
                r.Length < length))
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }

            Route route = new(startPoint, endPoint, length, routes.GetAll().Count + 1);

            routes.AddModel(route);

            foreach (Route longerRoute in routes
                .GetAll()
                .Where(r => r.StartPoint == startPoint &&
                r.EndPoint == endPoint &&
                r.Length > length))
            {
                longerRoute.IsLocked = true;
            }

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }
        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.GetAll().First(u => u.DrivingLicenseNumber == drivingLicenseNumber);

            if (user.IsBlocked == true)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }

            Vehicle vehicle = vehicles.GetAll().First(v => v.LicensePlateNumber == licensePlateNumber) as Vehicle;

            if (vehicle.IsDamaged == true)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }

            IRoute route = routes.GetAll().First(r => r.RouteId == int.Parse(routeId));

            if (route.IsLocked == true)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened == true)
            {
                vehicle.IsDamaged = true;

                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }
        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (users.GetAll().Any(u => u.DrivingLicenseNumber == drivingLicenseNumber))
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            IUser user = new User(firstName, lastName, drivingLicenseNumber);

            users.AddModel(user);

            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }
        public string RepairVehicles(int count)
        {
            int counter = 0;

            foreach (Vehicle vehicle in vehicles
                .GetAll()
                .Where(v => v.IsDamaged == true)
                .OrderBy(v => v.Brand)
                .ThenBy(v => v.Model)
                .Take(count))
            {
                vehicle.Recharge();

                vehicle.IsDamaged = false;

                counter++;
            }

            return string.Format(OutputMessages.RepairedVehicles, counter);
        }
        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != "PassengerCar" && vehicleType != "CargoVan")
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            if (vehicles.GetAll().Any(v => v.LicensePlateNumber == licensePlateNumber))
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            IVehicle vehicle = null;

            if (vehicleType == "PassengerCar")
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
            else
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }

            vehicles.AddModel(vehicle);

            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }
        public string UsersReport()
        {
            StringBuilder result = new();

            result.AppendLine("*** E-Drive-Rent ***");

            foreach (User user in users
                .GetAll()
                .OrderByDescending(u => u.Rating)
               .ThenBy(u => u.LastName)
               .ThenBy(u => u.FirstName))
            {
                result.AppendLine(user.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
