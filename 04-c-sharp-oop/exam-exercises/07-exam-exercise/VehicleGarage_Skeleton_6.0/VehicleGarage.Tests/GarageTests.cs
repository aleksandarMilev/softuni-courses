using NUnit.Framework;
using System.Linq;

namespace VehicleGarage.Tests
{
    [TestFixture]
    public class GarageTests
    {
        private Garage garage;
        private Vehicle vehicle;

        [SetUp]
        public void SetUp()
        {
            garage = new(10);
            vehicle = new("Audi", "A6", "CA9999CB");
        }

        [Test]
        public void GarageConstructorShouldInitializeProperly()
        {
            garage = new(10);

            Assert.IsNotNull(garage);
            Assert.AreEqual(10, garage.Capacity);
            Assert.IsNotNull(garage.Vehicles);
        }

        [Test]
        public void AddVehicleMethodShouldAddTheGivenVehicleIfCapacityIsGreaterThanVehiclesCountAndTheVehicleIsNotAddedAlready()
        {
            garage.AddVehicle(vehicle);

            Assert.IsNotNull(garage
                .Vehicles
                .FirstOrDefault(v => v.LicensePlateNumber == vehicle.LicensePlateNumber));
        }

        [Test]
        public void AddVehicleMethodShouldReturnTrueIfVehicleIsAdded()
        {
            Assert.IsTrue(garage.AddVehicle(vehicle));
        }

        [Test]
        public void AddVehicleMethodShouldReturnFalseIfCapacityIsEqualToTheVehiclesCount()
        {
            garage.Capacity = 1;

            _ = garage.AddVehicle(vehicle);

            Assert.IsFalse(garage.AddVehicle(new("Audi", "A8", "B1234MT")));
        }

        [Test]
        public void AddVehicleMethodShouldReturnFalseIfVehicleWithTheGivenLicenseNumberAlreadyExists()
        {
            _ = garage.AddVehicle(vehicle);

            Assert.IsFalse(garage.AddVehicle(new("BMW", "E60", "CA9999CB")));
        }

