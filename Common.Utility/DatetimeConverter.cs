namespace Common.Utility
{
    public static class DatetimeConverter
    {
        /// <summary>
        /// Return current datetime in Australia Estern Standard Time
        /// </summary>
        /// <param name=""></param
        /// <returns>datetime type</returns>
        public static DateTime ReturnCurrentAESTDateTime()
        {
            DateTime utcDt = DateTime.UtcNow;
            TimeZoneInfo aestZone = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
            DateTime aestDt = TimeZoneInfo.ConvertTimeFromUtc(utcDt, aestZone);

            return aestDt;
        }

        /// <summary>
        /// Return utc datetime string based on the Australia Estern Standard Time
        /// </summary>
        /// <param name="localAUSDateTime"></param
        /// <returns>datetime string, example 2023-02-23T01:56:10</returns>
        public static string ReturnUtcDateTimeFromAESTDateTime(string localAUSDateTime)
        {
            DateTime dateTime;
            if (!DateTime.TryParse(localAUSDateTime, out dateTime)) return new DateTime().ToUniversalTime().ToString("s");
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, "AUS Eastern Standard Time", "UTC").ToString("s");
        }

        /// <summary>
        /// Return a datetime string in yyyy-MM-dd format
        /// </summary>
        /// <param name="inputDate">the date string with 8 charaters, example: 20230223</param
        /// <returns>string datetime, example 2023-02-23</returns>
        public static string FormatDate_yyyyMMdd_dash(string inputDate)
        {
            if (string.IsNullOrEmpty(inputDate) || inputDate.Length != 8) return ReturnCurrentAESTDateTime().ToString("yyyy-MM-dd");

            return string.Format("{0}-{1}-{2}", inputDate.Substring(0, 4), inputDate.Substring(4, 2),
                inputDate.Substring(6, 2));
        }

        /// <summary>
        /// Return UTC datetime string base on the Australia Estern Standard Time string input
        /// </summary>
        /// <param name="inputDate">the Australia Estern Standard Time string, example: 20221215 16:32:55</param
        /// <returns>utc datetime string, example 2022-12-15T05:32:55</returns>
        public static string ReturnUtcDateTimeBased_yyyyMMddHHmmss_Formated_AESTDateTime(string documentDate)
        {
            DateTime formattedDate;
            return DateTime.TryParseExact(documentDate, "yyyyMMdd HH:mm:ss",
                new System.Globalization.DateTimeFormatInfo(), System.Globalization.DateTimeStyles.None,
                out formattedDate) ? ReturnUtcDateTimeFromAESTDateTime(formattedDate.ToString()) : new DateTime().ToUniversalTime().ToString("s");
        }

        public static string FormatTime(string inputTime)
        {
            if (string.IsNullOrEmpty(inputTime)) return "00:00:00";
            switch (inputTime.Length)
            {
                case 4:
                    return string.Format("{0}:{1}:00", inputTime.Substring(0, 2), inputTime.Substring(2, 2));
                case 6:
                    return string.Format("{0}:{1}:{2}", inputTime.Substring(0, 2), inputTime.Substring(2, 2), inputTime.Substring(4, 2));
                default:
                    return inputTime;
            }
        }
    }
}