using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMatrix
{
    public class MatrixEventArgs : EventArgs
    {
        /// <summary>
        /// Properties
        /// </summary>
        public int Rows { get; }
        public int Columns { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rows">row of matrix</param>
        /// <param name="columns">column of matrix</param>
        public MatrixEventArgs(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }
    }
}
