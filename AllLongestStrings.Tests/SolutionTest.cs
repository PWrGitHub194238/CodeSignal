using AllLongestStrings.Tests.TestData;
using Xunit;

namespace AllLongestStrings.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldReturnOnlyLongestStringsTestData))]
        public void ShouldReturnOnlyLongestStrings(string[] inputArray, string[] expectedResult)
        {
            // Arrange

            // Act
            string[] result = Solution.allLongestStrings(inputArray);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
