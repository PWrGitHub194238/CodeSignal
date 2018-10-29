using CheckPalindrome.Tests.TestData;
using Xunit;

namespace CheckPalindrome.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldRecognizePalindromeTestData))]
        public void ShouldRecognizePalindrome(string inputString, bool expectedResult)
        {
            // Arrange

            // Act
            bool result = Solution.checkPalindrome(inputString);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
