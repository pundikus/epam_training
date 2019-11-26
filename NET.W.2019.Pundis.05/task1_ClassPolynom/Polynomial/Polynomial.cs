using System;
using System.Collections.Generic;
using System.Text;

namespace ClassPolynomial
{
    /// <summary>
    /// Class for for polynomial
    /// </summary>
    public sealed class Polynomial
    {
        private const double Epsilon = 0.000001;

        private readonly double[] _coefficients = { };

        private int degree;

        /// <summary>
        /// Public constructor for Polynomial
        /// </summary>
        /// <param name="coefficients">Given array of Polynomial coefficients</param>
        public Polynomial(params double[] coefficients)
        {
            _coefficients = coefficients;
            degree = Degree;
        }

        /// <summary>
        /// Property for Polynomial degree
        /// </summary>
        public int Degree
        {
            get
            {
                if (_coefficients.Length == 1)
                {
                    return 0;
                }

                int i;
                for (i = _coefficients.Length - 1; i >= 0; i--)
                {
                    if (Math.Abs(_coefficients[i]) > Epsilon)
                    {
                        break;
                    }
                }

                return i;
            }
        }

        /// <summary>
        /// Indexer for Polynomial
        /// </summary>
        /// <param name="number">Index for Polynomial member</param>
        /// <returns>Member of Polynomial by given index</returns>
        public double this[int number]
        {
            get
            {
                if (degree > _coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _coefficients[degree];
            }

            private set
            {
                if (number >= 0 || number < _coefficients.Length)
                {
                    _coefficients[number] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Method that overrides operator '+' of two Polynomials
        /// </summary>
        /// <param name="pol1">first polynomial</param>
        /// <param name="pol2">second polynomial</param>
        /// <returns>New polynomial that is sum of given</returns>
        public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
        {
            if (pol1 is null || pol2 is null)
            {
                throw new ArgumentNullException();
            }

            double[] larger = new double[pol1.Degree],
                     smaller = new double[pol2.Degree];

            CopyPolynomialCoefficients(pol1, pol2, ref larger, ref smaller);

            for (int i = 0; i < smaller.Length; i++)
            {
                larger[i] += smaller[i];
            }

            return new Polynomial(larger);
        }

        /// <summary>
        /// Method that overrides operator '-' of two Polynomials
        /// </summary>
        /// <param name="pol1">first polynomial</param>
        /// <param name="pol2">second polynomial</param>
        /// <returns>New polynomial that is difference of given</returns>
        public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
        {
            if (pol1 is null || pol2 is null)
            {
                throw new ArgumentNullException();
            }

            double[] larger = new double[pol1.Degree], smaller = new double[pol2.Degree];

            CopyPolynomialCoefficients(pol1, pol2, ref larger, ref smaller);

            for (int i = 0; i < smaller.Length; i++)
            {
                larger[i] -= smaller[i];
            }

            return new Polynomial(larger);
        }

        /// <summary>
        /// Method that overrides operator '*' for multiplication of two Polynomials
        /// </summary>
        /// <param name="pol1">first polynomial</param>
        /// <param name="pol2">second polynomial</param>
        /// <returns>New polynomial that is result of multiplication of given</returns>
        public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
        {
            if (pol1 is null || pol2 is null)
            {
                throw new ArgumentNullException();
            }

            double[] result = new double[pol1._coefficients.Length + pol2._coefficients.Length];

            for (int i = 0; i < pol1._coefficients.Length; i++)
            {
                for (int j = 0; j < pol2._coefficients.Length; j++)
                {
                    result[i + j] += pol1._coefficients[i] * pol2._coefficients[j];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Method that overrides operator '==' to compare two Polynomials
        /// </summary>
        /// <param name="pol1">first polynomial</param>
        /// <param name="pol2">second polynomial</param>
        /// <returns>True if polynomials are equal, else false</returns>
        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            if (ReferenceEquals(pol1, pol2))
            {
                return true;
            }

            if (pol1 is null || pol2 is null)
            {
                return false;
            }

            return pol1.Equals(pol2);
        }

        /// <summary>
        /// Method that overrides operator '!=' to compare two Polynomials
        /// </summary>
        /// <param name="pol1">first polynomial</param>
        /// <param name="pol2">second polynomial</param>
        /// <returns>True if polynomials are not equal, else false</returns>
        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            return !pol1.Equals(pol2);
        }

        /// <summary>
        /// Method that overrides Equals method of System.Object class 
        /// </summary>
        /// <param name="obj">Boxed polynomial to compare with given</param>
        /// <returns>True if polynomials are equal, else false</returns>
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var temp = obj as Polynomial;
            if (_coefficients.Length != temp._coefficients.Length)
            {
                return false;
            }

            for (var i = 0; i < _coefficients.Length; i++)
            {
                if (!_coefficients[i].Equals(temp._coefficients[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method that overrides GetHashCode method of System.Object class
        /// </summary>
        /// <returns>HashCode of polynomial</returns>
        public override int GetHashCode()
        {
            int hash = 1;
            foreach (var factor in _coefficients)
            {
                hash *= (int)factor;
                hash += Degree;
            }

            return hash;
        }

        /// <summary>
        /// Method that overrides ToString method of System.Object class
        /// </summary>
        /// <returns>String representation of polynomial</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 2; i < _coefficients.Length; i++)
            {
                if (_coefficients[i] > Epsilon)
                {
                    stringBuilder.Append($"{_coefficients[i]} * x ^ {i} + ");
                }
                else
                {
                    continue;
                }
            }

            string s = $"{_coefficients[0]} + {_coefficients[1]} * x + {stringBuilder.ToString()}";

            return s.Substring(0, s.Length - 3);
        }

        /// <summary>
        /// Method determines position by size of polynomial
        /// </summary>
        /// <param name="pol1">first polynomial</param>
        /// <param name="pol2">second polynomial</param>
        /// <param name="larger">larger coefficients</param>
        /// <param name="smaller">smaller coefficients</param>
        private static void CopyPolynomialCoefficients(Polynomial pol1, Polynomial pol2, ref double[] larger, ref double[] smaller)
        {
            if (pol1 is null || pol2 is null)
            {
                throw new ArgumentNullException();
            }

            Array.Copy(pol1._coefficients, larger, larger.Length);
            Array.Copy(pol2._coefficients, smaller, smaller.Length);

            if (larger.Length < smaller.Length)
            {
                larger = new double[pol2.Degree];
                smaller = new double[pol1.Degree];

                Array.Copy(pol2._coefficients, larger, larger.Length);
                Array.Copy(pol1._coefficients, smaller, smaller.Length);
            }
        }
    }
}
