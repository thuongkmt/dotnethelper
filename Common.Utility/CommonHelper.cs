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
    }
}
