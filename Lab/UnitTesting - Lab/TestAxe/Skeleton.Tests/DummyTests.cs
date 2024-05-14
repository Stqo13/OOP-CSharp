using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void SetUp()
        {
            axe = new Axe(5, 10);
            dummy = new Dummy(20, 10);
        }

        [Test]
        public void Test_When_DummyTakesAttack_ItShouldLoseHealth()
        {
            axe.Attack(dummy);

            Assert.AreEqual(15, dummy.Health);
        }

        [Test]
        public void Test_When_ADeadDummyTakesAnAttack_ItShould_ThrowException()
        {
            dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
        [Test]
        public void Test_When_ADummyIsDead_ItShouldGiveExperience()
        {
            dummy = new Dummy(0, 10);

            Assert.AreEqual(10, dummy.GiveExperience());
        }

        [Test]
        public void Test_When_ADummyIsAlive_ItShould_ThrowException()
        {
            dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}