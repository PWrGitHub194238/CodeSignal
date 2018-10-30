using ShapeArea.Tests.TestData;
using Xunit;

namespace ShapeArea.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldReturnProperAreaTestData))]
        public void ShouldReturnProperArea(int n, int expectedResult)
        {
            // Arrange

            // Act
            int result = Solution.shapeArea(n);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
