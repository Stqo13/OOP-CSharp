using System;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
            Person[] persons =
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Stefko"),
                new Person(4, "Aleks"),
                new Person(5, "Teda"),
                new Person(6, "Stelko"),
                new Person(7, "Peter"),
                new Person(8, "Nasko"),
                new Person(9, "Desislava"),
                new Person(10, "Monika"),
                new Person(11, "Toshko")
            };

            database = new Database(persons);
        }

        [Test]
        public void When_CreatingDatabase_CountShouldBeCorrect()
        {
            int expectedResult = 11;

            int actualResult = database.Count;

            Assert.NotNull(database);
            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Test]
        public void When_DatabaseAddRangeMethodOverflows_ItShouldThrowException()
        {
            Person[] persons =
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Stefko"),
                new Person(4, "Aleks"),
                new Person(5, "Teda"),
                new Person(6, "Stelko"),
                new Person(7, "Peter"),
                new Person(8, "Nasko"),
                new Person(9, "Desislava"),
                new Person(10, "Monika"),
                new Person(11, "Toshko"),
                new Person(12, "Kiril"),
                new Person(13, "Petya"),
                new Person(14, "Radosveta"),
                new Person(15, "Margarita"),
                new Person(16, "Kalina"),
                new Person(17, "Todor")
            };

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => database = new Database(persons));

            Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message);
        }

        [Test]
        public void DatabaseCount_ShouldWorkCorrectly()
        {
            int expectedResult = 11;

            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void When_InvokingDatabaseAddMethod_CountShouldIncrease()
        {
            int expectedResult = 12;

            database.Add(new Person(12, "Kiril"));

            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void When_InvokingDatabaseAddMethod_Elements_ShouldBeAddedCorrectly()
        {
            int expectedResult = 12;

            database.Add(new Person(12, "Kiril"));

            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void When_DatabaseAddMethodOverflows_ItShouldThrowException()
        {
            var person12 = new Person(12, "Kiril");
            var person13 = new Person(13, "Petya");
            var person14 = new Person(14, "Radosveta");
            var person15 = new Person(15, "Margarita");
            var person16 = new Person(16, "Kalina");

            database.Add(person12);
            database.Add(person13);
            database.Add(person14);
            database.Add(person15);
            database.Add(person16);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(17, "Todor"));
            });

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", ex.Message);
        }

        [Test]
        public void When_DatabaseAddMethodAddsAnExistingUsername_ItShouldThrowException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(12, "Stefko"));
            });

            Assert.AreEqual(("There is already user with this username!"), ex.Message);
        }

        [Test]
        public void When_DatabaseAddMethodAddsAnExistingId_ItShouldThrowException()
        {

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(11, "Nikola"));
            });

            Assert.AreEqual("There is already user with this Id!", ex.Message);
        }

        [Test]
        public void When_InvokingDatabaseRemoveMethod_ItShouldRemoveCorrectly()
        {
            int expectedResult = 10;

            database.Remove();

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void When_DatabaseHasNoElements_RemoveMethod_ShouldThrowException()
        {
            database = new();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void When_InvokingDatabaseFindByUsername_ItShouldWorkCorrectly()
        {
            string expectedResult = "Pesho";

            string actualResult = database.FindByUsername("Pesho").UserName;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void When_InvokingDatabaseFindByUsername_ItShouldBeCaseSensitive()
        {
            string expectedResult = "peShO";
            string actualResult = database.FindByUsername("Pesho").UserName;

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_InvokingDatabaseFindByUsername_IfUserNameIsNull_ItShouldThrowException(string data)
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(data);
            });

            Assert.AreEqual("Username parameter is null!", ex.ParamName);
        }

        [Test]
        [TestCase("Dimitrichko")]
        [TestCase("Stanislav")]
        public void When_InvokingDatabaseFindByUsername_IfUserNameIsMissing_ItShouldThrowException(string data)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername(data);
            });

            Assert.AreEqual("No user is present by this username!", ex.Message);
        }

        [Test]
        public void When_InvokingDatabaseFindById_ItShouldWorkCorrectly()
        {
            long expectedResult = 11l;

            long actualResult = database.FindById(11l).Id;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void When_InvokingDatabaseFindById_IfIdIsNegative_ItShouldThrowException()
        {
            long id = -1l;

            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(id);
            });

            Assert.AreEqual("Id should be a positive number!", ex.ParamName);
        }

        [Test]
        public void When_InvokingDatabaseFindById_IfIdIsMissing_ItShouldThrowException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(12);
            });

            Assert.AreEqual("No user is present by this ID!", ex.Message);
        }
    }
}