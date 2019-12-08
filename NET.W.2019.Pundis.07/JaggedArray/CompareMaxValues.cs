using System;
using System.Linq;

namespace TaskArray
{
    class CompareMaxValues : IComparer<int[]>
    {
        /// <summary>
        /// Sorting arrays by using maximum element in this array
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Compare(int[] a, int[] b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));

            int aMax = a.Max();
            int bMax = b.Max();

            return aMax > bMax ? -1 : aMax < bMax ? 0 : 1;
        }
    }
}
