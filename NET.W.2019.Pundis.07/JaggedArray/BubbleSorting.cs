using System;

namespace TaskArray
{
    /// <summary>
    /// Bubblesoring class
    /// </summary>
    public static class BubbleSorting
    {
        /// <summary>
        /// Method for bubble sorting using interface
        /// </summary>
        /// <param name="jaggetArray"></param>
        /// <param name="comparer"></param>
        public static void Sort(this int[][] jaggetArray, IComparer<int[]> comparer)
        {
            if (jaggetArray == null) throw new ArgumentNullException(nameof(jaggetArray));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            jaggetArray.Sort(comparer.Compare);
        }
        /// <summary>
        /// Method for bubble sorting using delegate
        /// </summary>
        /// <param name="jaggetArray"></param>
        /// <param name="comparer"></param>
        public static void Sort(this int[][] jaggetArray, Func<int[], int[], int> comparer)
        {
            if (jaggetArray == null) throw new ArgumentNullException(nameof(jaggetArray));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            for (int i = 0; i < jaggetArray.Length; i++)
            {
                for (int j = 0; j < jaggetArray.Length - 1; j++)
                {
                    int resultOfCompare = comparer.Invoke(jaggetArray[j], jaggetArray[j + 1]);

                    if (resultOfCompare.Equals(1))
                    {
                        jaggetArray.Swap(j, j + 1);
                    }
                    else if (resultOfCompare.Equals(-1))
                    {
                        jaggetArray.Swap(j + 1, j);
                    }
                }
            }
        }
    }
    /// <summary>
    /// Class with "swap" operation
    /// </summary>
    public static class Operations
    {
        public static void Swap(this int[][] jaggedArray, int indexA, int indexB)
        {
            if (jaggedArray == null) throw new ArgumentNullException(nameof(jaggedArray));

            var currentJaggetArray = jaggedArray[indexA];
            jaggedArray[indexA] = jaggedArray[indexB];
            jaggedArray[indexB] = currentJaggetArray;
        }
    }
}
