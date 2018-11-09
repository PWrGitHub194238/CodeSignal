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
            string result = Solution.reverseParentheses(s);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
