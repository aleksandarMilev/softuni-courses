using NUnit.Framework;
namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void WeaponLosesDurabilityAfterEachAttack()
        {
            Axe axe = new(10, 10);
            Dummy target = new(100, 10);

            axe.Attack(target);

            Assert.AreEqual(9, axe.DurabilityPoints);
        }

        [Test]
        public void AttackMethodShouldThrowAnExceptionIfDurabilityIsBelowOrEqualToZero()
        {
            Axe axe = new(10, 1);
            Dummy target = new(100, 10);

            axe.Attack(target);

            Assert.Throws<InvalidOperationException>(()
                => axe.Attack(target), "Axe is broken.");
        }
    }
}