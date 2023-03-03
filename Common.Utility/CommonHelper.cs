using System.Linq;

namespace Common.Utility
{
    public static class CommonHelper
    {
        /// <summary>
        /// Remove the redandunt leading zero in the time string
        /// </summary>
        /// <param name="input">time string</param
        /// <returns>correct time string</returns>
        public static string RemoveLeadingZero(string input)
        {
            if (string.IsNullOrEmpty(input) || input[0] != '0' || input.Length == 4 || input.Length == 6) return input;

            return RemoveLeadingZero(input.Substring(1));
        }

        /// <summary>
        /// Adding zero in the beginning of the string
        /// </summary>
        /// <param name="input">string</param>
        /// <param name="length">length of string</param>
        /// <returns>correct time string</returns>
        public static string AddLeadingZero(string input, int length)
        {
            if (input.Length <= length)
            {
                return input.PadLeft(length, '0');
            }
            return input;
        }
    }
}
