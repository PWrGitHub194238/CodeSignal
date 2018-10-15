using DigitRootSort.Tests.TestData;
using Xunit;

namespace DigitRootSort.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldSortCorrectlyTestData))]
        public void ShouldSortCorrectly(int[] inputArray, int[] sortedArray)
        {
            // Arrange

            // Act
            int[] resultArray = Solution.DigitRootSort(inputArray);

            // Assert
            Assert.Equal(sortedArray, resultArray);
        }
    }
}
