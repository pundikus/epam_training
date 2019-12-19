using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMatrix
{
    /// <summary>
    /// Abstruct class with main information about matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Matrix<T>
    {
        /// <summary>
        /// Two-dimensional array
        /// </summary>
        private T[,] matrix;
        /// <summary>
        /// Amount of elements
        /// </summary>
        public int Length { get { return matrix.Length; } }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public T this[int i, int j]
        {
            get
            {
                if (i > Math.Sqrt(Length) - 1 || j > Math.Sqrt(Length) - 1 || i < 0 || j < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(matrix));
                }

                return matrix[i, j];
            }
            set
            {
                if (i > Math.Sqrt(Length) - 1 || j > Math.Sqrt(Length) - 1 || i < 0 || j < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(matrix));
                }

                matrix[i, j] = value;
            }
        }
        /// <summary>
        /// Event which started in case of changing element in matrix
        /// </summary>
        public event EventHandler<MatrixEventArgs> changeMatrix = delegate { };

        #region constructors
        /// <summary>
        /// Create matrix
        /// </summary>
        /// <param name="size"></param>
        public Matrix(int size)
        {
            matrix = new T[size, size];
        }
        /// <summary>
        /// Create matrix based on existing one
        /// </summary>
        /// <param name="size"></param>
        /// <param name="array"></param>
        public Matrix(int size, T[,] array)
        {
            if (CheckExisting(size, array))
            {
                matrix = new T[size, size];
                Array.Copy(array, matrix, array.Length);
            }
            else
                throw new ArgumentException(nameof(array));
        }
        #endregion

        #region API
        /// <summary>
        /// Check possibility to create matrix
        /// </summary>
        /// <param name="size"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public abstract bool CheckExisting(int size, T[,] array);
        /// <summary>
        /// Add new operation to classes inheritance
        /// </summary>
        /// <param name="visitor"></param>
        public void Accept(IMatrixVisitor<T> visitor) => visitor.Visit((dynamic)this);
        /// <summary>
        /// Registrate method on event
        /// </summary>
        public void Register() => this.changeMatrix += Info;
        /// <summary>
        /// Unregistrate method
        /// </summary>
        public void Unregister() => this.changeMatrix -= Info;
        /// <summary>
        /// Change element in matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="element"></param>
        public void ChangeElement(int row, int column, T element)
        {
            MatrixEventArgs changeElement = new MatrixEventArgs(row, column);
            this[row, column] = element;
            OnChangeMatrix(changeElement);
        }
        /// <summary>
        /// Method starting after event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void Info(object sender, MatrixEventArgs e);
        #endregion
        /// <summary>
        /// Method starts event
        /// </summary>
        /// <param name="e"></param>
        private void OnChangeMatrix(MatrixEventArgs e) => changeMatrix?.Invoke(this, e);
    }
}
