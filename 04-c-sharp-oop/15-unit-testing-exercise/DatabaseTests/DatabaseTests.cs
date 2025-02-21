using NUnit.Framework;
using System;
namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new(1, 2);
        }

        //Constructor
        [Test]
        public void CreatingDatabaseElementsCountShouldBeCorrect()
        {
            int expectedResult = 2;

            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CreatingDatabaseShouldAddElementsCorrectly(int[] data)
        {
            database = new(data);
            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void CreatingDatabaseShouldThrowAnExceptionIfElementsCountIsGreaterThan16(int[] data)
        {
            Assert.Throws<InvalidOperationException>(()
                => database = new(data), "Array's capacity must be exactly 16 integers!");
        }


        //CountProperty
        [Test]
        public void CountGetterShouldReturnCorrectElementsCount()
        {
            int expectedResult = 2;

            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }


        //AddMethod
        [Test]
        public void AddMethodShouldIncreaseElementsCount()
        {
            int expectedResult = 3;

            database.Add(3);
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void AddMethodShouldAddElementsCorrectly(int[] data)
        {
            int[] expectedResult = data;
            database = new();

            for (int i = 0; i < 5; i++)
            {
                database.Add(data[i]);
            }

            int[] actualResult = database.Fetch();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddMethodShouldThrowAnExceptionIfElementsCountIsEqualTo16(int[] data)
        {
            database = new(data);

            Assert.Throws<InvalidOperationException>(()
                => database.Add(1), "Array's capacity must be exactly 16 integers!");
        }


        //RemoveMethod
        [Test]
        public void RemoveMethodShouldDecreaseElementsCount()
        {
            int expectedResult = 1;

            database.Remove();
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveMethodShouldRemoveElementsCorrectly()
        {
            int[] expectedResult = Array.Empty<int>();

            database.Remove();
            database.Remove();

            int[] actualResult = database.Fetch();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveMethodShouldThrowAnExceptionIfElementsCountIsEqualToZero()
        {
            database = new();

            Assert.Throws<InvalidOperationException>(()
                => database.Remove(), "The collection is empty!");
        }


        //FetchMethod
        [Test]
        public void FetchMethodShouldReturnCorrectData()
        {
            int[] expectedResult = { 1, 2 };

            int[] actualResult = database.Fetch();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
