using TaskManagerApp.Application.Utils;

namespace TaskManagerApp.Tests.Unit.Classes
{
    public sealed class TimeUtilsTests
    {
        [Theory]
        [InlineData("09:30", 930)]
        [InlineData("10:00", 1000)]
        [InlineData("00:35", 35)]
        [InlineData("00:50", 50)]
        [InlineData("00:07", 7)]
        public void ConvertTimeToShort_WithValidTime_ReturnsNumber(string time, short expected)
        {
            var result = TimeUtils.ConvertTimeToShort(time);

            Assert.IsType<short>(result);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("0:0")]
        [InlineData("0:00")]
        [InlineData("00:0")]
        [InlineData("0000")]
        public void ConvertTimeToShort_WithInvalidTime_ReturnsZero(string time)
        {
            var result = TimeUtils.ConvertTimeToShort(time);

            Assert.Equal((short)0, result);
        }

        [Theory]
        [InlineData(930, "09:30")]
        [InlineData(1000, "10:00")]
        [InlineData(35, "00:35")]
        [InlineData(50, "00:50")]
        [InlineData(7, "00:07")]
        public void ConvertShortToTime_WithValidNumber_ReturnsTime(short number, string expected)
        {
            var result = TimeUtils.ConvertShortToTime(number);

            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData((short)-51)]
        [InlineData((short)10523)]
        [InlineData(null)]
        public void ConvertShortToTime_WithInvalidNumber_ReturnsEmpty(short? number)
        {
            var result = TimeUtils.ConvertShortToTime(number);

            Assert.IsType<string>(result);
            Assert.Equal(string.Empty, result);
        }
    }
}