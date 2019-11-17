using NUnit.Framework;
using task2FindNumber;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            long time = 0;
            Assert.AreEqual(FindNumber.FindNextBiggerNumber(10, out time), -1);
        }

        [Test]
        public void Test2()
        {
            long time = 0;
            Assert.AreEqual(FindNumber.FindNextBiggerNumber(20, out time), -1);
        }

        [Test]
        public void Test3()
        {
            long time = 0;
            Assert.AreEqual(FindNumber.FindNextBiggerNumber(513, out time), 531);
            Assert.AreEqual(FindNumber.FindNextBiggerNumber(2017, out time), 2071);
            Assert.AreEqual(FindNumber.FindNextBiggerNumber(414, out time), 441);
        }

        [Test]
        public void Test4()
        {
            long time = 0;
            Assert.That(FindNumber.FindNextBiggerNumber(1234321, out time), Is.EqualTo(1241233));
            Assert.That(FindNumber.FindNextBiggerNumber(3456432, out time), Is.EqualTo(3462345));
        }
    }
}