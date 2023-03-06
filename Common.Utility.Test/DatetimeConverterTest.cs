namespace Common.Utility.Test
{
    public class DatetimeConverterTest
    {
        [Fact]
        public void ReturnCurrentAESTDateTime_ReturnTrue()
        {
            var currentDateTimeInAEST = DatetimeConverter.ReturnCurrentAESTDateTime();
        }

        [Theory]
        
        [InlineData("010323")]
        public void ReturnUtcDateTimeFromAESTDateTime_ReturnTrue(string inputDate)
        {
            var resultDateTimeInUTC = DatetimeConverter.ReturnUtcDateTimeFromAESTDateTime(inputDate);

            Assert.Equal("2023-02-23T01:56:10", resultDateTimeInUTC);
        }

        [Theory]
        [InlineData("20221215 16:32:55")]
        public void ReturnUtcDateTimeBased_yyyyMMddHHmmss_Format_ReturnTrue(string inputDate)
        {
            var resultDateTimeInUTC = DatetimeConverter.ReturnUtcDateTimeBased_yyyyMMddHHmmss_Formated_AESTDateTime(inputDate);

            Assert.Equal("2022-12-15T05:32:55", resultDateTimeInUTC);
        }

        [Theory]
        [InlineData("20230223")]
        public void FormatDate_yyyyMMdd_dash_ReturnTrue(string inputDate)
        {
            var resultDateFormat = DatetimeConverter.FormatDate_yyyyMMdd_dash(inputDate);

            Assert.Equal("2023-02-23", resultDateFormat);
        }

        [Fact]
        public void FormatDate_ddMMyyyy_forwardSlash_ReturnTrue()
        {
            var currentDateTime = DatetimeConverter.ReturnCurrentAESTDateTime();
            var resultDateFormat = DatetimeConverter.FormatCurrentAESTDate_ddMMyyyy_forwardSlash();

            Assert.Equal(currentDateTime.ToString("dd/MM/yyyy"), resultDateFormat);
        }

        [Fact]
        public void CurrentTime_HHmm_Format_ReturnTrue()
        {
            var hourMinute = DatetimeConverter.CurrentTime_HHmm_Format();
        }

        [Fact]
        public void GetCurrentDay_ReturnTrue()
        {
            var dayOfWeek = DatetimeConverter.GetCurrentDayOfWeek();
        }
    }
}