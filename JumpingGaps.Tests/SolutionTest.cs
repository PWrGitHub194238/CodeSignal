using JumpingGaps.Tests.TestData;
using Xunit;

namespace JumpingGaps.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldReturnTheLeastMovesAmmountTestData))]
        public void ShouldReturnTheLeastMovesAmmount(string[] stage, int expectedResult)
        {
            // Arrange

            // Act
            int result = Solution.JumpingGaps(stage);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
