using TreeBottom.Tests.TestData;
using Xunit;

namespace TreeBottom.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldReturnListOfLowestLeveledNodesTestData))]
        public void ShouldReturnListOfLowestLeveledNodes(string tree, int[] expectedResult)
        {
            // Arrange

            // Act
            int[] result = Solution.TreeBottom(tree);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
