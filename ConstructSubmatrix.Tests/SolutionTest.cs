using ConstructSubmatrix.Tests.TestData;
using Xunit;

namespace ConstructSubmatrix.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldMatchGivenSubMatrixAfterColOrRowRemovalTestData))]
        public void ShouldMatchGivenSubMatrixAfterColOrRowRemoval(int[][] matrix, int[] rowsToDelete, int[] columnsToDelete, int[][] expectedResult)
        {
            // Arrange

            // Act
            int[][] result = Solution.ConstructSubmatrix(matrix, rowsToDelete, columnsToDelete);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
