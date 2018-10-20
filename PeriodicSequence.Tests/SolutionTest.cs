using PeriodicSequence.Tests.TestData;
using Xunit;

namespace PeriodicSequence.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldFoundMinimalPeriodTestData))]
        public void ShouldFoundMinimalPeriod(int s0, int a, int b, int m, int expectedResult)
        {
            // Arrange

            // Act
            int result = Solution.periodicSequence(s0, a, b, m);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
