using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace task2
{
    /// <summary>
    /// Contains Convert methods.
    /// </summary>
    public static class DoubleExtension
    {
        private const int BITS_IN_BYTE = 8;

        /// <summary>
        /// Convert double number in a binary system.
        /// </summary>
        /// <param name="number">Number to convert.</param>
        /// <returns>Number in binary system.</returns>
        public static string DoubleToBinaryString(this double number)
        {
            DoubleToLongStruct numberInBinary = new DoubleToLongStruct(number);
            return ConvertToBinary(numberInBinary.Long64Bits);
        }

        /// <summary>
        /// Convert long number in a binary system.
        /// </summary>
        /// <param name="number">Number to convert.</param>
        /// <returns>Number in binary system.</returns>
        private static string ConvertToBinary(long number)
        {
            const int size = sizeof(long) * BITS_IN_BYTE;

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                result.Append((((long)1 << size - 1 - i) & number) != 0 ? '1' : '0');
            }

            return result.ToString();
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly long long64bits;

            [FieldOffset(0)]
            private double double64bits;

            public DoubleToLongStruct(double number)
            {
                long64bits = 0;
                double64bits = number;
            }
            
            public long Long64Bits => long64bits;
        }
    }
}
