using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void SetUp()
        {
            int attack = 10;
            int durability = 10;
            axe = new Axe(attack, durability);
            int health = 10;
            int experience = 10;
            dummy = new Dummy(health, experience);
        }

        [Test]
        public void Test_When_AttackingWithAxe_DurabilityPoints_ShouldDecrease()
        {
            axe.Attack(dummy);
            Assert.AreEqual(9, axe.DurabilityPoints, "Durability is decreasing properly");
        }

        [Test]
        public void Test_When_AttackingWithBrokenAxe_AnExceptionShouldBe_Thrown()
        {
            axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}