namespace Common.Utility.Test
{
    public class CommonHelperTest
    {
        [Theory]
        [InlineData("000061815")]
        public void RemoveLeadingZero_ReturnTrue(string timeString)
        {
            var resultTime = CommonHelper.RemoveLeadingZero(timeString);

            Assert.Equal("061815", resultTime);
        }

        [Theory]
        [InlineData("311466", 8)]
        public void AddLeadingZero_ReturnTrue(string dataString, int length)
        {
            var result = CommonHelper.AddLeadingZero(dataString, length);

            Assert.Equal(length, result.Length);
        }

        [Theory]
        [InlineData(2.000)]
        public void ConvertDecimalToInt_ReturnTrue(decimal dataString)
        {
            var result = CommonHelper.ConvertDecimalToInt(dataString);

            Assert.Equal(2, result);
        }
    }
}
