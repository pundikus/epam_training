using System;
using System.Linq;

namespace TaskArray
{
    class CompairMinValues : IComparer<int[]>
    {
        /// <summary>
        /// Compare two arrays by using minimum values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Compare(int[] a, int[] b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));

            int aMin = a.Min();
            int bMin = b.Min();

            return aMin > bMin ? -1 : aMin < bMin ? 0 : 1;
        }
    }
}
