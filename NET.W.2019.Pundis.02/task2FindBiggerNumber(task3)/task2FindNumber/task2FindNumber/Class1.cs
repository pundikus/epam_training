﻿// <auto-generated />
namespace Task2FindNumber
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for search next bigger number
    /// </summary>
    public static class FindNumber
    {
        /// <summary>
        /// List for combination elements
        /// </summary>
        private static List<int> listCombination = new List<int>();

        /// <summary>
        /// This method returns the near the largest integer consisting of digits of the original number
        /// </summary>
        /// <param name="value">initial number</param>
        /// <param name="elapsedMs">runtime for method FindNextBiggerNumber</param>
        /// <returns>largest integer consisting of digits of the original number</returns>
        public static int FindNextBiggerNumber(int value, out long elapsedMs)
        {
            if (value <= 0)
            {
                throw new ArgumentException("value is not correct");
            }

            var watch = System.Diagnostics.Stopwatch.StartNew(); // reference point
            int result = -1;

            var value_string = value.ToString();
            var array_char_value = value_string.ToCharArray();
            var array_int_value = new int[array_char_value.Length];

            for (int i = 0; i < array_char_value.Length; i++)
            {
                array_int_value[i] = array_char_value[i] - '0';
            }

            Shuffle(array_int_value);

            listCombination.Sort();

            var array_combination = listCombination.ToArray();

            for (int i = 0; i < array_combination.Length; i++)
            {
                if (value == array_combination[array_combination.Length - 1])
                {
                    break;
                }

                if (array_combination[i] == value)
                {
                    result = array_combination[i + 1];
                }
            }

            watch.Stop();                                       // end of reference
            elapsedMs = watch.ElapsedMilliseconds;              // variable for storing function run time

            return result;
        }

        /// <summary>
        /// This method returns count combinations(Factorial)
        /// </summary>
        /// <param name="numb">initial number</param>
        /// <returns>returns count combinations</returns>
        private static int Factorial(int numb)
        {
            int result = 1;
            for (int i = numb; i > 1; i--)
            {
                result *= i;
            }

            return result;
        }

        /// <summary>
        /// This method change elements
        /// </summary>
        /// <param name="i">first value</param>
        /// <param name="j">second value</param>
        private static void Swap(ref int i, ref int j)
        {
            int t = i;
            i = j;
            j = t;
        }

        /// <summary>
        /// This method adds all combinations of numbers to the list
        /// </summary>
        /// <param name="n">count elements of array</param>
        /// <param name="arr">input element array</param>
        private static void Generate(int n, int[] arr)
        {
            if (n == 0)
            {
                string value_string = string.Join(string.Empty, arr);

                int value_int = Convert.ToInt32(value_string);

                listCombination.Add(value_int);

                return;
            }

            for (int i = 0; i < n; i++)
            {
                Generate(n - 1, arr);

                int j = n % 2 == 0 ? 0 : i;

                Swap(ref arr[j], ref arr[n - 1]);
            }
        }

        /// <summary>
        /// This method sets array values ​​to the "Generate" method
        /// </summary>
        /// <param name="n">source array</param>
        private static void Shuffle(int[] n)
        {
            if (n == null)
            {
                throw new ArgumentNullException("array is empty");
            }

            Generate(n.Length, n);
        }
    }
}
