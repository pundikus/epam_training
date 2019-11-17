using NUnit.Framework;
using FindRooter;
using System;

namespace Tests
{
    public class Tests
    {
        [TestFixture]
        public class FindRooterClassNUnitTests
        {
            [TestCase(1, 5, 0.0001, 1)]
            [TestCase(8, 3, 0.0001, 2)]
            [TestCase(0.001, 3, 0.0001, 0.1)]
            [TestCase(0.04100625, 4, 0.0001, 0.45)]
            [TestCase(8, 3, 0.0001, 2)]
            [TestCase(0.0279936, 7, 0.0001, 0.6)]
            [TestCase(0.0081, 4, 0.1, 0.3)]
            [TestCase(-0.008, 3, 0.1, -0.2)]
            [TestCase(0.004241979, 9, 0.00000001, 0.545)]
            public void FindNthRootTest1(double number, int degree, double precision, double result)
            {
                Assert.AreEqual(result, FindNthRooter.FindNthRoot(number, degree, precision), Math.Pow(10, 2 - precision.ToString().Length));
            }

            [TestCase(8, 15, -7)]
            [TestCase(8, 15, -0.6)]
            public void FindNthRootTest_Number_Degree_Precision_ArgumentOutOfRangeException(double number, int degree, double precision)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => FindNthRooter.FindNthRoot(number, degree, precision));
            }
        }
    }
}