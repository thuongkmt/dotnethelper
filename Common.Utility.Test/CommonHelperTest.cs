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
    }
}
