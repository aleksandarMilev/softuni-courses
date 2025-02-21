namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        RailwayStation rs;

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            rs = new("rs");
            Assert.IsNotNull(rs);
            Assert.AreEqual(rs.Name, "rs");
            Assert.IsNotNull(rs.ArrivalTrains);
            Assert.IsNotNull(rs.DepartureTrains);
        }

        [Test]
        public void NameGetterShouldWorkProperly()
        {
            string name = "rs";
            Assert.AreEqual(rs.Name, name);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void NameSetterShouldThrowAnExceptionIfArgumentNullOrWhiteSpace(string name)
        {
            ArgumentException exc = Assert.Throws<ArgumentException>(() => rs = new(name));
            Assert.AreEqual(exc.Message, "Name cannot be null or empty!");
        }

        [Test]
        public void NewArrivalOnBoardMethodShouldAddTheTrainToTheInnerCollection()
        {
            rs = new("rs");
            rs.NewArrivalOnBoard("firstTrain");

            Queue<string> expectedResult = new();
            expectedResult.Enqueue("firstTrain");

            Assert.AreEqual(expectedResult, rs.ArrivalTrains);
        }

        [Test]
        public void TrainHasArrivedMethodShouldReturnTheProperMessageIfTheTrainPassedIsNotTheFirstInTheQueue()
        {
            rs = new("rs");
            rs.NewArrivalOnBoard("firstTrain");
            rs.NewArrivalOnBoard("secondTrain");
            rs.NewArrivalOnBoard("thirdTrain");

            string expectedMessage = $"There are other trains to arrive before thirdTrain.";

            Assert.AreEqual(expectedMessage, rs.TrainHasArrived("thirdTrain"));
        }

        [Test]
        public void TrainHasArrivedMethodShouldRemoveTheTrainIfTheTrainPassedIsTheFirstInTheQueue()
        {
            rs = new("rs");
            rs.NewArrivalOnBoard("firstTrain");
            rs.NewArrivalOnBoard("secondTrain");
            rs.NewArrivalOnBoard("thirdTrain");
            rs.TrainHasArrived("firstTrain");

            Queue<string> expectedResult = new();
            expectedResult.Enqueue("secondTrain");
            expectedResult.Enqueue("thirdTrain");

            Assert.AreEqual(rs.ArrivalTrains, expectedResult);
        }

        [Test]
        public void TrainHasArrivedMethodShouldReturnTheProperMessageIfTheTrainPassedIsTheFirstInTheQueue()
        {
            rs = new("rs");
            rs.NewArrivalOnBoard("firstTrain");
            rs.NewArrivalOnBoard("secondTrain");
            rs.NewArrivalOnBoard("thirdTrain");

            string expectedMessage = $"firstTrain is on the platform and will leave in 5 minutes.";

            Assert.AreEqual(expectedMessage, rs.TrainHasArrived("firstTrain"));
        }

        [Test]
        public void TrainHasArrivedMethodShouldAddTheTrainRemovedInDepartureTrainsCollection()
        {
            rs = new("rs");
            rs.NewArrivalOnBoard("firstTrain");
            rs.NewArrivalOnBoard("secondTrain");
            rs.NewArrivalOnBoard("thirdTrain");
            rs.TrainHasArrived("firstTrain");

            Queue<string> expectedResult = new();
            expectedResult.Enqueue("firstTrain");

            Assert.AreEqual(expectedResult, rs.DepartureTrains);
        }

        [Test]
        public void TrainHasLeftMethodShouldReturnTrueIfTrainPassedIsTheLastInDepartureTrainsCollection()
        {
            rs = new("rs");
            rs.NewArrivalOnBoard("firstTrain");
            rs.NewArrivalOnBoard("secondTrain");

            rs.TrainHasArrived("firstTrain");
            rs.TrainHasLeft("secondTrain");

            Assert.IsTrue(rs.TrainHasLeft("firstTrain"));
        }

        [Test]
        public void TrainHasLeftMethodShouldRemoveTheTrainFromDepartureTrainsIfTrainPassedIsTheLastInTheCollection()
        {
            rs = new("rs");
            rs.NewArrivalOnBoard("firstTrain");
            rs.NewArrivalOnBoard("secondTrain");

            rs.TrainHasArrived("firstTrain");
            rs.TrainHasLeft("secondTrain");

            Queue<string> expectedResult = new();
            expectedResult.Enqueue("firstTrain");

            Assert.AreEqual(expectedResult, rs.DepartureTrains);
        }

        [Test]
        public void TrainHasLeftMethodShouldReturnFalseIfTrainPassedIsNotTheLastInDepartureTrainsCollection()
        {
            rs = new("rs");
            rs.NewArrivalOnBoard("firstTrain");
            rs.NewArrivalOnBoard("secondTrain");

            rs.TrainHasArrived("firstTrain");
            rs.TrainHasArrived("secondTrain");

            Assert.IsFalse(rs.TrainHasLeft("secondTrain"));
        }
    }
}