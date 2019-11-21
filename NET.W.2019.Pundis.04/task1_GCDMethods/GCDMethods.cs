using System;

namespace task1
{
    public class GCDMethods
    {
        /// <summary>
        /// Method that calculates GCD for 2 numbers using Euclid algorythm
        /// </summary>
        /// <param name="a">1st number</param>
        /// <param name="b">2nd number</param>
        /// <returns>GCD of given numbers</returns>
        public static int EuclidGCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }

            while (b != 0)
            {
                b = a % (a = b);
            }

            return a;
        }

        /// <summary>
        /// Method that calculates GCD for 3 numbers using Euclid algorythm
        /// </summary>
        /// <param name="a">1st number</param>
        /// <param name="b">2nd number</param>
        /// <param name="c">3rd number</param>
        /// <returns>GCD of given numbers</returns>
        public static int EuclidGCD(int a, int b, int c) => FindGCD(EuclidGCD, a, b, c);

        /// <summary>
        /// Method that calculates GCD using Euclid algorythm
        /// </summary>
        /// <param name="array">Array of 2, 3 or more numbers</param>
        /// <returns>GCD of given numbers</returns>
        public static int EuclidGCD(params int[] array) => FindGCD(EuclidGCD, array);

        /// <summary>
        /// Method that calculates GCD for 2 numbers using Stein algorythm (Euclid binary algorythm)
        /// </summary>
        /// <param name="a">1st number</param>
        /// <param name="b">2nd number</param>
        /// <returns>GCD of given numbers</returns>
        public static int SteinGCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }

            int k = 1;
            a = Math.Abs(a);
            b = Math.Abs(b);
            while ((a != 0) && (b != 0))
            {
                while ((a % 2 == 0) && (b % 2 == 0))
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }

                while (a % 2 == 0)
                {
                    a /= 2;
                }

                while (b % 2 == 0)
                {
                    b /= 2;
                }

                if (a >= b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return b * k;
        }

        /// <summary>
        /// Method that calculates GCD for 2 numbers using Stein algorythm (Euclid binary algorythm)
        /// </summary>
        /// <param name="a">1st number</param>
        /// <param name="b">2nd number</param>
        /// <param name="c">3rd number</param>
        /// <returns>GCD of given numbers</returns>
        public static int SteinGCD(int a, int b, int c) => FindGCD(SteinGCD, a, b, c);

        /// <summary>
        /// Method that calculates GCD using Stein algorythm (Euclid binary algorythm)
        /// </summary>
        /// <param name="array">Array of 2, 3 or more numbers</param>
        /// <returns>GCD of given numbers</returns>
        public static int SteinGCD(params int[] array) => FindGCD(SteinGCD, array);        

        private static int FindGCD(Func<int, int, int> gcdDelegate, int a, int b, int c)
        {
            if (gcdDelegate == null)
            {
                throw new ArgumentNullException(nameof(gcdDelegate));
            }

            int[] array = { a, b, c };
            int gcd = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                gcd = gcdDelegate(gcd, array[i + 1]);
            }

            return gcd;
        }

        private static int FindGCD(Func<int, int, int> gcdDelegate, params int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException(nameof(array));
            }
                        
            if (gcdDelegate == null)
            {
                throw new ArgumentNullException(nameof(gcdDelegate));
            }

            int gcd = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                gcd = gcdDelegate(gcd, array[i + 1]);
            }

            return gcd;
        }
    }
}