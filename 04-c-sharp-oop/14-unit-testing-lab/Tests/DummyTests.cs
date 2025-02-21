using NUnit.Framework;
namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyHealthDecreasesAfterAttack()
        {
            Dummy dummy = new(20, 10);

            dummy.TakeAttack(10);

            Assert.AreEqual(10, dummy.Health);
        }

        [Test]
        public void TakeAttackMethodThrowsAnExceptionIfDummyIsDead()
        {
            Dummy dummy = new(10, 10);

            dummy.TakeAttack(10);

            Assert.Throws<InvalidOperationException>(()
                => dummy.TakeAttack(10), "Dummy is dead.");
        }

        [Test]
        public void DeadDummyGivesExperience()
        {
            Dummy dummy = new(10, 10);

            dummy.TakeAttack(10);
            int experience = dummy.GiveExperience(); 

            Assert.That(experience == dummy.GiveExperience());
        }

        [Test]
        public void AliveDummyDoesNotGiveExperience()
        {
            Dummy dummy = new(10, 10);

            Assert.Throws<InvalidOperationException>(()
                => dummy.GiveExperience(), "Target is not dead.");
        }
    }
}