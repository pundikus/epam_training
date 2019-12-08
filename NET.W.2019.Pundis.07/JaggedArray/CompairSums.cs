using System;
using System.Linq;

namespace TaskArray
{
    class CompairSums : IComparer<int[]>
    {
        /// <summary>
        /// Compair two arrays by using sums of elements
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Compare(int[] a, int[] b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));

            int aSum = a.Sum();
            int bSum = b.Sum();

            return aSum > bSum ? -1 : aSum < bSum ? 0 : 1;
        }
    }
}
