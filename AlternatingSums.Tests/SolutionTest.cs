using AlternatingSums.Tests.TestData;
using Xunit;

namespace AlternatingSums.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldReturnTeamTotalWeightsTestData))]
        public void ShouldReturnTeamTotalWeights(int[] a, int[] expectedResult)
        {
            // Arrange

            // Act
            int[] result = Solution.AlternatingSums(a);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}