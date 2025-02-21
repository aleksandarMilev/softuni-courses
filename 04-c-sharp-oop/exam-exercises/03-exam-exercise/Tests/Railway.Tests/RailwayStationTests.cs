namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class RailwayStationTests
    {
        private RailwayStation railwayStation;

        [SetUp]
        public void Setup()
        {
            railwayStation = new("CJPG");
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            string expectedName = "CJPG";

            Assert.AreEqual(expectedName, railwayStation.Name);

            Assert.IsNotNull(railwayStation.ArrivalTrains);
            Assert.IsNotNull(railwayStation.DepartureTrains);
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void NameSetterShouldThrowExceptionIfValueIsNullOrWhiteSpace(string value)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => railwayStation = new(value));

            Assert.AreEqual(exception.Message, "Name cannot be null or empty!");
        }
        [Test]
        public void NewArrivalOnBoardMethodEnqueueTheCorrectTrainInfo()
        {
            string expectedResult = "M10, 10:10, Sofia-Silistra";

            railwayStation.NewArrivalOnBoard(expectedResult);

            string actualResult = railwayStation.ArrivalTrains.Dequeue();

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void TrainHasArrivedMethodShouldEnqueueTheCorrectTrainIntoDepartureTrainsCollection()
        {
            string expectedResult = "M10, 10:10, Sofia-Silistra";

            railwayStation.ArrivalTrains.Enqueue(expectedResult);
            railwayStation.TrainHasArrived(expectedResult);

            string actualResult = railwayStation.DepartureTrains.Dequeue();

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void TrainHasArrivedMethodShouldReturnTheCorrectMessage()
        {
            string expectedResult = "M10, 10:10, Sofia-Silistra is on the platform and will leave in 5 minutes.";

            railwayStation.ArrivalTrains.Enqueue("M10, 10:10, Sofia-Silistra");

            string actualResult = railwayStation.TrainHasArrived("M10, 10:10, Sofia-Silistra");

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void TrainHasArrivedMethodShouldReturnTheCorrectMessageIfTheTrainInfoGivenIsDifferentThanTheTrainFromTheArrivalTrains()
        {
            string expectedResult = $"There are other trains to arrive before M10 10:10 Sofia-Razgrad.";

            railwayStation.ArrivalTrains.Enqueue("M10 10:00 Sofia-Razgrad");

            string actualResult = railwayStation.TrainHasArrived("M10 10:10 Sofia-Razgrad");

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void TrainHasLeftShouldReturnTrueIfDepartureTrainsTrainIsEqualToTheGiven()
        {
            railwayStation.DepartureTrains.Enqueue("M10 10:00 Sofia-Razgrad");

            Assert.IsTrue(railwayStation.TrainHasLeft("M10 10:00 Sofia-Razgrad"));
        }
        [Test]
        public void TrainHasLeftShouldReturnFalseIfDepartureTrainsTrainIsNotEqualToTheGiven()
        {
            railwayStation.DepartureTrains.Enqueue("M10 10:10 Sofia-Razgrad");

            Assert.IsFalse(railwayStation.TrainHasLeft("M10 10:00 Sofia-Razgrad"));
        }
    }
}