using NUnit.Framework;

namespace VehicleGarage.Tests
{
    [TestFixture]
    public class VehicleTests
    {
        [Test]
        public void VehicleConstructorInstanceVehicleProperly()
        {
            Vehicle vehicle = new("Audi", "A6", "CA9999CB");

            string expectedBrand = "Audi";
            string expectedModel = "A6";
            string expectedLicensePlateNumber = "CA9999CB";
            int expectedBatteryLevel = 100;
            bool expectedIsDamaged = false;

            Assert.IsNotNull(vehicle);

            Assert.AreEqual(expectedBrand, vehicle.Brand);
            Assert.AreEqual(expectedModel, vehicle.Model);
            Assert.AreEqual(expectedLicensePlateNumber, vehicle.LicensePlateNumber);
            Assert.AreEqual(expectedBatteryLevel, vehicle.BatteryLevel);
            Assert.AreEqual(expectedIsDamaged ,vehicle.IsDamaged);
        }
    }
}