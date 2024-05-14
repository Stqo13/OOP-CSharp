using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void SetUp()
        {
            database = new Database(1, 2);
        }

        [Test]
        public void When_CreatingDatabase_CountShouldBeCorrect()
        {
            int expectedResult = 2;

            int actualResult = database.Count;

            Assert.NotNull(database);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8})]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void When_CreatingDatabase_ElementsShouldBeAddedCorrectly(int[] data)
        {
            database = new(data);

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17})]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20})]
        public void When_CreatingDatabaseTheAddMethod_ShouldThrowException(int[] data)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database = new Database(data);
            });

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", ex.Message);
        }

        [Test]
        public void DatabaseCount_ShouldWorkCorrectly()
        {
            int expectedResult = 2;

            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-3)]
        [TestCase(0)]
        public void When_InvokingDatabaseAddMethod_CountShouldIncrease(int number)
        {
            int expectedResult = 3;

            database.Add(number);

            Assert.AreEqual(expectedResult, database.Count);
        }

        [TestCase(new int[]{1, 2, 3, 4, 5, 6, 7, 8})]
        public void When_InvokingDatabaseAddMethod_Elements_ShouldBeAddedCorrectly(int[] data)
        {
            database = new Database();

            foreach (var item in data)
            {
                database.Add(item);
            }

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void When_DatabaseAddMethodOverflows_ItShouldThrowAnException(int[] data)
        {
            database = new Database(data);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            });

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", ex.Message);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void When_InvokingDatabaseRemoveMethod_Elements_ShouldBeRemovedCorrectly(int[] data)
        {
            int[] expectedResult = new int[] { 1 };

            database.Remove();

            int[] actualResult = database.Fetch();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void When_InvokingDatabaseRemoveMethod_CountShouldDecrease()
        {
            int expectedResult = 1;

            database.Remove();

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void When_DatabaseHasNoElements_RemoveMethod_ShouldThrowException()
        {
            database = new Database() { };

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });

            Assert.AreEqual("The collection is empty!", ex.Message);
        }

        [TestCase(new int[] {1, 2, 3, 4, 5})]
        public void When_InvokingFetchMethod_TheTwoArrays_ShouldBeIdentical(int[] data)
        {
            database = new Database(data);

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }
    }
}
