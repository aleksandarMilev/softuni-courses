namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new("Audi", "A6", 10, 60);
        }


        //Constructor
        [Test]
        public void CreatingCarFuelAmountShouldBeEqualToZero()
        {
            int expectedResult = 0;

            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        public void CreatingCarShouldBeCorrectly()
        {
            string expectedMake = "Audi";
            string expectedModel = "A6";
            int expectedFuelConsumption = 10;
            int expectedFuelCapacity = 60;

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity); 
        }


        //MakeProperty
        [TestCase(null)]
        [TestCase("")]
        public void MakeShouldThrowAnExceptionIfIsSetToNull(string make)
        {
            Assert.Throws<ArgumentException>(()
                => car = new(make, "A6", 10, 60), "Make cannot be null or empty!");
        }


        //ModelProperty
        [TestCase(null)]
        [TestCase("")]
        public void ModelShouldThrowAnExceptionIfIsSetToNull(string model)
        {
            Assert.Throws<ArgumentException>(()
                => car = new("Audi", model, 10, 60), "Model cannot be null or empty!");
        }


        //FuelConsumptionProperty
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionShouldThrowAnExceptionIfIsSetToBelowOrEqualToZero(int fuelConsumption)
        {
            Assert.Throws<ArgumentException>(()
                => car = new("Audi", "A6", fuelConsumption, 60), "Fuel consumption cannot be zero or negative!");
        }


        //FuelAmountProperty
        [Test]
        public void FuelAmountShouldThrowAnExceptionIfIsNegative()
        {
            Assert.Throws<InvalidOperationException>(()
                => car.Drive(12), "Fuel amount cannot be negative!");
        }


        //FuelCapacityProperty
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacityShouldThrowAnExceptionIfIsSettToBelowOrEqualToZero(int fuelCapacity)
        {
            Assert.Throws<ArgumentException>(()
                => car = new("Audi", "A6", 10, fuelCapacity), "Fuel capacity cannot be zero or negative!");
        }


        //RefuelMethod
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelMethodShouldThrowAnExceptionIfParameterIsBelowOrEqualToZero(int refuelAmount)
        {
            Assert.Throws<ArgumentException>(()
                => car.Refuel(refuelAmount), "Fuel amount cannot be zero or negative!");
        }
        [Test]
        public void RefuelMethodShouldNotIncreaseFuelAmountMoreThanTheFuelCapacity()
        {
            int expectedResult = 60;

            car.Refuel(61);

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }
        [Test]
        public void RefuelMethodShouldIncreaseFuelAmountCorrectly()
        {
            int expectedResult = 10;

            car.Refuel(10);

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }


        //DriveMethod
        [Test]
        public void DriveMethodShouldThrowAnExceptionIfFuelNeededIsMoreThanTheFuelAmount()
        {
            Assert.Throws<InvalidOperationException>(()
                => car.Drive(100), "You don't have enough fuel to drive!");
        }
        [Test]
        public void DriveMethodShouldDecreaseFuelAmountCorrectly()
        {
            int expectedResult = 58;

            car.Refuel(60);

            car.Drive(20);

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }
    }
}