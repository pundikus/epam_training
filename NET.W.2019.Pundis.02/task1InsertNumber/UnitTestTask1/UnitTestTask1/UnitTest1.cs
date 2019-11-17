using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersInserter;


namespace UnitTestProject1
{
    [TestClass]
    public class NumberTest
    {
        [TestMethod]
        public void TestingInsertNumber1()
        {
            Assert.AreEqual(15, InsertingNumbers.InsertNumber(15, 15, 0, 0));
        }

        [TestMethod]
        public void TestingInsertNumber2()
        {
            Assert.AreEqual(9, InsertingNumbers.InsertNumber(8, 15, 0, 0));
        }

        [TestMethod]
        public void TestingInsertNumber3()
        {
            Assert.AreEqual(120, InsertingNumbers.InsertNumber(8, 15, 3, 8));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCase1_OutOfRange()
        => InsertingNumbers.InsertNumber(8, 15, -7, 0);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCase2_OutOfRange()
        => InsertingNumbers.InsertNumber(8, 15, 7, 1);
    }
}
