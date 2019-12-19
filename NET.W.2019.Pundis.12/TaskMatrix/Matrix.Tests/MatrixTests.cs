using System;
using System.Linq;
using NUnit.Framework;
using TaskMatrix;

namespace Matrix.Tests
{
    [TestFixture]
    public class MatrixesTests
    {
        private int[,] array = { { 4, 5, 6, 7 }, { 5, 4, 3, 2 }, { 7, 8, 8, 9 }, { 6, 1, 24, 5 } };

        public class Add : ISum<int>
        {
            public int Sum(int first, int second) => first + second;
        }

        [Test]
        public void SquareMatrixSum()
        {
            SquareMatrix<int> s = new SquareMatrix<int>(4, array);
            SquareMatrix<int> s1 = new SquareMatrix<int>(4, array);
            Matrix<int> actual = s.Sum(s1, new Add());
            Matrix<int> expected = new SquareMatrix<int>(4, new int[,] { { 8, 10, 12, 14 }, { 10, 8, 6, 4 }, { 14, 16, 16, 18 }, { 12, 2, 48, 10 } });
            for (int i = 0; i < Math.Sqrt(actual.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(actual.Length); j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }

        [Test]
        public void DiagonalMatrixSum()
        {
            SquareMatrix<int> s = new SquareMatrix<int>(4, array);
            DiagonalMatrix<int> s1 = new DiagonalMatrix<int>(4);
            Matrix<int> actual = s.Sum(s1, new Add());
            Matrix<int> expected = new SquareMatrix<int>(4, new int[,] { { 4, 5, 6, 7 }, { 5, 4, 3, 2 }, { 7, 8, 8, 9 }, { 6, 1, 24, 5 } });
            for (int i = 0; i < Math.Sqrt(actual.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(actual.Length); j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }

        [Test]
        public void SymmetricMatrixSum()
        {
            SquareMatrix<int> s = new SquareMatrix<int>(4, array);
            SymmetricMatrix<int> s1 = new SymmetricMatrix<int>(4, new int[,] { { 1, 2, 3, 4 }, { 2, 0, 0, 0 }, { 3, 0, 0, 0 }, { 4, 0, 0, 0 } });
            Matrix<int> actual = s.Sum(s1, new Add());
            Matrix<int> expected = new SquareMatrix<int>(4, new int[,] { { 5, 7, 9, 11 }, { 7, 4, 3, 2 }, { 10, 8, 8, 9 }, { 10, 1, 24, 5 } });
            for (int i = 0; i < Math.Sqrt(actual.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(actual.Length); j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }
    }
}
