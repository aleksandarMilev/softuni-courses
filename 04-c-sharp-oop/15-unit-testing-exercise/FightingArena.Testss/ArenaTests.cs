namespace FightingArena.Testss
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new();
        }


        //Constructor
        [Test]
        public void CreatingArenaShouldWorkCorrect()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }


        //CountProperty
        [Test]
        public void CountPropertyShouldReturnCorrectValue()
        {
            int expectedResult = 1;

            Warrior warrior = new("Transformer", 10, 100);

            arena.Enroll(warrior);

            Assert.AreEqual(expectedResult, arena.Count);
        }


        //EnrollMethod
        [Test]
        public void EnrollMethodShouldThrowAnExceptionIfWarriorWithTheSameNameAlreadyExists()
        {
            Warrior warrior1 = new("Transformer", 10, 100);
            arena.Enroll(warrior1);

            Warrior warrior2 = new("Transformer", 20, 200);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(warrior2));

            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }

        [Test]
        public void EnrollMethodShouldWorkCorrectly()
        {
            Warrior warrior = new("Transformer", 10, 100);
            arena.Enroll(warrior);

            Warrior warriorSearch = arena.Warriors.FirstOrDefault(w => w.Name == "Transformer");

            Assert.IsNotNull(warriorSearch);
        }


        //FightMethod
        [Test]
        public void FightMethodShouldThrowAnExceptionTheFirstWarriorDoNotExist()
        {
            Warrior warrior1 = new("Transformer1", 10, 100);
            Warrior warrior2 = new("Transformer2", 10, 100);

            arena.Enroll(warrior2);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Fight("Transformer1", "Transformer2"));

            Assert.AreEqual($"There is no fighter with name {warrior1.Name} enrolled for the fights!", exception.Message);
        }

        [Test]
        public void FightMethodShouldThrowAnExceptionTheSecondWarriorDoNotExist()
        {
            Warrior warrior1 = new("Transformer1", 10, 100);
            Warrior warrior2 = new("Transformer2", 10, 100);

            arena.Enroll(warrior1);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Fight("Transformer1", "Transformer2"));

            Assert.AreEqual($"There is no fighter with name {warrior2.Name} enrolled for the fights!", exception.Message);
        }

        [Test]
        public void FightMethodShouldWorkCorrectly()
        {
            Warrior warrior1 = new("Transformer1", 10, 100);
            Warrior warrior2 = new("Transformer2", 10, 100);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            arena.Fight(warrior1.Name, warrior2.Name);

            int expectedWarrior1Hp = 90;
            int expectedWarrior2Hp = 90;

            Assert.AreEqual(expectedWarrior1Hp, warrior1.HP);
            Assert.AreEqual(expectedWarrior2Hp, warrior2.HP);
        }
    }
}
 