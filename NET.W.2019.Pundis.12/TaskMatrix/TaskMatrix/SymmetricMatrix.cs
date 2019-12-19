using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMatrix
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="size"></param>
        public SymmetricMatrix(int size) : base(size)
        {

        }
        public SymmetricMatrix(int size, T[,] array) : base(size, array)
        {

        }

        /// <summary>
        /// Checks a possibility to create symmetric matrix
        /// </summary>
        /// <param name="size">size of matrix</param>
        /// <param name="array">existing matrix</param>
        /// <returns>true in case possibility to create symmetric matrix based on existing matrix else false</returns>
        public override bool CheckExisting(int size, T[,] array)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (Math.Sqrt(array.Length) != size)
            {
                return false;
            }

            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (!Equals(array[i, j], array[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Method starts after event
        /// </summary>
        /// <param name="sender">object which runs event</param>
        /// <param name="e">additional information about symmetric matrix</param>
        protected override void Info(object sender, MatrixEventArgs e) => Console.WriteLine($"Symmetric matrix[{e.Rows},{e.Columns}] is changed !");
    }
}
