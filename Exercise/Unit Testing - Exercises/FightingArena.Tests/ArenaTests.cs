namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void When_CreatingArena_ItShouldBeCreatedCorrectly()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void ArenaCount_ShouldWorkCorrectly()
        {
            int expectedResult = 1;

            Warrior warrior = new("Stefko", 5, 100);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(expectedResult, arena.Count);
        }

        [Test]
        public void When_InvokingEnrollMethod_ItShouldWorkCorrectly()
        {
            Warrior warrior = new("Stefko", 5, 100);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]
        public void When_InvokingEnrollMethod_IfWarriorIsAlreadyEnrolled_ItShouldThrowException()
        {
            Warrior warrior = new("Stefko", 5, 100);

            arena.Enroll(warrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()=>
            {
                arena.Enroll(warrior);
            });

            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }


        [Test]
        public void When_InvokingFightMethod_ItShouldWorkCorreclty()
        {
            Warrior attacker = new("Stefko", 15, 100);
            Warrior defender = new("Aleks", 5, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            int expectedAttackerHp = 95;
            int expectedDefenderHp = 35;

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void When_InvokingFightMethod_IfAttackerIsNotFound_ItShouldThrowException()
        {
            Warrior attacker = new("Stefko", 15, 100);
            Warrior defender = new("Aleks", 5, 50);

            arena.Enroll(defender);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()=>
            {
                arena.Fight(attacker.Name, defender.Name);
            });

            Assert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!", exception.Message);
        }

        [Test]
        public void When_InvokingFightMethod_IfDefenderIsNotFound_ItShouldThrowException()
        {
            Warrior attacker = new("Stefko", 15, 100);
            Warrior defender = new("Aleks", 5, 50);

            arena.Enroll(attacker);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()=>
            {
                arena.Fight(attacker.Name, defender.Name);
            });

            Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", exception.Message);
        }
    }
}
