namespace FightingArena.Testss
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new("Transformer", 10, 100);
        }


        //Constructor
        [Test]
        public void CreatingWarriorShouldWorkCorrectly()
        {
            string expectedName = "Transformer";
            int expectedDamage = 10;
            int expectedHp = 100;

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }


        //NameProperty
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void WarriorNameSetterShouldThrowAnExceptionIfValueIsNullOrWhiteSpace(string value)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => warrior = new(value, 10, 100));

            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
        }


        //DamageProperty
        [TestCase(0)]
        [TestCase(-1)]
        public void WarriorDamageSetterShouldThrowAnExceptionIfValueIsNotPositive(int value)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => warrior = new("Transformer", value, 100));

            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }


        //HpProperty
        [Test]
        public void WarriorHpSetterShouldThrowAnExceptionIfValueIsNegative()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => warrior = new("Transformer", 10, -1));

            Assert.AreEqual("HP should not be negative!", exception.Message);
        }


        //AttackMethod
        [TestCase(29)]
        [TestCase(30)]
        public void AttackMethodShouldThrowAnExceptionIfAttackerHpIsBelowOrEqualTo30(int hp)
        {
            Warrior attacker = new("Transformer", 10, hp);
            Warrior defender = new("Transformer", 10, 100);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
        }

        [TestCase(29)]
        [TestCase(30)]
        public void AttackMethodShouldThrowAnExceptionIfDefenderHpIsBelowOrEqualTo30(int hp)
        {
            Warrior attacker = new("Transformer", 10, 100);
            Warrior defender = new("Transformer", 10, hp);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual($"Enemy HP must be greater than 30 in order to attack him!", exception.Message);
        }

        [Test]
        public void AttackMethodShouldThrowAnExceptionIfAttackerHpIsLowerThanDefenderDamage()
        {
            Warrior attacker = new("Transformer", 10, 100);
            Warrior defender = new("Transformer", 101, 100);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("You are trying to attack too strong enemy", exception.Message);
        }

        [Test]
        public void AttackMethodShouldDecreaseAttackerHpCorrectly()
        {
            int expectedResult = 90;

            Warrior attacker = new("Transformer", 10, 100);
            Warrior defender = new("Transformer", 10, 100);

            attacker.Attack(defender);

            Assert.AreEqual(expectedResult, attacker.HP);
        }

        [Test]
        public void AttackMethodShouldSetDefenderHpToZeroIfAttackerDamageIsGreaterThanDefenderHp()
        {
            int expectedResult = 0;

            Warrior attacker = new("Transformer", 101, 100);
            Warrior defender = new("Transformer", 10, 100);

            attacker.Attack(defender);

            Assert.AreEqual(expectedResult, defender.HP);
        }

        [Test]
        public void AttackMethodShouldDecreaseDefenderHpCorrectly()
        {
            int expectedResult = 90;

            Warrior attacker = new("Transformer", 10, 100);
            Warrior defender = new("Transformer", 10, 100);

            attacker.Attack(defender);

            Assert.AreEqual(expectedResult, defender.HP);
        }
    }
}