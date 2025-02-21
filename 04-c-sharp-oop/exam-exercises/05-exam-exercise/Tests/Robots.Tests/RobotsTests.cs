namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robotManager;

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            robotManager = new RobotManager(10);

            Assert.IsNotNull(robotManager);
            Assert.AreEqual(10, robotManager.Capacity);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-10_000)]
        public void CapacitySetterShouldThrowAnExceptionIfValueNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(()
                => robotManager = new RobotManager(capacity));
        }

        public void CapacitySetterExceptionMessageShouldBeCorrect(int capacity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => robotManager = new RobotManager(capacity));

            Assert.AreEqual("Invalid capacity!", ex.Message);
        }

        [Test]
        public void CountGetterShouldReturnTheCorrectValue()
        {
            robotManager = new RobotManager(10);

            robotManager.Add(new Robot("Robot1", 100));
            robotManager.Add(new Robot("Robot2", 100));
            robotManager.Add(new Robot("Robot3", 100));

            Assert.AreEqual(3, robotManager.Count);
        }

        [Test]
        public void AddShouldThrowAnExceptionIfSuchRobotWithSuchAlreadyExist()
        {
            robotManager = new RobotManager(10);

            robotManager.Add(new Robot("Robot1", 100));

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Add(new Robot("Robot1", 80)));
        }

        [Test]
        public void AddExceptionIfRobotNameDuplicatesShouldReturnTheCorrectMessage()
        {
            robotManager = new RobotManager(10);

            robotManager.Add(new Robot("Robot1", 100));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => robotManager.Add(new Robot("Robot1", 80)));

            Assert.AreEqual("There is already a robot with name Robot1!", ex.Message);
        }

        [Test]
        public void AddShouldThrowAnExceptionIfRobotsCountIsEqualToTheManagerCapacity()
        {
            robotManager = new RobotManager(1);

            robotManager.Add(new Robot("Robot1", 100));

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Add(new Robot("Robot2", 80)));
        }

        [Test]
        public void AddExceptionIfRobotsCountIsEqualToManagerCapacityShouldReturnTheCorrectMessage()
        {
            robotManager = new RobotManager(1);

            robotManager.Add(new Robot("Robot1", 100));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => robotManager.Add(new Robot("Robot2", 80)));

            Assert.AreEqual("Not enough capacity!", ex.Message);
        }

        [Test]
        public void RemoveShouldThrowAnExceptionIfRobotWithTheGivenNameDoesNotExist()
        {
            robotManager = new RobotManager(10);

            robotManager.Add(new Robot("Robot1", 100));
            robotManager.Add(new Robot("Robot2", 100));

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Remove("Robot3"));
        }

        [Test]
        public void RemoveExceptionIfRobotWithTheGivenNameDoesNotExistShouldReturnTheCorrectMessage()
        {
            robotManager = new RobotManager(10);

            robotManager.Add(new Robot("Robot1", 100));
            robotManager.Add(new Robot("Robot2", 100));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => robotManager.Remove("Robot3"));

            Assert.AreEqual("Robot with the name Robot3 doesn't exist!", ex.Message);
        }

        [Test]
        public void WorkShouldThrowAnExceptionIfRobotWithTheGivenNameDoesNotExist()
        {
            robotManager = new RobotManager(10);

            robotManager.Add(new Robot("Robot1", 100));
            robotManager.Add(new Robot("Robot2", 100));

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Work("Robot3", "SomeJob", 10));
        }

        [Test]
        public void WorkExceptionIfRobotWithTheGivenNameDoesNotExistShouldReturnTheCorrectMessage()
        {
            robotManager = new RobotManager(10);

            robotManager.Add(new Robot("Robot1", 100));
            robotManager.Add(new Robot("Robot2", 100));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                 => robotManager.Work("Robot3", "SomeJob", 10));

            Assert.AreEqual("Robot with the name Robot3 doesn't exist!", ex.Message);
        }

        [Test]
        public void WorkShouldThrowAnExceptionIfRobotBatteryIsLessThanBatteryUsage()
        {
            robotManager = new RobotManager(10);

            robotManager.Add(new Robot("Robot1", 50));
            robotManager.Add(new Robot("Robot2", 100));

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Work("Robot1", "SomeJob", 55));
        }

        [Test]
        public void WorkExceptionIfRobotBatteryIsLessThanBatteryUsageShouldReturnTheCorrectMessage()
        {
            robotManager = new RobotManager(10);

            robotManager.Add(new Robot("Robot1", 50));
            robotManager.Add(new Robot("Robot2", 100));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => robotManager.Work("Robot1", "SomeJob", 55));

            Assert.AreEqual("Robot1 doesn't have enough battery!", ex.Message);
        }

        [Test]
        public void WorkShouldDecreaseRobotBatteryWithTheBatteryUsage()
        {
            robotManager = new RobotManager(10);

            Robot robot1 = new Robot("Robot1", 100);

            robotManager.Add(robot1);
            robotManager.Add(new Robot("Robot2", 100));

            robotManager.Work("Robot1", "SomeJob", 50);

            Assert.AreEqual(50, robot1.Battery);
        }

        [Test]
        public void ChargeShouldThrowAnExceptionIfRobotWithTheGivenNameDoesNotExist()
        {
            robotManager = new RobotManager(10);

            robotManager.Add(new Robot("Robot1", 100));
            robotManager.Add(new Robot("Robot2", 100));

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Charge("Robot3"));
        }

        [Test]
        public void ChargeExceptionIfRobotWithTheGivenNameDoesNotExistShouldReturnTheCorrectMessage()
        {
            robotManager = new RobotManager(10);

            robotManager.Add(new Robot("Robot1", 50));
            robotManager.Add(new Robot("Robot2", 100));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => robotManager.Charge("Robot3"));

            Assert.AreEqual("Robot with the name Robot3 doesn't exist!", ex.Message);
        }

        [Test]
        public void ChargeShouldSetRobotBatteryToTheMaximumCapacityValue()
        {
            robotManager = new RobotManager(10);

            Robot robot1 = new Robot("Robot1", 100);

            robotManager.Add(robot1);
            robotManager.Add(new Robot("Robot2", 100));

            robotManager.Work("Robot1", "SomeJob", 50);

            robotManager.Charge("Robot1");

            Assert.AreEqual(100, robot1.Battery);
        }

    }
}
