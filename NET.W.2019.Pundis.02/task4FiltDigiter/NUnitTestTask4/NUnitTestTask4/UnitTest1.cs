using NUnit.Framework;
using System.Collections.Generic;
using task4FilterDigiter;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            List<int> list = new List<int> { 1, 2, 7, 4, 5, 6, 17, 12, 10, 50, 74, 172, 25 };
            var listf = FilterDigiter.FilterDigit(list, 7);
            Assert.AreEqual(FilterDigiter.FilterDigit(list, 7), new List<int> { 7, 17, 74, 172 });
        }

        [Test]
        public void Test2()
        {
            List<int> list = new List<int> { 1, 2, 7, 4, 5, 6, 17, 12, 10, 50, 74, 172, 25 };
            var listf = FilterDigiter.FilterDigit(list, 2);
            Assert.AreEqual(FilterDigiter.FilterDigit(list, 2), new List<int> { 2, 12, 172, 25 });
        }
    }
}