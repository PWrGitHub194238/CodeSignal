using SortByHeight.Tests.TestData;
using Xunit;

namespace SortByHeight.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldSortNonDescendingWithoutTreesTestData))]
        public void ShouldSortNonDescendingWithoutTrees(int[] a, int[] expectedResult)
        {
            // Arrange

            // Act
            int[] result = Solution.SortByHeight(a);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
