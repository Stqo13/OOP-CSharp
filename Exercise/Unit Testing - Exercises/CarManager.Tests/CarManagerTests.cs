using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("Mercedes", "S63", 7.5, 50.0);
        }

        [Test]
        public void When_CreatingCar_ItShouldBeCreatedCorrectly()
        {
            string expectedMake = "Mercedes";
            string expectedModel = "S63";
            double expectedFuelConsumption = 7.5;
            double expectedFuelCapacity = 50.0;

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void When_CreatingCarFuelAmount_ItShouldBeZero()
        {
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_SettingCarMake_IfValueIsNull_ItShouldThrowException(string data)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(data, "S63", 7.5, 50.0);
            });

            Assert.AreEqual("Make cannot be null or empty!", ex.Message);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_SettingCarModel_IfValueIsNull_ItShouldThrowException(string data)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Mercedes", data, 7.5, 50.0);
            });

            Assert.AreEqual("Model cannot be null or empty!", ex.Message);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void When_SettingCarFuelConsumption_IfValueIsZeroOrNegative_ItShouldThrowException(double data)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Mercedes", "S63", data, 50.0);
            });

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", ex.Message);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-500)]
        public void When_SettingCarFuelCapacity_IfValueIsZeroOrNegative_ItShouldThrowException(double data)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Mercedes", "S63", 7.5, data);
            });

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", ex.Message);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void When_InvokingRefuelMethod_FuelToRefuelShouldNotBeZeroOrNegative_ThrowException(double data)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(data);
            });

            Assert.AreEqual("Fuel amount cannot be zero or negative!", ex.Message);
        }

        [Test]
        [TestCase(20)]
        public void When_InvokingRefuelMethod_ItShouldWorkCorrectly(double data)
        {
            double expectedResult = 20.0;

            car.Refuel(data);
            
            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [Test]
        [TestCase(55)]
        public void When_InvokingRefuelMethod_IfFuelAmountIsBiggerThanFuelCapacity_FuelAmountShouldBeEqualToFuelCapacity(double data)
        {
            double expectedResult = 50;

            car.Refuel(data);

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [Test]
        [TestCase(120)]
        public void When_InvokingDriveMethod_IfFuelNeedIsBiggerThanFuelAmount_ItShouldThrowException(double data)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(data);
            });

            Assert.AreEqual("You don't have enough fuel to drive!", ex.Message);
        }

        [Test]
        [TestCase(2000)]
        public void When_InvokingDriveMethod_FuelAmountShouldBeReturnedCorrectly(double data)
        {
            double expectedResult = 50.0;

            car = new Car("Mercedes", "S63", 7.5, 500.0);
            car.Refuel(200);
            car.Drive(data);

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }
    }
}