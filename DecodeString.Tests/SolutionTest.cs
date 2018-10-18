using DecodeString.Tests.TestData;
using Xunit;

namespace DecodeString.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldDecodeStringCorrectlyTestData))]
        public void ShouldDecodeStringCorrectly(string s, string expectedResult)
        {
            // Arrange

            // Act
            string result = Solution.decodeString(s);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
