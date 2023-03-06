using System.Net.NetworkInformation;

namespace Common.Utility
{
    public static class DatetimeConverter
    {
        /// <summary>
        /// Return current datetime in Australia Estern Standard Time
        /// </summary>
        /// <param name=""></param
        /// <returns>datetime type, ex: 3/3/2023 12:08:44 PM</returns>
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
            if (!DateTime.TryParse(localAUSDateTime, out dateTime)) return DateTime.UtcNow.ToString("s");
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
        /// Return a datetime string in dd/MM/yyyy format
        /// </summary>
        /// <param name="inputDate">the date string with 8 charaters, example: 20230223</param
        /// <returns>string datetime, example 03/03/2023</returns>
        public static string FormatDate_ddMMyyyy_forwardSlash(string inputDate)
        {
            if (string.IsNullOrEmpty(inputDate) || inputDate.Length != 8) return ReturnCurrentAESTDateTime().ToString("dd/MM/yyyy");

            return string.Format("{0}-{1}-{2}", inputDate.Substring(0, 4), inputDate.Substring(4, 2),
                inputDate.Substring(6, 2));
        }

        /// <summary>
        /// Return a Current AEST Datetime string in dd/MM/yyyy format
        /// </summary>
        /// <returns>string datetime, example 03/03/2023</returns>
        public static string FormatCurrentAESTDate_ddMMyyyy_forwardSlash()
        {
            var currentDateTime = ReturnCurrentAESTDateTime();
            return currentDateTime.ToString("dd/MM/yyyy");
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
                out formattedDate) ? ReturnUtcDateTimeFromAESTDateTime(formattedDate.ToString()) : DateTime.UtcNow.ToString("s");
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

        /// <summary>
        /// Return current AEST Time in HHmm format
        /// </summary>
        /// <returns>time in integer type, ex: 1255</returns>
        public static int CurrentTime_HHmm_Format()
        {
            var currentDateTime = ReturnCurrentAESTDateTime();
            var hour = currentDateTime.Hour;
            var minute = currentDateTime.Minute;
            return int.Parse(string.Join("", hour, minute));
        }

        /// <summary>
        /// Return current day of the week[Monday: 1, Tuesday: 2, Wedsnerday: 3, Thursday: 4, Friday: 5, Saterday: 6, Sunday: 7]
        /// </summary>
        /// <returns>current day in week, example 1</returns>
        public static int GetCurrentDayOfWeek()
        {
            var currentDateTime = ReturnCurrentAESTDateTime();
            var dayOfWeek = (int) currentDateTime.DayOfWeek;
            if(dayOfWeek == 0) {
                return 7;//Sunday
            }
            return dayOfWeek;
        }
    }
}