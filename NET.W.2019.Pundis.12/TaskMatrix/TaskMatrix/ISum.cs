using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMatrix
{
    public interface ISum<T>
    {
        /// <summary>
        /// Sum of two elements
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        T Sum(T first, T second);
    }
}
