﻿using System;

namespace FindRooter
{
    /// <summary>
    /// Class that contains calculating methods
    /// </summary>
    public class FindNthRooter
    {
        /// <summary>
        /// Method that calculates n-degree root of given number
        /// </summary>
        /// <param name="number">Number for calculating n-degree root</param>
        /// <param name="degree">Root of given degree</param>
        /// <param name="precision">Required precision for calculating</param>
        /// <returns>N-degree root of given number</returns>
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if (precision > 1 || precision < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(precision)} must be from 0 to 1");
            }

            if (degree % 2 == 0 && number < 0)
            {
                throw new ArgumentOutOfRangeException($"If number is negative, even {nameof(degree)} cannot be taken.");
            }

            double x0 = number;
            double x1 = (((degree - 1) * x0) + (number / Math.Pow(x0, degree - 1))) / degree;
            while (Math.Abs(x1 - x0) >= precision)
            {
                x0 = x1;
                x1 = (((degree - 1) * x0) + (number / Math.Pow(x0, degree - 1))) / degree;
            }

            return x1;
        }
    }
}
