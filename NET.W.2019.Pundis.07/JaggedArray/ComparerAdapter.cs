using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskArray
{
    /// <summary>
    /// Adapting interface's methods of IComparer for using specified delegate.   
    /// </summary>
    public class ComparerAdapter : IComparer<int[]>
    {
        private readonly Func<int[], int[], int> _comparer;

        public ComparerAdapter(Func<int[], int[], int> comparer)
        {
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));
            _comparer = comparer;
        }

        /// <summary>
        /// Adapts this method for use the specified delegate.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public int Compare(int[] a, int[] b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));

            return _comparer.Invoke(a, b);
        }
    }
}
