using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private CoffeeMat coffeeMat;
        [SetUp]
        public void Setup()
        {
            coffeeMat = new(100, 20);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            coffeeMat = new(100, 20);

            int expectedWaterCapacity = 100;
            int expectedButtonsCount = 20;
            int expectedIncome = 0;

            Assert.AreEqual(expectedWaterCapacity, coffeeMat.WaterCapacity);
            Assert.AreEqual(expectedButtonsCount, coffeeMat.ButtonsCount);
            Assert.AreEqual(expectedIncome, coffeeMat.Income);
        }

        [Test]
        public void FillWaterMethodShouldReturnTheCorrectMessageIfWaterTankLevelIsEqualToTheWaterCapacity()
        {
            coffeeMat = new(0, 20);

            string expectedResult = "Water tank is already full!";

            string actualResult = coffeeMat.FillWaterTank();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FillWaterMethodShouldReturnTheCorrectMessageIfWaterTankLevelIsNotEqualToTheWaterCapacity()
        {
            coffeeMat = new(100, 20);

            string expectedResult = $"Water tank is filled with 100ml";

            string actualResult = coffeeMat.FillWaterTank();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddDrinkMethodShouldReturnTrueIfDrinksCountIsLowerThanButtonsCountAndSuchDrinkDoesNotExistAlready()
        {
            Assert.IsTrue(coffeeMat.AddDrink("coffee", 1.5));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void AddDrinkMethodShouldReturnFalseIfDrinksCountIsEqualOrGreaterThanButtonsCount(int value)
        {
            coffeeMat = new(100, value);

            Assert.IsFalse(coffeeMat.AddDrink("coffee", 1.5));
        }

        [Test]
        public void AddDrinkMethodShouldReturnFalseIfSuchDrinkExistsAlready()
        {
            _ = coffeeMat.AddDrink("coffee", 1.5);

            Assert.IsFalse(coffeeMat.AddDrink("coffee", 1.5));
        }

        [Test]
        public void BuyDrinkMethodShouldReturnTheCorrectMessageIfWaterTankLevelIsLowerThan80()
        {
            coffeeMat = new(79, 20);

            _ = coffeeMat.FillWaterTank();

            string expectedMessage = "CoffeeMat is out of water!";

            string actualMessage = coffeeMat.BuyDrink("coffee");
        }

        [Test]
        public void BuyDrinkMethodShouldIncreaseIncomeWithThProductPriceIfSuchExists()
        {
            _ = coffeeMat.FillWaterTank();

            _ = coffeeMat.AddDrink("coffee", 1.5);

            _ = coffeeMat.BuyDrink("coffee");

            double expectedResult = 1.5;

            double actualResult = coffeeMat.Income;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void BuyDrinkMethodShouldReturnTheCorrectMessageIfPurchaseIsSuccessful()
        {
            _ = coffeeMat.FillWaterTank();

            _ = coffeeMat.AddDrink("coffee", 1.5);

            string expectedResult = "Your bill is 1.50$";

            string actualResult = coffeeMat.BuyDrink("coffee");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void BuyDrinkMethodShouldReturnTheCorrectMessageIfPurchaseIsNotSuccessful()
        {
            _ = coffeeMat.FillWaterTank();

            _ = coffeeMat.AddDrink("coffee", 1.5);

            string expectedResult = "tea is not available!";

            string actualResult = coffeeMat.BuyDrink("tea");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CollectIncomeShouldSetYheIncomeTo0()
        {
            _ = coffeeMat.FillWaterTank();

            _ = coffeeMat.AddDrink("coffee", 1.5);

            _ = coffeeMat.BuyDrink("coffee");

            _ = coffeeMat.CollectIncome();

            double expectedResult = 0;

            double actualResult = coffeeMat.Income;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CollectIncomeShouldReturnTheCorrectValue()
        {
            _ = coffeeMat.FillWaterTank();

            _ = coffeeMat.AddDrink("coffee", 1.5);

            _ = coffeeMat.BuyDrink("coffee");

            double expectedResult = 1.5;

            double actualResult = coffeeMat.CollectIncome();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}