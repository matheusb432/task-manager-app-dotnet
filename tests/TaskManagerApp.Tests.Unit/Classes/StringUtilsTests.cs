using TaskManagerApp.Application.Utils;

namespace TaskManagerApp.Tests.Classes
{
    public class StringUtilsTests
    {
        [Theory]
        [InlineData("Ab", 3, "AbAbAb")]
        [InlineData("Ab", 2, "AbAb")]
        [InlineData("Ab", 1, "Ab")]
        [InlineData("Ab", 0, "")]
        [InlineData("", 2, "")]
        [InlineData("St R -", 2, "St R -St R -")]
        public void Repeat_ShouldRepeatString(string value, int count, string expected)
        {
            var actual = value.Repeat(count);

            Assert.Equal(expected, actual);
        }
    }
}