using CommonCharacterCount.Tests.TestData;
using Xunit;

namespace CommonCharacterCount.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldCountOnlyCommonCharactersTestData))]
        public void ShouldCountOnlyCommonCharacters(string s1, string s2, int expectedResult)
        {
            // Arrange

            // Act
            int result = Solution.commonCharacterCount(s1, s2);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
