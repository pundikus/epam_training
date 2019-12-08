using System;
using NUnit.Framework;

namespace tests1_2
{
    [TestFixture]
    public class ExtensionMethodsNUnitTests
    {

        [TestCase(-55, 11, 110, ExpectedResult = 11)]
        [TestCase(10, 20, 40, 50, 100, ExpectedResult = 10)]
        [TestCase(27, 0, 54, ExpectedResult = 27)]
        [TestCase(150, 450, 900, ExpectedResult = 150)]
        public int EuclidGCDTest(params int[] array) => GCDMethods.EuclidGCD(array);

        [TestCase(null)]
        [TestCase(new int[0])]
        public void EuclidGCDTest_AcceptsEmptyArray_ThrowsException(params int[] array) => Assert.Throws<ArgumentNullException>(() => GCDMethods.EuclidGCD(array));

        [TestCase(-55, 11, 110, ExpectedResult = 11)]
        [TestCase(10, 20, 40, 50, 100, ExpectedResult = 10)]
        [TestCase(0, 27, 81, ExpectedResult = 27)]
        [TestCase(150, 450, 900, ExpectedResult = 150)]
        public int SteinGCDTest(params int[] array) => GCDMethods.SteinGCD(array);

        [TestCase(null)]
        [TestCase(new int[0])]
        public void SteinGCDTest_AcceptsEmptyArray_ThrowsException(params int[] array) => Assert.Throws<ArgumentNullException>(() => GCDMethods.SteinGCD(array));


        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string DoubleToBinaryStringTest(double number) => DoubleExtension.DoubleToBinaryString(number);

    }
}
