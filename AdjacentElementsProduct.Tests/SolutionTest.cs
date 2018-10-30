using AdjacentElementsProduct.Tests.TestData;
using Xunit;

namespace AdjacentElementsProduct.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldGetLargestProductOfAdjacentsTestData))]
        public void ShouldGetLargestProductOfAdjacents(int[] inputArray, int expectedResult)
        {
            // Arrange

            // Act
            int result = Solution.AdjacentElementsProduct(inputArray);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
