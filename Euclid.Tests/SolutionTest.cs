using Euclid.Tests.TestData;
using Xunit;

namespace Euclid.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldMatchParallelogramCoordinatesTestData))]
        public void ShouldMatchParallelogramCoordinates(double[] coordinates, double[] expectedResult)
        {
            // Arrange

            // Act
            double[] result = Solution.Euclid(coordinates);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
