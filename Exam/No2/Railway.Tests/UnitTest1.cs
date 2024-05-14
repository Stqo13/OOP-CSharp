namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private RailwayStation railway;
        [SetUp]
        public void Setup()
        {
            railway = new RailwayStation("GaraSofia");
        }

        [Test]
        public void When_CreatingRailway_ItShouldWorkCorrectly()
        {
            string expectedName = "GaraSofia";

            Assert.AreEqual(expectedName, railway.Name);
            Assert.NotNull(railway.ArrivalTrains);
            Assert.NotNull(railway.DepartureTrains);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_SettingName_ItShouldThrowException(string data)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                new RailwayStation(data);
            });
            Assert.AreEqual("Name cannot be null or empty!", ex.Message);
        }

        [Test]
        public void When_InvokingNewArrivalMethod_ItShouldWorkCorrectly()
        {
            string expectedResult = "Vlak5";

            railway.NewArrivalOnBoard("Vlak5");

            Assert.AreEqual(expectedResult, railway.ArrivalTrains.Peek());
        }

        [Test]
        public void When_InvokingTrainHasArrivedMethod_ItShouldReturnCorrectMessage()
        {
            railway.NewArrivalOnBoard("Vlak5");

            string acutalResult = railway.TrainHasArrived("Vlak6");

            Assert.AreEqual("There are other trains to arrive before Vlak6.", acutalResult);
        }

        [Test]
        public void When_InvokingTrainHasArrivedMethod_DepartTrainsShouldFillUp_AndReturnCorrectMessage()
        {
            railway.NewArrivalOnBoard("Vlak7");
            string expectedResult = "Vlak7";

            string actualMessage = railway.TrainHasArrived("Vlak7");
            
            Assert.AreEqual(expectedResult, railway.DepartureTrains.Peek());
            Assert.AreEqual("Vlak7 is on the platform and will leave in 5 minutes.", actualMessage);
        }

        [Test]
        public void When_InvokingTrainHasLeftMethod_ItShouldWorkCorrectly()
        {
            railway.NewArrivalOnBoard("Vlak8");
            railway.TrainHasArrived("Vlak8");

            bool actualResult = railway.TrainHasLeft("Vlak8");

            Assert.AreEqual(0, railway.DepartureTrains.Count);
            Assert.AreEqual(true, actualResult);
        }

        [Test]
        public void When_InvokingTrainHasLeftMethod_ItShouldReturnFalse()
        {
            railway.NewArrivalOnBoard("Vlak8");
            railway.TrainHasArrived("Vlak8");

            bool actualResult = railway.TrainHasLeft("Vlak7");

            Assert.AreEqual(false, actualResult);
        }
    }
}