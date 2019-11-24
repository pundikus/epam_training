// <auto-generated />
namespace Tests
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;
    using Task4FilterDigiter;

    /// <summary>
    /// Class for testing
    /// </summary>
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// if list is empty
        /// </summary>
        [Test]
        public void FilterDigits_ArgumentNUllException()
        {
            List<int> list = new List<int> { };
            list = null;
            Assert.Throws<ArgumentNullException>(() => FilterDigiter.FilterDigit(list, 1));
        }

        /// <summary>
        /// Test first value
        /// </summary>
        [Test]
        public void Test_first_value()
        {
            List<int> list = new List<int> { 1, 2, 7, 4, 5, 6, 17, 12, 10, 50, 74, 172, 25 };
            var listf = FilterDigiter.FilterDigit(list, 7);
            Assert.AreEqual(FilterDigiter.FilterDigit(list, 7), new List<int> { 7, 17, 74, 172 });
        }

        /// <summary>
        /// Test second value
        /// </summary>
        [Test]
        public void Test_second_value()
        {
            List<int> list = new List<int> { 1, 2, 7, 4, 5, 6, 17, 12, 10, 50, 74, 172, 25 };
            var listf = FilterDigiter.FilterDigit(list, 2);
            Assert.AreEqual(FilterDigiter.FilterDigit(list, 2), new List<int> { 2, 12, 172, 25 });
        }
    }
}