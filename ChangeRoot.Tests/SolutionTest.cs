using ChangeRoot.Tests.TestData;
using Xunit;

namespace ChangeRoot.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldReturnParentArrayForNewTreeAfterRootChangeTestData))]
        public void ShouldReturnParentArrayForNewTreeAfterRootChange(int[] parent, int newRoot, int[] expectedResult)
        {
            // Arrange

            // Act
            int[] result = Solution.changeRoot(parent, newRoot);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
