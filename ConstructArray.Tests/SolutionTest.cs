using ConstructArray.Tests.TestData;
using Xunit;

namespace ConstructArray.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldContainItemsInGivenOrderTestData))]
        public void ShouldContainItemsInGivenOrder(int size, int[] expectedResult)
        {
        // Arrange

        // Act
        int[] result = Solution.constructArray(size);

        // Assert
        Assert.Equal(expectedResult, result);

        }
    }
}
