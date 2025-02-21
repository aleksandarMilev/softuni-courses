using NUnit.Framework;
using System.Linq;
namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;

        [SetUp]
        public void Setup()
        {
            factory = new("Transformer", 10);
        }
        [Test]
        public void FactoryConstructorShouldWorkProperly()
        {
            string expectedName = "Transformer";
            int expectedCapacity = 10;

            Assert.AreEqual(expectedName, factory.Name);
            Assert.AreEqual(expectedCapacity, factory.Capacity);
            Assert.IsNotNull(factory.Robots);
            Assert.IsNotNull(factory.Supplements);
        }
        [Test]
        public void NameSetterShouldWorkProperly()
        {
            string expectedName = "Transformer2";

            factory.Name = "Transformer2";

            Assert.AreEqual(expectedName, factory.Name);
        }
        [Test]
        public void CapacitySetterShouldWorkProperly()
        {
            int expectedCapacity = 20;

            factory.Capacity = 20;

            Assert.AreEqual(expectedCapacity, factory.Capacity);
        }
        [Test]
        public void ProduceRobotMethodShouldAddRobotToTheInnerCollection()
        {
            Robot expectedRobot = new("007", 100.50, 10);

            string expectedMessage =
                $"Produced --> Robot model: {expectedRobot.Model} IS: {expectedRobot.InterfaceStandard}, Price: {expectedRobot.Price:f2}";

            string actualMessage = factory.ProduceRobot("007", 100.50, 10);

            Robot actualRobot = factory.Robots.Single();

            Assert.AreEqual(expectedRobot.Model, actualRobot.Model);
            Assert.AreEqual(expectedRobot.Price, actualRobot.Price);
            Assert.AreEqual(expectedRobot.InterfaceStandard, actualRobot.InterfaceStandard);

            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [Test]
        public void ProduceRobotMethodShouldNotAddRobotToTheInnerCollectionIfRobotsCountIsEqualToTheFactoryCapacity()
        {
            string expectedMessage = "The factory is unable to produce more robots for this production day!";

            factory.Capacity = 0;
            string actualMessage = factory.ProduceRobot("Robot1", 100.50, 10);

            Assert.AreEqual(actualMessage, expectedMessage);
        }
        [Test]
        public void ProduceSupplementMethodShouldAddRobotToTheInnerCollection()
        {
            Supplement expectedSupplement = new("G7", 35);
            string expectedMessage = $"Supplement: {expectedSupplement.Name} IS: {expectedSupplement.InterfaceStandard}";

            string actualMessage = factory.ProduceSupplement("G7", 35);
            Supplement actualSupplement = factory.Supplements.Single();

            Assert.AreEqual(expectedSupplement.Name, actualSupplement.Name);
            Assert.AreEqual(expectedSupplement.InterfaceStandard, actualSupplement.InterfaceStandard);

            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [Test]
        public void UpgradeRobotMethodShouldAddTheSupplementToTheGivenRobotAndReturnTrue()
        {
            Robot robot = new("008", 100.50, 15);
            Supplement supplement = new("M18", 15);

            bool actualResult = factory.UpgradeRobot(robot,supplement);

            Supplement actualSupplement = robot.Supplements.Single();

            Assert.AreEqual(supplement.Name, actualSupplement.Name);
            Assert.AreEqual(supplement.InterfaceStandard, actualSupplement.InterfaceStandard);

            Assert.True(actualResult);
        }
        [Test]
        public void UpgradeRobotShouldNotAddSupplementIfTheRobotAlreadyContainsTheSupplementAndReturnFalse()
        {
            Robot robot = new("008", 100.50, 15);
            Supplement supplement = new("M18", 15);

            _ = factory.UpgradeRobot(robot, supplement);

            bool actualResult = factory.UpgradeRobot(robot, supplement);

            Assert.AreEqual(1, robot.Supplements.Count);
            Assert.IsFalse(actualResult);
        }
        [Test]
        public void UpgradeRobotShouldNotAddSupplementIfInterfaceStandardsDoNotMatchAndReturnFalse()
        {
            Robot robot = new("008", 100.50, 10);
            Supplement supplement = new("M18", 15);

            bool actualResult = factory.UpgradeRobot(robot, supplement);

            Assert.AreEqual(0, robot.Supplements.Count);
            Assert.IsFalse(actualResult);
        }
        [Test]
        public void SellRobotMethodShouldReturnTheCorrectRobot()
        {
            Robot expectedRobot = new("ExpR", 1_000, 10);

            factory.ProduceRobot("ExpR", 1_000, 10);
            factory.ProduceRobot("R1", 1_001, 10);
            factory.ProduceRobot("R2", 999, 10);

            Robot actualRobot = factory.SellRobot(1_000);

            Assert.AreEqual(expectedRobot.Model, actualRobot.Model);
            Assert.AreEqual(expectedRobot.InterfaceStandard, actualRobot.InterfaceStandard);
            Assert.AreEqual(expectedRobot.Price, actualRobot.Price);
        }
        [Test]
        public void SellRobotMethodShouldReturnNullIfPriceIsTooLow()
        {
            factory.ProduceRobot("ExpR", 1_002, 10);
            factory.ProduceRobot("R1", 1_001, 10);
            factory.ProduceRobot("R2", 999, 10);

            Robot robot = factory.SellRobot(998);

            Assert.IsNull(robot);
        }
        [Test]
        public void SellRobotMethodShouldReturnNullIfRobotCollectionIsEmpty()
        {
            Assert.IsNull(factory.SellRobot(100));
        }
    }
}
