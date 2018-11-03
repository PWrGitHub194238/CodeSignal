using MatrixElementsSum.Tests.TestData;
using Xunit;

namespace MatrixElementsSum.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldReturnSuitableRoomsTotalCostTestData))]
        public void ShouldReturnSuitableRoomsTotalCost(int[][] matrix, int expectedResult)
        {
            // Arrange

            // Act
            int result = Solution.matrixElementsSum(matrix);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
