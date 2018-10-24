using TextJustification.Tests.TestData;
using Xunit;

namespace TextJustification.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldJustifyGivenTextsTestData))]
        public void ShouldJustifyGivenTexts(string[] words, int l, string[] expectedResult)
        {
            // Arrange

            // Act
            string[] result = Solution.TextJustification(words, l);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
