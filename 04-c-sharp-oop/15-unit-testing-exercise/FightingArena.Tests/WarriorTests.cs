namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        //Constructor
        [Test]
        public void CreatingWarriorWorkCorrectly()
        {
            Warrior warrior = new("Transformer", 10, 100);

            string expectedName = "Transformer";
            int expectedDamage = 10;
            int expectedHp = 100;

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }
    }
}