using System;

namespace JaggedArraySorter
{
    /// <summary>
    /// JaggedArray class with some properties and methods
    /// </summary>
    public class JaggedArray
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array"></param>
        public JaggedArray(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Array = array;
        }

        /// <summary>
        /// Property for array
        /// </summary>
        public int[][] Array { get; }

        /// <summary>
        /// Swap method
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        public void Swap(ref int[] arr1, ref int[] arr2)
        {
            int[] buff = arr1;
            arr1 = arr2;
            arr2 = buff;
        }

        /// <summary>
        /// Method for searching min element
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int Min(int[] array)
        {
            int min = int.MaxValue;
            foreach (int item in array)
            {
                if (item < min)
                {
                    min = item;
                }
            }

            return min;
        }

        /// <summary>
        /// Method for searching max element
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int Max(int[] array)
        {
            int max = int.MinValue;
            foreach (int item in array)
            {
                if (item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        /// <summary>
        /// Method for sum
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int Sum(int[] array)
        {
            int sum = 0;
            foreach (int element in array)
            {
                sum += element;
            }

            return sum;
        }
    }

    /// <summary>
    /// Class that sort by sum
    /// </summary>
    public class SortBySumOfTheElements
    {
        public void GetCompareElements(JaggedArray array)
        {
            for (int i = 0; i < array.Array.Length; i++)
            {
                for (int j = 0; j < array.Array[i].Length; j++)
                {
                    if (array.Sum(array.Array[i]) < array.Sum(array.Array[j]))
                    {
                        array.Swap(ref array.Array[i], ref array.Array[j]);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Class that sort by max elements
    /// </summary>
    public class SortByMaximumOfTheElements
    {
        public void GetCompareElements(JaggedArray array)
        {
            for (int i = 0; i < array.Array.Length; i++)
            {
                for (int j = 0; j < array.Array[i].Length; j++)
                {
                    if (array.Max(array.Array[i]) < array.Max(array.Array[j]))
                    {
                        array.Swap(ref array.Array[i], ref array.Array[j]);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Class that sort by minimum elements
    /// </summary>
    public class SortByMinimumOfTheElements
    {
        public void GetCompareElements(JaggedArray array)
        {
            for (int i = 0; i < array.Array.Length; i++)
            {
                for (int j = 0; j < array.Array[i].Length; j++)
                {
                    if (array.Min(array.Array[i]) < array.Min(array.Array[j]))
                    {
                        array.Swap(ref array.Array[i], ref array.Array[j]);
                    }
                }
            }
        }
    }
}