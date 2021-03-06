﻿namespace NET.W._2019.Pundis._01
{
    using System;
    
    /// <summary>
    /// Class for Quicksorting
    /// </summary>
    class QuickSorter
    {
        /// <summary>
        /// This method for exchanging array elements
        /// </summary>
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        /// <summary>
        /// This method returns the index of the reference element
        /// </summary>
        /// <param name="minIndex">first element of array</param>
        /// <param name="maxIndex">last element of array</param>
        /// <returns>index of the reference element</returns>
        private static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;

            Swap(ref array[pivot], ref array[maxIndex]);

            return pivot;
        }

        /// <summary>
        /// This method recursively sorts array before and after the reference element
        /// </summary>
        /// <returns>sorted array</returns>
        private static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        /// <summary>
        /// This Method sort initial array
        /// </summary>
        /// <param name="array">initial array</param>
        /// <returns>sort array</returns>
        public static int[] QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array is empty");
            }

            return QuickSort(array, 0, array.Length - 1);
        }

    }

    /// <summary>
    /// Class for Mergesorting
    /// </summary>
    class MergeSorter
    {
        /// <summary>
        /// This method join arrays
        /// </summary>
        /// <param name="lowIndex">first element of array</param>
        /// <param name="middleIndex">mid array</param>
        /// <param name="highIndex">last element of array</param>
        private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        /// <summary>
        /// This method recursively sorts array before and after the middle element
        /// </summary>
        /// <param name="lowIndex">first element of array</param>
        /// <param name="highIndex">last element of array</param>
        /// <returns>sorted array</returns>
        private static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        /// <summary>
        /// This Method sort initial array
        /// </summary>
        /// <param name="array">initial array</param>
        /// <returns>sort array</returns>
        public static int[] MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array is empty");
            }

            return MergeSort(array, 0, array.Length - 1);
        }
    }
}
