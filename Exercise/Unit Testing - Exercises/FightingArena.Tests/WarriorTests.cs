using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Stefko", 15, 100);
        }

        [Test]
        public void When_CreatingWarrior_ItShouldBeCreatedCorrectly()
        {
            string expectedName = "Stefko";
            int expectedDamage = 15;
            int expectedHP = 100;

            warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            Assert.NotNull(warrior);
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_SettingWarriorName_IfValueIsNullOrEmpty_ItShouldThrowException(string data)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(data, 15, 100);
            });

            Assert.AreEqual("Name should not be empty or whitespace!", ex.Message);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void When_SettingDamage_IfValueIsZeroOrNegative_ItShouldThrowException(int data)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Stefko", data, 100);
            });

            Assert.AreEqual("Damage value should be positive!", ex.Message);
        }

        [Test]
        [TestCase(-1)]
        public void When_SettingHP_IfValueIsZeroOrNegative_ItShouldThrowException(int data)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Stefko", 15, data);
            });

            Assert.AreEqual("HP should not be negative!", ex.Message);
        }

        [Test]
        public void When_InvokingAttackMethod_IfHPIsLowerThanMinDamage_ItShouldThrowException()
        {
            var attacker = new Warrior("Aleks", 15, 20);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(warrior);
            });

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", ex.Message);
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void When_InvokingAttackMethod_IfEnemyHPIsLowerOrEqualToMinDamage_ItShouldThrowException(int data)
        {
            var enemy = new Warrior("Aleks", 18, data);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(enemy);;
            });

            Assert.AreEqual($"Enemy HP must be greater than 30 in order to attack him!", ex.Message);
        }

        [Test]
        public void When_InvokingAttackMethod_IfEnemyDamageIsBiggerThanHP_ItShouldThrowException()
        {
            var enemy = new Warrior("Stelko", 260, 100);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(enemy);
            });

            Assert.AreEqual($"You are trying to attack too strong enemy", ex.Message);
        }

        [Test]
        public void When_InvokingAttackMethod_HPShouldDecrease()
        {
            int expectedResult = 85;
            var enemy = new Warrior("Teda", 15, 100);

            warrior.Attack(enemy);

            Assert.AreEqual(expectedResult, warrior.HP);
        }

        [Test]
        public void When_InvokingAttackMethod_IfDamageIsBiggerThanEnemyHP_HPShouldBeZero()
        {
            warrior = new Warrior("Stefko", 50, 150);
            var enemy = new Warrior("Mitio", 15, 40);

            warrior.Attack(enemy);

            Assert.AreEqual(0 ,enemy.HP);
        }

        [Test]
        [TestCase(40)]
        [TestCase(35)]
        public void When_InvokingAttackMethod_IfDamageIsLowerOrEqualToEnemyHP_HPShouldDecrease(int data)
        {
            warrior = new Warrior("Stefko", data, 150);
            var enemy = new Warrior("Mitio", 15, 40);
            int expectedResult = enemy.HP - warrior.Damage;

            warrior.Attack(enemy);

            Assert.AreEqual(expectedResult, enemy.HP);
        }
    }
}