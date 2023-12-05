using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utilities
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts an integer into a string with an ordinal
        /// (i.e. 1 -> 1st, 2 -> 2nd, 11 -> 11th, etc.)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string AddOrdinal(this int number)
        {
            if (number <= 0) return number.ToString();

            switch (number % 100)
            {
                case 11:
                case 12:
                case 13:
                    return number + "th";
            }

            switch (number % 10)
            {
                case 1:
                    return number + "st";

                case 2:
                    return number + "nd";

                case 3:
                    return number + "rd";

                default:
                    return number + "th";
            }
        }
        
        /// <summary>
        /// Converts a string to byte array
        /// </summary>
        /// <param name="input">The string</param>
        /// <returns>The byte array</returns>
        public static byte[] ConvertToByteArray(this string input)
        {
            return input.Select(Convert.ToByte).ToArray();
        }

        /// <summary>
        /// Converts a byte array to a string
        /// </summary>
        /// <param name="bytes">the byte array</param>
        /// <returns>The string</returns>
        public static string ConvertToString(this byte[] bytes)
        {
            return new string(bytes.Select(Convert.ToChar).ToArray());
        }

        /// <summary>
        /// Converts a byte array to a string
        /// </summary>
        /// <param name="bytes">the byte array</param>
        /// <returns>The string</returns>
        public static string ConvertToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// Converts a string to a byte array
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] ConvertFromBase64String(this string input)
        {
            return Convert.FromBase64String(input);
        }

        public static string ByteArrayToString(this byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-","");
        }

        public static string SanitizeNameString(this string name)
        {
            return Regex.Replace(name, @"[^a-zA-Z0-9 \'\-]", "");
        }
    }
}