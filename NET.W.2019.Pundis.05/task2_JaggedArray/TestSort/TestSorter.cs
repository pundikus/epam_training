using System;
using NUnit.Framework;
using JaggedArraySorter;

namespace TestSorter
{
    [TestFixture]
    public class JaggedArraySorterTests
    {
        [TestCase(null)]
        public void BubbleSortTest_AcceptsEmptyArray_ThrowsException(int[][] array)
        {
            Assert.Throws<ArgumentNullException>(() => SortBySumOfTheElements.GetCompareElements(new JaggedArray(array)));
        }

        [Test]
        public void Sort_CompareArraySum()
        {
            var array = new int[5][] { new int[] { 3, 5, 6 }, new int[] { 3, 5, 6, 7 }, new int[] { 3, 5 }, new int[] { 3, 5, 6, 7, 9 }, new int[] { 3 } };
            var JG = new JaggedArray(array);

            var expected = new int[5][] { new int[] { 3 }, new int[] { 3, 5 }, new int[] { 3, 5, 6 }, new int[] { 3, 5, 6, 7 }, new int[] { 3, 5, 6, 7, 9 } };

            SortBySumOfTheElements.GetCompareElements(JG);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void Sort_CompareArrayMax()
        {
            var array = new int[5][] { new int[] { 3, 5, 6 }, new int[] { 3, 5, 6, 7 }, new int[] { 3, 5 }, new int[] { 3, 5, 6, 7, 9 }, new int[] { 3 } };
            var JG = new JaggedArray(array);

            var expected = new int[5][] { new int[] { 3 }, new int[] { 3, 5 }, new int[] { 3, 5, 6 }, new int[] { 3, 5, 6, 7 }, new int[] { 3, 5, 6, 7, 9 } };

            SortByMaximumOfTheElements.GetCompareElements(JG);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void Sort_CompareArrayMin()
        {
            var array = new int[5][] { new int[] { 3, 5, 6 }, new int[] { -3, 5, 6, 7 }, new int[] { -43, 5 }, new int[] { -53, 5, 6, 7, 9 }, new int[] { 8 } };
            var JG = new JaggedArray(array);

            var expected = new int[5][] { new int[] { -53, 5, 6, 7, 9 }, new int[] { -43, 5 }, new int[] { -3, 5, 6, 7 }, new int[] { 3, 5, 6 }, new int[] { 8 } };

            SortByMinimumOfTheElements.GetCompareElements(JG);

            CollectionAssert.AreEqual(expected, array);
        }
    }
}