        [Test]
        public void ChargeVehiclesMethodShouldRechargeTheBatteryOfEachVehicleWithBatteryLevelLowerOrEqualToTheGivenMethodParameter()
        {
            Vehicle vehicle1 = new("Audi", "A1", "CB1111CB");
            vehicle1.BatteryLevel = 49;
            _ = garage.AddVehicle(vehicle1);

            Vehicle vehicle2 = new("Audi", "A2", "CB2222CB");
            vehicle2.BatteryLevel = 50;
            _ = garage.AddVehicle(vehicle2);

            Vehicle vehicle3 = new("Audi", "A3", "CB3333CB");
            vehicle3.BatteryLevel = 1;
            _ = garage.AddVehicle(vehicle3);

            Vehicle vehicle4 = new("Audi", "A4", "CB4444CB");
            vehicle4.BatteryLevel = 51;
            _ = garage.AddVehicle(vehicle4);

            _ = garage.ChargeVehicles(50);

            Assert.AreEqual(100, vehicle1.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
            Assert.AreEqual(100, vehicle3.BatteryLevel);
        }

        [Test]
        public void ChargeVehiclesMethodShouldNotRechargeTheBatteryOfEachVehicleWithBatteryLevelGreaterThanTheGivenMethodParameter()
        {
            Vehicle vehicle1 = new("Audi", "A1", "CB1111CB");
            vehicle1.BatteryLevel = 49;
            _ = garage.AddVehicle(vehicle1);

            Vehicle vehicle2 = new("Audi", "A2", "CB2222CB");
            vehicle2.BatteryLevel = 50;
            _ = garage.AddVehicle(vehicle2);

            Vehicle vehicle3 = new("Audi", "A3", "CB3333CB");
            vehicle3.BatteryLevel = 1;
            _ = garage.AddVehicle(vehicle3);

            Vehicle vehicle4 = new("Audi", "A4", "CB4444CB");
            vehicle4.BatteryLevel = 51;
            _ = garage.AddVehicle(vehicle4);

            _ = garage.ChargeVehicles(50);

            Assert.AreEqual(51, vehicle4.BatteryLevel);
        }

        [Test]
        public void ChargeVehiclesMethodShouldReturnTheCorrectCountOfRechargedVehicles()
        {
            Vehicle vehicle1 = new("Audi", "A1", "CB1111CB");
            vehicle1.BatteryLevel = 49;
            _ = garage.AddVehicle(vehicle1);

            Vehicle vehicle2 = new("Audi", "A2", "CB2222CB");
            vehicle2.BatteryLevel = 50;
            _ = garage.AddVehicle(vehicle2);

            Vehicle vehicle3 = new("Audi", "A3", "CB3333CB");
            vehicle3.BatteryLevel = 1;
            _ = garage.AddVehicle(vehicle3);

            Vehicle vehicle4 = new("Audi", "A4", "CB4444CB");
            vehicle4.BatteryLevel = 51;
            _ = garage.AddVehicle(vehicle4);

            Assert.AreEqual(3 ,garage.ChargeVehicles(50));
        }

        [Test]
        public void DriveVehicleMethodShouldNotDoAnythingIfVehicleIsDamaged() //Testing a void method to ensure it doesn't do anything
                                                                              //is not very clear because,
                                                                              //by design void method's primary purpose is to perform some action.

        {
            vehicle.IsDamaged = true;

            _ = garage.AddVehicle(vehicle);

            garage.DriveVehicle("CA9999CB", 100, true);

            Assert.AreEqual(vehicle, garage.Vehicles[0]);
        }

        [Test]
        public void DriveVehicleMethodShouldNotDoAnythingIfBatteryDrainageIsGreaterThan100()
        {
            _ = garage.AddVehicle(vehicle);

            garage.DriveVehicle("CA9999CB", 101, true);

            Assert.AreEqual(vehicle, garage.Vehicles[0]);
        }

        [Test]
        public void DriveVehicleMethodShouldNotDoAnythingIfVehicleBatteryLevelIsLowerThanBatteryDrainageMethodParameter()
        {
            vehicle.BatteryLevel = 90;

            _ = garage.AddVehicle(vehicle);

            garage.DriveVehicle("CA9999CB", 91, true);

            Assert.AreEqual(vehicle, garage.Vehicles[0]);
        }

        [Test]
        public void DriveVehicleMethodShouldReduceTheBatteryLevelOfGivenVehicleWithBatteryDrainageMethodParameter()
        {
            _ = garage.AddVehicle(vehicle);

            garage.DriveVehicle("CA9999CB", 50, true);

            Assert.AreEqual(50, vehicle.BatteryLevel);
        }

        [Test]
        public void DriveVehicleMethodShouldSetTheVehicleIsDamagedPropertyToFalseIfAccidentOccurredParameterIsTrue()
        {
            _ = garage.AddVehicle(vehicle);

            garage.DriveVehicle("CA9999CB", 50, true);

            Assert.IsTrue(vehicle.IsDamaged);
        }

        [Test]
        public void RepairVehiclesMethodShouldSetTheIsDamagedPropertyToFalseOfEachVehicleWithIsDamagedEqualToTrue()
        {
            Vehicle vehicle1 = new("Audi", "A1", "CB1111CB");
            vehicle1.IsDamaged = true;
            garage.AddVehicle(vehicle1);

            Vehicle vehicle2 = new("Audi", "A2", "CB2222CB");
            vehicle2.IsDamaged = true;
            garage.AddVehicle(vehicle2);

            Vehicle vehicle3 = new("Audi", "A3", "CB3333CB");
            garage.AddVehicle(vehicle3);

           _ = garage.RepairVehicles();

            Assert.IsFalse(garage
                .Vehicles
                .First(v => v.LicensePlateNumber == "CB1111CB")
                .IsDamaged);

            Assert.IsFalse(garage
                .Vehicles
                .First(v => v.LicensePlateNumber == "CB2222CB")
                .IsDamaged);
        }

        [Test]
        public void RepairVehiclesMethodShouldReturnTheCorrectMessage()
        {
            Vehicle vehicle1 = new("Audi", "A1", "CB1111CB");
            vehicle1.IsDamaged = true;
            garage.AddVehicle(vehicle1);

            Vehicle vehicle2 = new("Audi", "A2", "CB2222CB");
            vehicle2.IsDamaged = true;
            garage.AddVehicle(vehicle2);

            Vehicle vehicle3 = new("Audi", "A3", "CB3333CB");
            garage.AddVehicle(vehicle3);

            string expectedResult = "Vehicles repaired: 2";

            Assert.AreEqual(expectedResult, garage.RepairVehicles());
        }
    }
}
