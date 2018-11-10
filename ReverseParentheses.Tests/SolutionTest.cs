using ReverseParentheses.Tests.TestData;
using Xunit;

namespace ReverseParentheses.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldReturnProperlyReversedStringTestData))]
        public void ShouldReturnProperlyReversedString(string s, string expectedResult)
        {
            // Arrange

            // Act
            string result = Solution.ReverseParentheses(s);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
