using NUnit.Framework;
using System;
namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            Person[] people =
            {
                new(1, "Ivan"),
                new(2, "Petkan"),
                new(3, "Dragan"),
                new(4, "Stoqn"),
                new(5, "RobinzoKruzo"),
                new(6, "Dimitrichko"),
                new(7, "Stoine")
            };

            database = new(people);
        }

        //Constructor
        [Test]
        public void CreatingDataBaseCountShouldBeCorrect()
        {
            int expectedResult = 7;

            Assert.AreEqual(expectedResult, database.Count);
        }
        [Test]
        public void CreatingDataShouldThrowAnExceptionIfPeopleCountIsGreaterThan16()
        {
            Person[] people =
            {
                new(1, "Ivan"),
                new(2, "Petkan"),
                new(3, "Dragan"),
                new(4, "Stoqn"),
                new(5, "RobinzoKruzo"),
                new(6, "Dimitrichko"),
                new(7, "Stoine"),
                new(8, "Zdravko"),
                new(9, "Jelqko"),
                new(10, "ZdravkoJelqzkov"),
                new(11, "JelqzkoZdravkov"),
                new(12, "Vulchan"),
                new(13, "Suleiman"),
                new(14, "Dimirtii"),
                new(15, "Ahmed"),
                new(16, "Mehmed"),
                new(17, "Mohamed"),
            };

            Assert.Throws<ArgumentException>(()
                => database = new(people), "Provided data length should be in range [0..16]!");
        }


        //CountProperty
        [Test]
        public void CountGetterShouldReturnCorrectValue()
        {
            int expectedResult = 7;

            Assert.AreEqual(7, database.Count);
        }


        //AddMethod
        [Test]
        public void AddMethodShouldThrowAnExceptionIfPeopleCountIsEqualTo16()
        {
            Person[] people =
            {
                new(1, "Ivan"),
                new(2, "Petkan"),
                new(3, "Dragan"),
                new(4, "Stoqn"),
                new(5, "RobinzoKruzo"),
                new(6, "Dimitrichko"),
                new(7, "Stoine"),
                new(8, "Zdravko"),
                new(9, "Jelqko"),
                new(10, "ZdravkoJelqzkov"),
                new(11, "JelqzkoZdravkov"),
                new(12, "Vulchan"),
                new(13, "Suleiman"),
                new(14, "Dimirtii"),
                new(15, "Ahmed"),
                new(16, "Mehmed"),
            };

            database = new(people);

            Person person = new(17, "Ali");

            Assert.Throws<InvalidOperationException>(()
                => database.Add(person), "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void AddMethodShouldThrowAnExceptionIfPersonWithSameNameAlreadyExists()
        {

            Person person = new(17, "Stoine");

            Assert.Throws<InvalidOperationException>(()
                => database.Add(person), "There is already user with this username!");
        }
        [Test]
        public void AddMethodShouldThrowAnExceptionIfPersonWithSameIdAlreadyExists()
        {

            Person person = new(1, "MohamedAli");

            Assert.Throws<InvalidOperationException>(()
                => database.Add(person), "There is already user with this Id!");
        }
        [Test]
        public void AddMethodShouldIncreasePeopleCount()
        {
            int expectedResult = 8;

            Person person = new(8, "AliMehmed");
            database.Add(person);

            Assert.AreEqual(expectedResult, database.Count);
        }


        //RemoveMethod
        [Test]
        public void RemoveMethodShouldDecreasePeopleCountCorrect()
        {
            int expectedResult = 6;

            database.Remove();

            Assert.AreEqual(6, database.Count);
        }
        [Test]
        public void RemoveMethodShouldThrowAnExceptionIfPeopleCountIsEqualToZero()
        {
            database = new();

            Assert.Throws<InvalidOperationException>(()
                => database.Remove());
        }


        //FindByUserNameMethod
        [Test]
        public void FindByUsernameMethodShouldBeCaseSensitive()
        {
            string expectedResult = "iVAn";

            string actualResult = database.FindByUsername("Ivan").UserName;

            Assert.AreNotEqual(expectedResult, actualResult);
        }
        [Test]
        public void FindByUserNameMethodShouldThrowAnExceptionIfParameterIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(()
                => database.FindByUsername(null), "Username parameter is null!");
        }
        [Test]
        public void FindByUserNameMethodShouldThrowAnExceptionIfPersonWithThatNameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(()
                => database.FindByUsername("Velko"), "No user is present by this username!");
        }
        [Test]
        public void FindByUserNameReturnTheCorrectPerson()
        {
            string expectedResult = "Ivan";

            string actualResult = database.FindByUsername("Ivan").UserName;

            Assert.AreEqual(expectedResult, actualResult);
        }


        //FindById
        [Test]
        public void FindByIdMethodShouldThrowAnExceptionIfParameterIsNegativeNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => database.FindById(-1), "Id should be a positive number!");
        }
        [Test]
        public void FindByIdMethodShouldThrowAnExceptionIfPersonWithThatIdDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(()
                => database.FindById(20), "No user is present by this ID!");
        }
        [Test]
        public void FindByIdMethodShouldReturnTheCorrectPerson()
        {
            int expectedResult = 1;

            long actualResult = database.FindById(1).Id;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}