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
        [InlineData("2/23/2023 12:56:10 PM")]
        [InlineData("2023-02-23T12:56:10")]
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

    }
}