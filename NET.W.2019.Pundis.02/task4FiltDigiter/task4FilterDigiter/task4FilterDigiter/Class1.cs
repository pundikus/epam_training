﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4FilterDigiter
{
    public static class FilterDigiter
    {
        /// <summary>
        /// This Method returns list numbers containing the given digit
        /// </summary>
        /// <param name="list">source list</param>
        /// <param name="value">the number by which we will filter</param>
        /// <returns>list numbers containing the given digit</returns>
        public static List<int> FilterDigit(List<int> list, int value)
        {
            var list_value = new List<int>();

            foreach (var item in list)
            {
                if (SearchMiddle(item, value))
                {
                    list_value.Add(item);
                }
            }

            return list_value;
        }
        /// <summary>
        /// This Method search number that is in the value
        /// </summary>
        private static bool SearchMiddle(int element, int value)
        {
            var string_value = element.ToString();
            var char_array_value = string_value.ToCharArray();

            var int_array_value = new int[char_array_value.Length];

            for (int i = 0; i < char_array_value.Length; i++)
            {
                int_array_value[i] = char_array_value[i] - '0';
            }

            foreach (var item in int_array_value)
            {
                if (item == value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}