using System;
using System.Runtime.InteropServices;

namespace task2
{
    /// <summary>
    /// Class that contains converting method from double to binary
    /// </summary>
    public static class NumberRepresentationConverter
    {
        private const int BitsInBytes = 8;

        /// <summary>
        /// Extension method for converting double to binary
        /// </summary>
        /// <param name="number">Given double number to convert</param>
        /// <returns>Binary representation of given number</returns>
        public static string DoubleToBinaryString(this double number)
        {
            DoubleToLongStruct convertStruct = new DoubleToLongStruct { Double64bits = number };
            long value = convertStruct.Long64bits;
            int bitsCount = (int)Math.Pow(BitsInBytes, 2);
            char[] result = new char[bitsCount];
            result[0] = value < 0 ? '1' : '0';
            for (int i = bitsCount - 2, j = 1; i >= 0; i--, j++)
            {
                result[j] = (value & (1L << i)) != 0 ? '1' : '0';
            }

            return new string(result);
        }

        /// <summary>
        /// Struct that contains fields and properties for long and double numbers
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly long long64bits;

            [FieldOffset(0)]
            private double double64bits;

            public double Double64bits
            {
                set
                {
                    double64bits = value;
                }
            }

            public long Long64bits
            {
                get
                {
                    return long64bits;
                }
            }
        }
    }
}