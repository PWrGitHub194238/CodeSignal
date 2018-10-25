using WordBoggle.Tests.TestData;
using Xunit;

namespace WordBoggle.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldFindAllWordsTestData))]
        public void ShouldFindAllWords(char[][] board, string[] words, string[] expectedResult)
        {
            // Arrange

            // Act
            string[] result = Solution.wordBoggle(board, words);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
